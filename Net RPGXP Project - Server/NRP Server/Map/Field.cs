using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NRP_Server
{
    class Field
    {
        public Dictionary<int, UserCharacter> Users = new Dictionary<int, UserCharacter>();
        public Dictionary<int, DropItem> DropItems = new Dictionary<int, DropItem>();
        public ArrayList Enemies;
        public int mapid { get; private set; }
        public int seed { get; private set; }
        
        public Field(int _mapid, int _seed)
        {
            mapid = _mapid;
            seed = _seed;
            loadEnemyData();
        }

        // 필드 몬스터 데이터를 로드합니다.
        public void loadEnemyData()
        {
            int count = 0;
            Enemy obj;
            Enemies = new ArrayList();
            DataTable pos = Mysql.Query($"SELECT * FROM enemy_position WHERE map_id = '{mapid}'");
            DataTable ds;
            foreach (DataRow ps in pos.Rows)
            {
                ds = Mysql.Query($"SELECT * FROM enemy WHERE no = '{ps["enemy_no"]}'");
                obj = new Enemy(this);
                Enemies.Add(obj);
                obj.loadData(ds.Rows[0], Enemies.IndexOf(obj), mapid, Convert.ToInt32(ps["map_x"]), Convert.ToInt32(ps["map_y"]));
                count++;
            }
            Msg.Info($"[맵] {mapid}번 {count} 개의 몬스터 로드 완료");
        }

        // 충돌 판정
        public bool passable(int x, int y, int dir)
        {
            int new_x, new_y;
            Map map = Map.Maps[mapid];
            new_x = x + (dir == 4 ? -1 : dir == 6 ? 1 : 0);
            new_y = y + (dir == 8 ? -1 : dir == 2 ? 1 : 0);
            // 범위 외 값 판정
            if (new_x >= map.width || new_y >= map.height || new_x < 0 || new_y < 0)
                return false;
            // 유저 충돌판정
            foreach(UserCharacter c in Users.Values)
                if (c.x == new_x && c.y == new_y) { return false; }
            // NPC 충돌판정
            foreach (NPC npc in map.npcData.Values)
                if (npc.x == new_x && npc.y == new_y) { return false; }
            // 넷이벤트 충돌판정
            foreach (Enemy enemy in Enemies)
                if (enemy.x == new_x && enemy.y == new_y && !enemy.IsDead) { return false; }
            // 갈 수 없는 곳 판정
            return (map.flagData[new_x, new_y] == 1 ? false : true);
        }
        // 포탈(장소이동) 판정
        public bool portal(UserCharacter u)
        {
            if (Users.ContainsKey(u.no)) {
                Map map = Map.Maps[mapid];
                // 포탈 판정
                if (map.portalData.ContainsKey($"{u.x},{u.y}"))
                {
                    Portal portal = map.portalData[$"{u.x},{u.y}"];
                    // 이동시키기
                    leave(u.no);
                    Map.Maps[portal.move_mapid].Fields[0].join(u, portal.move_x, portal.move_y);
                    return true;
                }
            }
            return false;
        }

        // 필드의 유저들을 해당 유저에게 로드합니다.
        public bool loadUser(UserCharacter u)
        {
            if (!Users.ContainsKey(u.no))
                return false;
            foreach (UserCharacter c in Users.Values)
            {
                if (c == u) { continue; }
                u.userData.clientData.SendPacket(Packet.CharacterCreate(c));
            }
            return true;
        }
        // 필드의 NPC들을 해당 유저에게 로드합니다.
        public bool loadNPC(UserCharacter u)
        {
            if (!Users.ContainsKey(u.no))
                return false;
            foreach (NPC obj in Map.Maps[mapid].npcData.Values)
                u.userData.clientData.SendPacket(Packet.NPCCreate(obj));

            return true;
        }
        // 필드의 몬스터들을 해당 유저에게 로드합니다.
        public bool loadEnemy(UserCharacter u)
        {
            if (!Users.ContainsKey(u.no))
                return false;
            foreach (Enemy obj in Enemies)
                u.userData.clientData.SendPacket(Packet.EnemyCreate(obj));

            return true;
        }
        // 필드의 드랍아이템들을 해당 유저에게 로드합니다.
        public bool loadDropItem(UserCharacter u)
        {
            if (!Users.ContainsKey(u.no))
                return false;
            foreach (DropItem obj in DropItems.Values)
                u.userData.clientData.SendPacket(Packet.DropItemCreate(obj));

            return true;
        }


        // 드랍아이템을 생성합니다.
        public void addDropItem(int x, int y, EnemyDropData item)
        {
            int index = 0;
            for (int i = 0; i < 10000; i++)
                if (!DropItems.ContainsKey(i)) { index = i; break; }

            DropItem obj = new DropItem(index, x, y, item);
            DropItems.Add(index, obj);

            // 모든유저 패킷
            AllSendPacket(Packet.DropItemCreate(obj));
        }
        public void addDropItem(int x, int y, Item item, int number=1)
        {
            int index = 0;
            for (int i = 0; i < 10000; i++)
                if (!DropItems.ContainsKey(i)) { index = i; break; }

            DropItem obj = new DropItem(index, x, y, item, number);
            DropItems.Add(index, obj);

            // 모든유저 패킷
            AllSendPacket(Packet.DropItemCreate(obj));
        }
        // 드랍아이템을 획득합니다.
        public void gainDropItem(UserCharacter u, int index)
        {
            DropItem item = DropItems[index];
            item.gain(u);
            deleteDropItem(index);
        }
        // 드랍아이템을 제거합니다.
        public void deleteDropItem(int index)
        {
            DropItems.Remove(index);
            AllSendPacket(Packet.DropItemDelete(index));
        }

        // 몬스터를 생성합니다.
        public int addEnemy(int enemy_no, int x, int y)
        {
            Enemy obj;
            DataTable ds;
            int index;
            ds = Mysql.Query($"SELECT * FROM enemy WHERE no = '{enemy_no}'");
            obj = new Enemy(this);
            Enemies.Add(obj);
            index = Enemies.IndexOf(obj);
            obj.loadData(ds.Rows[0], index, mapid, x, y);
            // 패킷
            AllSendPacket(Packet.EnemyCreate(obj));
            return index;
        }
        // 몬스터를 제거합니다.
        public void deleteEnemy(int index)
        {
            if (index >= 0 && index < Enemies.Count)
            {
                Enemy obj = Enemies[index] as Enemy;
                // del Packet

                // del
                Enemies.Remove(obj);
            }
        }

        // 필드에 해당 유저를 입장시킵니다.
        public bool join(UserCharacter u, int _x, int _y)
        {
            if (Users.ContainsKey(u.no))
                return false;
            AllSendPacket(Packet.CharacterCreate(u));
            u.FieldData = this;
            Users.Add(u.no, u);
            u.moveto(_x, _y, u.direction);
            loadUser(u);
            loadNPC(u);
            loadEnemy(u);
            loadDropItem(u);
            return true;
        }
        // 필드에서 해당 유저를 퇴장시킵니다.
        public bool leave(int no)
        {
            if (!Users.ContainsKey(no))
                return false;
            foreach (UserCharacter _char in Users.Values)
            {
                if (_char.no == no) { continue; }
                _char.userData.clientData.SendPacket(Packet.DeleteCharacter(Users[no]));
            }
            foreach (Enemy enemy in Enemies)
                if (enemy.target == Users[no])
                    enemy.target = null;
            Users[no].fieldData = null;
            Users.Remove(no);
            return true;
        }

        // 필드에 있는 모든 유저에게 패킷 전송
        public void AllSendPacket(Hashtable data)
        {
            try
            {
                foreach (UserCharacter c in Users.Values)
                    c.userData.clientData.SendPacket(data);
            }
            catch(Exception e)
            {
                Msg.Error(e.ToString());
            }
            
        }

        // 몬스터 업데이트
        public void update()
        {
            if (Users.Count == 0) { return; }
            foreach (Enemy obj in Enemies)
                obj.update();
        }
    }
}

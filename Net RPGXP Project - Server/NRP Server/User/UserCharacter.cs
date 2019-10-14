using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace NRP_Server
{
    class UserCharacter : Character
    {
        #region 컨버터
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        # endregion

        // public Variable
        public UserData userData;
        public Field fieldData;
        public Field FieldData
        {
            set { fieldData = value; mapid = fieldData.mapid; }
        }
        // 변수
        public int index { get; private set; }
        public Dictionary<Item, UserItem> Inventory { get; set; }
        public UserItem[] Equipment { get; set; }
        public Dictionary<Skill, UserSkill> Skills { get; set; }

        public int gold { get; private set; }
        // 스탯 오버라이드
        public int Mystr { get; private set; }
        public int Mydex { get; private set; }
        public int Myint { get; private set; }
        public int Myluk { get; private set; }
        public int Mymaxhp { get; private set; }
        public int Mymaxmp { get; private set; }

        public override int str
        {
            get
            {
                int stat = Mystr;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.str;
                }
                return stat;
            }
            protected set { Mystr = value; }
        }
        public override int dex
        {
            get
            {
                int stat = Mydex;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.dex;
                }
                return stat;
            }
            protected set { Mydex = value; }
        }
        public override int Int
        {
            get
            {
                int stat = Myint;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.Int;
                }
                return stat;
            }
            protected set { Myint = value; }
        }
        public override int luk
        {
            get
            {
                int stat = Myluk;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.luk;
                }
                return stat;
            }
            protected set { Myluk = value; }
        }
        public override int maxhp
        {
            get
            {
                int stat = (level - 1) * 25 + 100;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.hp;
                }
                return stat;
            }
            protected set { Mymaxhp = value; }
        }
        public override int maxmp
        {
            get
            {
                int stat = Mymaxmp;
                foreach (UserItem equip in Equipment)
                {
                    if (equip == null) { continue; }
                    stat += equip.itemData.mp;
                }
                return stat;
            }
            protected set { Mymaxmp = value; }
        }

        //
        public Hashtable variables { get; set; }
        
        // NPC 대화
        public NPC npcData { get; set; }
        public bool isMessage { get; set; }
        public int page { get; set; }
        public int[] action { get; set; }
        public void resetMessage()
        {
            npcData = null;
            isMessage = false;
            page = 0;
            action = null;
            userData.clientData.SendPacket(Packet.EventTrigger());
        }

        // Object
        public UserCharacter(UserData u, int _index)
        {
            userData = u;
            index = _index;
            isMessage = false;
            page = 0;
        }

        // 유저 정보 세팅
        public void loadData(DataRow rs)
        {
            no = ToInt(rs["no"]);
            name = rs["name"].ToString();
            image = rs["image"].ToString();
            level = ToInt(rs["level"]);
            job = ToInt(rs["job"]);
            exp = ToInt(rs["exp"]);
            gold = ToInt(rs["gold"]);
            maxhp = ToInt(rs["maxhp"]);
            maxmp = ToInt(rs["maxmp"]);
            hp = ToInt(rs["hp"]);
            mp = ToInt(rs["mp"]);
            str = ToInt(rs["str"]);
            dex = ToInt(rs["dex"]);
            Int = ToInt(rs["int"]);
            luk = ToInt(rs["luk"]);
            point = ToInt(rs["point"]);


            mapid = ToInt(rs["map_id"]);
            x = ToInt(rs["map_x"]);
            y = ToInt(rs["map_y"]);
            direction = ToInt(rs["direction"]);
            move_speed = ToInt(rs["move_speed"]);
        }
        public void loadItems()
        {
            try
            {
                userData.clientData.SendPacket(Packet.ItemClear());
                // 아이템 저장 공간 정의
                Inventory = new Dictionary<Item, UserItem>();
                Equipment = new UserItem[11];

                // 인벤토리 로드
                DataTable ds = Mysql.Query($"SELECT * FROM user_inventory WHERE char_no = '{no}'");
                int data_no;
                foreach (DataRow rs in ds.Rows)
                {
                    data_no = ToInt(rs["item_no"]);
                    if (ToInt(rs["item_type"]) == 0)
                        Inventory.Add(Item.Equipments[data_no], new UserItem(Item.Equipments[data_no], ToInt(rs["number"])));
                    else
                        Inventory.Add(Item.Items[data_no], new UserItem(Item.Items[data_no], ToInt(rs["number"])));
                }
                // 착용 장비 로드
                ds = Mysql.Query($"SELECT * FROM user_equipment WHERE char_no = '{no}'");
                foreach (DataRow rs in ds.Rows)
                {
                    data_no = ToInt(rs["item_no"]);
                    if (Equipment[Item.Equipments[data_no].equip_type] != null && Item.Equipments[data_no].equip_type == 6)
                        Equipment[10] = new UserItem(Item.Equipments[data_no], 0);
                    else
                        Equipment[Item.Equipments[data_no].equip_type] = new UserItem(Item.Equipments[data_no], 0);      
                }

                foreach (UserItem item in Inventory.Values)
                    userData.clientData.SendPacket(Packet.Item(item, 1));

                foreach (UserItem item in Equipment)
                    if (item != null)
                        userData.clientData.SendPacket(Packet.Item(item, 2));
            }
            catch(Exception e)
            {
                Msg.Error(e.ToString());
            }
        }
        public void loadSkills()
        {
            // 스킬 로드
            Skill skill;
            UserSkill obj;
            Skills = new Dictionary<Skill, UserSkill>();
            DataTable ds = Mysql.Query($"SELECT * FROM user_skill WHERE char_no = '{no}'");
            foreach (DataRow rs in ds.Rows)
            {
                skill = Skill.Skills[ToInt(rs["skill_no"])];
                obj = new UserSkill(skill, rs);
                Skills.Add(skill, obj);
            }
            foreach (UserSkill s in Skills.Values)
                userData.clientData.SendPacket(Packet.LoadSkill(s));
        }

        public void gainItem(Item item, int num = 0)
        {
            if (Inventory.ContainsKey(item))
            {
                Mysql.Query($"UPDATE user_inventory SET number = number + {num} WHERE char_no = '{no}' AND item_no = '{item.no}'");
                Inventory[item].number += num;
                userData.clientData.SendPacket(Packet.Item(Inventory[item]));
            }
            else
            {
                Mysql.Query($"INSERT INTO user_inventory (char_no,item_no,item_type,number) VALUES ('{no}','{item.no}','{item.type}','{num}')");
                Inventory.Add(item, new UserItem(item, num));
                userData.clientData.SendPacket(Packet.Item(Inventory[item], 1));
            }
        }

        public void loseItem(Item item, int num = 0)
        {
            if (Inventory.ContainsKey(item))
            {
                DataTable rs = Mysql.Query($"SELECT * FROM user_inventory WHERE char_no = '{no}' AND item_no = '{item.no}'");
                if (ToInt(rs.Rows[0]["number"]) > num)
                {
                    Mysql.Query($"UPDATE user_inventory SET number = number - {num} WHERE char_no = '{no}' AND item_no = '{item.no}'");
                    Inventory[item].number = ToInt(rs.Rows[0]["number"]) - num;
                    userData.clientData.SendPacket(Packet.Item(Inventory[item]));
                }
                else if (ToInt(rs.Rows[0]["number"]) == num)
                {
                    Mysql.Query($"DELETE FROM user_inventory WHERE char_no = '{no}' AND item_no = '{item.no}'");
                    Inventory.Remove(item);
                    userData.clientData.SendPacket(Packet.ItemClear(3, item.type, item.no));
                }
            }
        }

        public void equipItem(Item item)
        {
            if (item.type != 0)
                return;
            if (!Inventory.ContainsKey(item))
                return;
            removeItem(item, false);
            Mysql.Query($"INSERT INTO user_equipment (char_no,item_no) VALUES ('{no}','{item.no}')");
            loseItem(item);
            UserItem equip = new UserItem(item, 0);
            Equipment[item.equip_type] = equip;
            if (item.hp != 0)
                damage((-item.hp).ToString(), false);
            userData.clientData.SendPacket(Packet.Item(equip, 2));
            userData.clientData.SendPacket(Packet.CharacterStatusUpdate(this));
        }

        public void removeItem(Item item, bool packet=true)
        {
            UserItem equip;
            equip = Equipment[item.equip_type];
            if (equip == null)
                return;
            Equipment[item.equip_type] = null;
            gainItem(equip.itemData);
            Mysql.Query($"DELETE FROM user_equipment WHERE char_no = '{no}' AND item_no = '{equip.itemData.no}'");
            userData.clientData.SendPacket(Packet.ItemClear(4, equip.itemData.type, equip.itemData.no));
            if (packet)
                userData.clientData.SendPacket(Packet.CharacterStatusUpdate(this));
        }

        public void trashItem(Item item, int number)
        {
            if (!Inventory.ContainsKey(item)) { return; }
            if (item.type != 0)
            {
                if (Inventory[item].number < number || number == 0) { return; }
            }
            else if (number != 0)
                return;
                
            loseItem(item, number);
            fieldData.addDropItem(x, y, item, number);
        }

        public void useItem(Item item)
        {
            if (Inventory.ContainsKey(item))
            {
                MethodInfo method = typeof(ItemFunction).GetMethod(item.method_name, BindingFlags.Public | BindingFlags.Static);
                if (method == null) { return; }
                object[] args = { this, item, item.method_arg };
                if ((bool)method.Invoke(null, args))
                    loseItem(item, 1);
            }
        }

        public void learnSkill(Skill skill)
        {
            if (!Skills.ContainsKey(skill))
            {
                // 스킬 안배움
                Mysql.Query($"INSERT INTO user_skill (char_no, skill_no) VALUES ('{no}', '{skill.no}')");
                Skills.Add(skill, new UserSkill(skill));
                userData.clientData.SendPacket(Packet.LoadSkill(Skills[skill]));
                userData.clientData.SendPacket(Packet.Dialog(0, "기술 습득", "성공적으로 기술을 배웠습니다."));
            }
            else
            {
                userData.clientData.SendPacket(Packet.Dialog(0, "기술 습득 오류", "이미 배운 기술입니다."));
            }
        }

        // 레벨 관련
        public void gainExp(int value)
        {
            exp += value;
            while (true)
            {
                if (Exp.getLevel(level) <= exp)
                    levelUp();
                else
                    break;
            }
            userData.clientData.SendPacket(Packet.CharacterStatusUpdate(this));
        }

        // 골드 획득
        public void gainGold(int value)
        {
            gold += value;
            userData.clientData.SendPacket(Packet.CharacterStatusUpdate(this));
        }

        public void loseGold(int value)
        {
            gold -= value;
            userData.clientData.SendPacket(Packet.CharacterStatusUpdate(this));
        }

        private void levelUp(int up_value=1)
        {
            exp -= Exp.getLevel(level);
            level += up_value;
            animation(15);
            damage((-maxhp).ToString(), false);
            userData.clientData.SendPacket(Packet.UserChat("\\C[250,250,50]레벨 업!!"));
        }

        // 유저 정보 저장
        public void saveData()
        {
            string str = "";
            str += $"name='{name}',image='{image}',level='{level}',guild='{guild}',`job`='{job}',`exp`='{exp}',gold='{gold}',maxhp='{Mymaxhp}',maxmp='{Mymaxmp}',hp='{hp}',mp='{mp}',str='{Mystr}',dex='{Mydex}',`int`='{Myint}',luk='{Myluk}',point='{point}',";
            str += $"map_id='{mapid}',map_x='{x}',map_y='{y}',direction='{direction}',move_speed='{move_speed}'";
            Mysql.Query($"UPDATE user_character SET {str} WHERE no = '{no}'");
        }

        // 이동관련 함수
        public void move(int dir)
        {
            if (fieldData.passable(x, y, dir))
            {
                x += (dir == 4 ? -1 : dir == 6 ? 1 : 0);
                y += (dir == 8 ? -1 : dir == 2 ? 1 : 0);
            }
            turn(dir);
            if (!fieldData.portal(this))
                fieldData.AllSendPacket(Packet.Move(this));
        }
        public void moveto(int _x, int _y, int _dir=2)
        {
            x = _x;
            y = _y;
            direction = _dir;
            fieldData.AllSendPacket(Packet.Move(this));
        }
        public void turn(int dir)
        {
            direction = dir;
        }

        // 전투 관련 함수
        public void damage(string dmg, bool critical)
        {
            if (dmg != "Miss")
                hp -= ToInt(dmg);
            if (hp > maxhp)
                hp = maxhp;
            // 죽었다면?
            if (hp <= 0)
            {
                hp = maxhp;
                dmg = (-maxhp).ToString();
                fieldData.leave(no);
                Map.Maps[1].Fields[0].join(this, 11, 9);
                userData.clientData.SendPacket(Packet.UserChat("\\C[250,50,50]당신은 죽었습니다!"));
            }
            fieldData.AllSendPacket(Packet.CharacterDamage(this, dmg, critical));
        }
        public void animation(int id)
        {
            fieldData.AllSendPacket(Packet.CharacterAnimation(this, id));
        }
        public void attack()
        {
            int new_x, new_y;
            bool critical;
            string dmg;
            new_x = x + (direction == 4 ? -1 : direction == 6 ? 1 : 0);
            new_y = y + (direction == 8 ? -1 : direction == 2 ? 1 : 0);
            foreach (Enemy enemy in fieldData.Enemies)
            {
                if (enemy.IsDead) { continue; }
                if (enemy.x == new_x && enemy.y == new_y)
                {
                    critical = Command.rand.Next(1000) < luk;
                    dmg = Damage.atk(this, enemy, critical);
                    enemy.damage(dmg, critical, this);
                    // Animation
                    enemy.animation(7);
                    break;
                }
            }
        }
    }
}

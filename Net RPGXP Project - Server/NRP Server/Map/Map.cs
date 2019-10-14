using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRP_Server
{
    // Map.Maps[id].seed => Real Map Object
    class Map
    {
        #region 컨버터
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        #endregion
        // Static Variables
        public const int MAP_SIZE = 4;
        public static Dictionary<int, Map> Maps = new Dictionary<int, Map>();

        public static void loadData()
        {
            for(int i=1; i<=MAP_SIZE; i++)
                Maps.Add(i, new Map(i));
            Msg.Info($"[맵] {MAP_SIZE}개의 맵 로드 완료.");
        }

        // Public Variables
        public Dictionary<int, Field> Fields = new Dictionary<int, Field>();

        // Property Variable
        public int id { get; private set; }
        public string name { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }
        public int[,] flagData { get; private set; }
        public Dictionary<string, Portal> portalData;
        public Dictionary<int, NPC> npcData;

        public Map(int _id)
        {
            id = _id;
            // 통행설정 셋 로드
            loadPathData();
            // 포탈 데이터 로드
            loadPortalData();
            // NPC 데이터 로드
            loadNPCData();
            // 시드 필드 작성(default = "0")
            Fields.Add(0, new Field(id, 0));
        }

        public bool loadPathData()
        {
            try
            {
                string filePath = $"./MapData/Map{id}.map";
                string fileData = System.IO.File.ReadAllText(filePath);

                string[] readData = fileData.Split(',');
                name = readData[1];
                width = ToInt(readData[2]);
                height = ToInt(readData[3]);

                string[] _flagData = new string[width * height];
                Array.Copy(readData, 4, _flagData, 0, _flagData.Length);

                flagData = new int[width, height];
                for (int i = 0; i < _flagData.Length; i++)
                    flagData[(i % width), (i / width)] = ToInt(_flagData[i]);
            }
            catch(Exception e)
            {
                Msg.Error(e.ToString());
                return false;
            }
            return true;
        }
        public bool loadPortalData()
        {
            try
            {
                int count = 0;
                Portal obj;
                DataTable ds = Mysql.Query($"SELECT * FROM portal WHERE map_id = '{id}'");
                portalData = new Dictionary<string, Portal>();
                foreach (DataRow rs in ds.Rows)
                {
                    obj = new Portal(ToInt(rs["no"]), id, ToInt(rs["x"]), ToInt(rs["y"]), ToInt(rs["move_map_id"]), ToInt(rs["move_x"]), ToInt(rs["move_y"]));
                    portalData.Add($"{obj.x},{obj.y}", obj);
                    count++;
                }
                Msg.Info($"[맵] {id}번 {count} 개의 포탈 로드 완료");
            }
            catch(Exception e)
            {
                Msg.Error(e.ToString());
                return false;
            }
            return true;
        }
        public bool loadNPCData()
        {
            try
            {
                int count = 0;
                NPC obj;
                DataTable ds = Mysql.Query($"SELECT * FROM npc WHERE map_id = '{id}'");
                npcData = new Dictionary<int, NPC>();
                foreach (DataRow rs in ds.Rows)
                {
                    obj = new NPC(rs);
                    npcData.Add(obj.no, obj);
                    count++;
                }
                Msg.Info($"[맵] {id}번 {count} 개의 NPC 로드 완료");
            }
            catch (Exception e)
            {
                Msg.Error(e.ToString());
                return false;
            }
            return true;
        }
        public bool newField(int _seed)
        {
            if (Fields.ContainsKey(_seed))
                return false;
            Fields.Add(_seed, new Field(id, _seed));
            return true;
        }
        public bool removeField(int _seed)
        {
            if (!Fields.ContainsKey(_seed))
                return false;
            Fields.Remove(_seed);
            return true;
        }

        public void update()
        {
            foreach (Field field in Fields.Values)
                field.update();
        }
    }
}

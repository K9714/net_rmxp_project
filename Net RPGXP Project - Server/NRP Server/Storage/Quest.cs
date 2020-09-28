using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace NRP_Server
{
    class Quest
    {
        public static Dictionary<int, Quest> Quests = new Dictionary<int, Quest>();

        public static void loadData()
        {
            int count = 0;
            try
            {
                Quest obj;
                DataTable ds = Mysql.Query("SELECT * FROM storage_quest");

                foreach (DataRow rs in ds.Rows)
                {
                    obj = new Quest(rs);
                    Quests.Add(obj.no, obj);
                    count++;
                }
            }
            catch (MySqlException e)
            {
                Msg.Error(e.ToString());
            }
            Msg.Info("[퀘스트] " + count.ToString() + "개 로드 완료.");
        }

        public int no { get; private set; }
        public string title { get; private set; }
        public int type { get; private set; }
        public string image { get; private set; }
        public string description { get; private set; }
        public int reward_gold { get; private set; }
        public int reward_exp { get; private set; }
        public int reward_item1 { get; private set; }
        public int reward_item2 { get; private set; }
        public int reward_item3 { get; private set; }
        public int count { get; private set; }
        public int count_no { get; private set; }
        public int count_type { get; private set; }
        public int next_no { get; private set; }

        public Quest(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            title = rs["title"].ToString();
            type = Convert.ToInt32(rs["type"]);
            image = rs["image"].ToString();
            description = rs["description"].ToString();
            reward_gold = Convert.ToInt32(rs["reward_gold"]);
            reward_exp = Convert.ToInt32(rs["reward_exp"]);
            reward_item1 = Convert.ToInt32(rs["reward_item1"]);
            reward_item2 = Convert.ToInt32(rs["reward_item2"]);
            reward_item3 = Convert.ToInt32(rs["reward_item3"]);
            count = Convert.ToInt32(rs["count"]);
            count_no = Convert.ToInt32(rs["count_no"]);
            count_type = Convert.ToInt32(rs["count_type"]);
            next_no = Convert.ToInt32(rs["next_no"]);
        }
    }
}

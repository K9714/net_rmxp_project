using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace NRP_Server
{
    class Skill
    {
        public static Dictionary<int, Skill> Skills = new Dictionary<int, Skill>();

        public static void loadData()
        {
            try
            {
                Skill obj;
                DataTable ds = Mysql.Query("SELECT * FROM storage_skill");

                foreach (DataRow rs in ds.Rows)
                {
                    obj = new Skill(rs);
                    Skills.Add(obj.no, obj);
                }
                Msg.Info("[스킬] " + ds.Rows.Count.ToString() + "개 로드 완료.");
            }
            catch (MySqlException e)
            {
                Msg.Error(e.ToString());
            }
        }

        public int no { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public string icon { get; private set; }
        public string function { get; set; }
        public int max_level { get; private set; }
        public int power { get; private set; }
        public int power_factor { get; private set; }
        public int level_power { get; private set; }
        public int cost { get; private set; }
        public int range_type { get; private set; }
        public int range { get; private set; }
        public int count { get; private set; }
        public int delay { get; private set; }
        public int wait_time { get; private set; }
        public int use_animation { get; private set; }
        public int target_animation { get; private set; }

        public Skill(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
            description = rs["description"].ToString();
            icon = rs["icon"].ToString();
            function = rs["function"].ToString();
            max_level = Convert.ToInt32(rs["max_level"]);
            power = Convert.ToInt32(rs["power"]);
            power_factor = Convert.ToInt32(rs["power_factor"]);
            level_power = Convert.ToInt32(rs["level_power"]);
            cost = Convert.ToInt32(rs["cost"]);
            range_type = Convert.ToInt32(rs["range_type"]);
            range = Convert.ToInt32(rs["range"]);
            count = Convert.ToInt32(rs["count"]);
            delay = Convert.ToInt32(rs["delay"]);
            wait_time = Convert.ToInt32(rs["wait_time"]);
            use_animation = Convert.ToInt32(rs["use_animation"]);
            target_animation = Convert.ToInt32(rs["target_animation"]);
        }


        // 스킬 관리 업데이트
        public static Dictionary<int, UserCharacter> userData = new Dictionary<int, UserCharacter>();
        private static Dictionary<int, UserCharacter> c;
        public static void update()
        {
            c = new Dictionary<int, UserCharacter>(userData);
            foreach (UserCharacter u in c.Values)
            {
                int remove = 0;
                foreach (UserSkill s in u.Skills.Values)
                {
                    if (!s.IsActive && s.wait_time <= 0) { continue; }
                    remove++;
                    if (s.wait_time > 0) { s.wait_time--; continue; }
                    s.delay--;
                    if (s.delay <= 0)
                    {
                        object[] args = { u, s };
                        typeof(SkillFunction).GetMethod(s.skillData.function).Invoke(null, args);
                        s.count--;
                        s.delay = s.skillData.delay;
                    }
                    if (s.count == 0)
                    {
                        s.IsActive = false;
                        s.wait_time = s.skillData.wait_time;
                        u.userData.clientData.SendPacket(Packet.SkillTime(s));
                    }
                }
                if (remove == 0) { userData.Remove(u.no); }
            }
            Thread.Sleep(Config.WAIT_TIME);
        }
    }
}

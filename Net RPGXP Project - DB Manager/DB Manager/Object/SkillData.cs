using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Manager
{
    class SkillData
    {
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

        public SkillData(DataRow rs)
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
    }
}

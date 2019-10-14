using System;
using System.Collections.Generic;
using System.Data;

namespace DB_Manager
{
    public class NPC
    {
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        public int no { get; private set; }
        public string name { get; private set; }
        public string image { get; private set; }
        public int id { get; private set; }
        public int mapid { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }
        public int direction { get; private set; }
        public int pattern { get; private set; }
        public int move_speed { get; private set; }
        public int default_action { get; private set; }

        public NPC(DataRow rs)
        {
            no = ToInt(rs["no"]);
            name = rs["name"].ToString();
            image = rs["image"].ToString();
            id = ToInt(rs["id"]);
            mapid = ToInt(rs["map_id"]);
            x = ToInt(rs["map_x"]);
            y = ToInt(rs["map_y"]);
            direction = ToInt(rs["direction"]);
            pattern = ToInt(rs["pattern"]);
            move_speed = ToInt(rs["move_speed"]);
            default_action = ToInt(rs["default_action"]);
        }
    }
}

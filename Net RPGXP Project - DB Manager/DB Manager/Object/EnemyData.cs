using System;
using System.Collections;
using System.Data;

namespace DB_Manager
{
    public class EnemyData
    {
        public int no { get; private set; }
        public string name { get; private set; }
        public string image { get; private set; }
        public int exp { get; private set; }
        public int level { get; private set; }
        public int maxhp { get; private set; }
        public int maxmp { get; private set; }
        public int str { get; private set; }
        public int dex { get; private set; }
        public int Int { get; private set; }
        public int luk { get; private set; }
        public int direction { get; private set; }
        public int move_speed { get; private set; }
        public int pattern { get; private set; }
        public int delay { get; private set; }
        public int rebirth_time { get; private set; }
        public int sight { get; private set; }
        public int animation_id { get; private set; }

        public ArrayList dropData;
        public ArrayList posData;

        public EnemyData(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
            image = rs["image"].ToString();
            exp = Convert.ToInt32(rs["exp"]);
            level = Convert.ToInt32(rs["level"]);
            maxhp = Convert.ToInt32(rs["maxhp"]);
            maxmp = Convert.ToInt32(rs["maxmp"]);
            str = Convert.ToInt32(rs["str"]);
            dex = Convert.ToInt32(rs["dex"]);
            Int = Convert.ToInt32(rs["int"]);
            luk = Convert.ToInt32(rs["luk"]);
            direction = Convert.ToInt32(rs["direction"]);
            move_speed = Convert.ToInt32(rs["move_speed"]);
            pattern = Convert.ToInt32(rs["pattern"]);
            delay = Convert.ToInt32(rs["delay"]);
            rebirth_time = Convert.ToInt32(rs["rebirth_time"]);
            sight = Convert.ToInt32(rs["sight"]);
            animation_id = Convert.ToInt32(rs["animation_id"]);
        }

        public void loadDropItem()
        {
            dropData = new ArrayList();
            try
            {
                EnemyDropItem obj;
                DataTable ds = Mysql.Query($"SELECT * FROM enemy_dropitem WHERE enemy_no = '{no}'");
                foreach (DataRow rs in ds.Rows)
                {
                    obj = new EnemyDropItem(rs);
                    dropData.Add(obj);
                }
            }
            catch (Exception e)
            {
                Console.warning(e.ToString());
            }

        }
        public void loadPosition()
        {
            posData = new ArrayList();
            try
            {
                EnemyPosition obj;
                DataTable ds = Mysql.Query($"SELECT * FROM enemy_position WHERE enemy_no = '{no}'");
                foreach (DataRow rs in ds.Rows)
                {
                    obj = new EnemyPosition(rs);
                    posData.Add(obj);
                }
            }
            catch (Exception e)
            {
                Console.warning(e.ToString());
            }
        }
    }

    public class EnemyDropItem
    {
        public int no { get; private set; }
        public int enemy_no { get; private set; }
        public int item_no { get; private set; }
        public int rate { get; private set; }
        public string image { get; private set; }
        public int pattern_x { get; private set; }
        public int pattern_y { get; private set; }
        public int min_price { get; private set; }
        public int min_str { get; private set; }
        public int min_dex { get; private set; }
        public int min_int { get; private set; }
        public int min_luk { get; private set; }
        public int min_solid { get; private set; }
        public int min_hp { get; private set; }
        public int min_mp { get; private set; }
        public int min_ability { get; private set; }
        public int min_cost { get; private set; }
        public int max_price { get; private set; }
        public int max_str { get; private set; }
        public int max_dex { get; private set; }
        public int max_int { get; private set; }
        public int max_luk { get; private set; }
        public int max_solid { get; private set; }
        public int max_hp { get; private set; }
        public int max_mp { get; private set; }
        public int max_ability { get; private set; }
        public int max_cost { get; private set; }
        public bool trade { get; private set; }
        public bool sell { get; private set; }
        public bool use { get; private set; }

        public EnemyDropItem(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            enemy_no = Convert.ToInt32(rs["enemy_no"]);
            item_no = Convert.ToInt32(rs["item_no"]);
            rate = Convert.ToInt32(rs["rate"]);
            image = rs["image"].ToString();
            pattern_x = Convert.ToInt32(rs["pattern_x"]);
            pattern_y = Convert.ToInt32(rs["pattern_y"]);
            min_price = Convert.ToInt32(rs["min_price"]);
            min_str = Convert.ToInt32(rs["min_str"]);
            min_dex = Convert.ToInt32(rs["min_dex"]);
            min_int = Convert.ToInt32(rs["min_int"]);
            min_luk = Convert.ToInt32(rs["min_luk"]);
            min_solid = Convert.ToInt32(rs["min_solid"]);
            min_hp = Convert.ToInt32(rs["min_hp"]);
            min_mp = Convert.ToInt32(rs["min_mp"]);
            min_ability = Convert.ToInt32(rs["min_ability"]);
            min_cost = Convert.ToInt32(rs["min_cost"]);
            max_price = Convert.ToInt32(rs["max_price"]);
            max_str = Convert.ToInt32(rs["max_str"]);
            max_dex = Convert.ToInt32(rs["max_dex"]);
            max_int = Convert.ToInt32(rs["max_int"]);
            max_luk = Convert.ToInt32(rs["max_luk"]);
            max_solid = Convert.ToInt32(rs["max_solid"]);
            max_hp = Convert.ToInt32(rs["max_hp"]);
            max_mp = Convert.ToInt32(rs["max_mp"]);
            max_ability = Convert.ToInt32(rs["max_ability"]);
            max_cost = Convert.ToInt32(rs["max_cost"]);
            trade = Convert.ToInt32(rs["trade"]) == 1 ? true : false;
            sell = Convert.ToInt32(rs["sell"]) == 1 ? true : false;
            use = Convert.ToInt32(rs["use"]) == 1 ? true : false;
        }
    }

    public class EnemyPosition
    {
        public int no { get; private set; }
        public int enemy_no { get; private set; }
        public int mapid { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public EnemyPosition(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            enemy_no = Convert.ToInt32(rs["enemy_no"]);
            mapid = Convert.ToInt32(rs["map_id"]);
            x = Convert.ToInt32(rs["map_x"]);
            y = Convert.ToInt32(rs["map_y"]);
        }
    }
}

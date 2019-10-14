using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Manager
{
    public class ItemData
    {
        public int no { get; private set; }
        public string name { get; private set; }
        public string icon { get; private set; }
        public string description { get; private set; }
        public int type { get; private set; }
        public int equip { get; private set; }
        public int price { get; private set; }
        public int str { get; private set; }
        public int dex { get; private set; }
        public int Int { get; private set; }
        public int luk { get; private set; }
        public int hp { get; private set; }
        public int mp { get; private set; }
        public int solid { get; private set; }
        public int max_ability { get; private set; }
        public int ability { get; private set; }
        public int lv_cost { get; private set; }
        public int rank { get; private set; }
        public bool trade { get; private set; }
        public bool sell { get; private set; }
        public bool use { get; private set; }
        public string method_name { get; private set; }
        public int method_arg { get; private set; }
        public int animation_id { get; private set; }

        public ItemData(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
            icon = rs["icon"].ToString();
            description = rs["description"].ToString();
            type = Convert.ToInt32(rs["type"]);
            equip = Convert.ToInt32(rs["equip_type"]);
            price = Convert.ToInt32(rs["price"]);
            str = Convert.ToInt32(rs["str"]);
            dex = Convert.ToInt32(rs["dex"]);
            Int = Convert.ToInt32(rs["int"]);
            luk = Convert.ToInt32(rs["luk"]);
            hp = Convert.ToInt32(rs["hp"]);
            mp = Convert.ToInt32(rs["mp"]);
            solid = Convert.ToInt32(rs["solid"]);
            max_ability = Convert.ToInt32(rs["max_ability"]);
            ability = Convert.ToInt32(rs["ability"]);
            lv_cost = Convert.ToInt32(rs["lv_cost"]);
            rank = Convert.ToInt32(rs["rank"]);
            trade = Convert.ToInt32(rs["trade"]) == 1 ? true : false;
            sell = Convert.ToInt32(rs["sell"]) == 1 ? true : false;
            use = Convert.ToInt32(rs["use"]) == 1 ? true : false;
            method_name = rs["method_name"].ToString();
            method_arg = Convert.ToInt32(rs["method_arg"]);
            animation_id = Convert.ToInt32(rs["animation_id"]);
        }

    }
}

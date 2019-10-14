using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace NRP_Server
{
    class Item
    {
        public static Dictionary<int, Item> Items = new Dictionary<int, Item>();
        public static Dictionary<int, Item> Equipments = new Dictionary<int, Item>();

        public static void loadData()
        {
            int count = 0;
            int err_count = 0;
            try
            {
                Item obj;
                DataTable ds = Mysql.Query("SELECT * FROM storage_item");

                foreach (DataRow rs in ds.Rows)
                {
                    obj = new Item(rs);
                    Items.Add(obj.no, obj);
                    count++;
                }

                ds = Mysql.Query("SELECT * FROM storage_equipment");
                foreach (DataRow rs in ds.Rows)
                {
                    if (Items.ContainsKey(Convert.ToInt32(rs["item_no"])))
                    {
                        obj = new Item(rs, Items[Convert.ToInt32(rs["item_no"])]);
                        Equipments.Add(obj.no, obj);
                        count++;
                    }
                    else
                    {
                        Msg.Error("[아이템] storage_equipment no = '" + rs["no"].ToString() + "', item_no = '" + rs["item_no"].ToString() +"' 잘못된 item_no 정보.");
                        err_count++;
                    }
                }
            }
            catch (MySqlException e)
            {
                Msg.Error(e.ToString());
            }
            Msg.Info("[아이템] " + count.ToString() + "개 로드 완료.");
            if (err_count > 0)
                Msg.Error("[아이템] " + err_count.ToString() + "개의 없는 아이템 저장 정보 확인됨.");

        }

        public int no { get; private set; }
        public string name { get; private set; }
        public int type { get; private set; }
        public int equip_type { get; private set; }
        public string icon { get; set; }
        public string description { get; private set; }
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

        public Item(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
            type = Convert.ToInt32(rs["type"]);
            equip_type = Convert.ToInt32(rs["equip_type"]);
            icon = rs["icon"].ToString();
            description = rs["description"].ToString();
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

        public Item(DataRow rs, Item item)
        {
            no = Convert.ToInt32(rs["no"]);
            name = item.name;
            type = item.type;
            equip_type = item.equip_type;
            icon = item.icon;
            description = item.description;
            price = item.price + Convert.ToInt32(rs["price"]);
            str = item.str + Convert.ToInt32(rs["str"]);
            dex = item.dex + Convert.ToInt32(rs["dex"]);
            Int = item.Int + Convert.ToInt32(rs["int"]);
            luk = item.luk + Convert.ToInt32(rs["luk"]);
            hp = item.hp + Convert.ToInt32(rs["hp"]);
            mp = item.mp + Convert.ToInt32(rs["mp"]);
            solid = item.solid + Convert.ToInt32(rs["solid"]);
            max_ability = Convert.ToInt32(rs["max_ability"]);
            ability = Convert.ToInt32(rs["ability"]);
            lv_cost = item.lv_cost + Convert.ToInt32(rs["lv_cost"]);
            rank = item.rank;
            trade = Convert.ToInt32(rs["trade"]) == 1 ? true : false;
            sell = Convert.ToInt32(rs["sell"]) == 1 ? true : false;
            use = Convert.ToInt32(rs["use"]) == 1 ? true : false;
            method_name = item.method_name;
            method_arg = item.method_arg;
            animation_id = item.animation_id;
        }
    }
}

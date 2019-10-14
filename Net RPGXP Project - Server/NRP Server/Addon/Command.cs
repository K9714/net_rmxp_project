using System;
using System.Data;
using System.Text.RegularExpressions;

namespace NRP_Server
{
    class Command
    {
        public Regex formula;

        public Command(string _cmd)
        {
            formula = new Regex(_cmd);
        }

        public bool isMatch(string str) { return formula.IsMatch(str); }
        public string[] MatchData(string str)
        {
            string[] data;
            MatchCollection mc = formula.Matches(str);

            data = new string[mc[0].Groups.Count];

            for (int i = 0; i < data.Length; i++)
                data[i] = mc[0].Groups[i].ToString();

            return data;
        }

        // Static
        public static Random rand = new Random((int)DateTime.Now.Ticks);
        public static void gainItem(UserCharacter u, int item_no, int num)
        {
            Item item = Item.Items[item_no];
            if (item.type == 0)
            {
                string field, values;
                field = "item_no,max_ability,ability,trade,sell,`use`,`character`";
                values = $"'{item.no}','{item.max_ability}','{item.ability}',";
                values += $"'{(item.trade ? 1 : 0)}','{(item.sell ? 1 : 0)}','{(item.use ? 1 : 0)}','{u.name}'";
                DataTable rs;
                Item obj;
                for (int i = 0; i < num; i++)
                {
                    Mysql.Query($"INSERT INTO storage_equipment ({field}) VALUES ({values})");

                    rs = Mysql.Query($"SELECT * FROM storage_equipment WHERE `character` = '{u.name}'");
                    Mysql.Query($"UPDATE storage_equipment SET `character` = '' WHERE no = '{rs.Rows[0]["no"]}'");
                    obj = new Item(rs.Rows[0], item);
                    Item.Equipments.Add(obj.no, obj);

                    u.gainItem(obj, 0);
                }
            }
            else
            {
                u.gainItem(item, num);
            }
        }

        public static void gainItem(UserCharacter u, DropItem dropitem)
        {
            Item item;
            Item obj;
            if (dropitem.trash && dropitem.dropData.item_type == 0)
                item = Item.Equipments[dropitem.dropData.item_no];
            else
                item = Item.Items[dropitem.dropData.item_no];
            if (item.type == 0)
            {
                if (!dropitem.trash)
                {
                    DataTable rs;
                    Mysql.Query($"INSERT INTO storage_equipment ({dropitem.field}) VALUES ({dropitem.values})");

                    // 아이템 재 로드하여 no 번호 추출 및 캐릭터, 변수 업데이트
                    rs = Mysql.Query($"SELECT * FROM storage_equipment WHERE `character` = '{u.name}'");
                    Mysql.Query($"UPDATE storage_equipment SET `character` = '' WHERE no = '{rs.Rows[0]["no"]}'");

                    obj = new Item(rs.Rows[0], item);
                    Item.Equipments.Add(obj.no, obj);

                    // 실제 인벤토리에 추가
                    u.gainItem(obj, 0);
                }
                else
                {
                    obj = Item.Equipments[dropitem.dropData.item_no];
                    u.gainItem(obj, 0);        
                }
            }
            else
            {
                if (!dropitem.trash)
                    u.gainItem(item, 1);
                else
                {
                    obj = Item.Items[dropitem.dropData.item_no];
                    u.gainItem(obj, dropitem.number);
                }
            }
            
        }
    }
}

using System;
using System.Collections;
using System.Data;

namespace DB_Manager
{
    public class StoreData
    {
        public int no { get; private set; }
        public string name { get; private set; }

        public ArrayList itemData;

        public StoreData(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
        }

        public void loadItems()
        {
            itemData = new ArrayList();
            try
            {
                StoreItem obj;
                DataTable ds = Mysql.Query($"SELECT * FROM store_item WHERE store_no = '{no}'");
                foreach (DataRow rs in ds.Rows)
                {
                    obj = new StoreItem(rs);
                    itemData.Add(obj);
                }
            }
            catch (Exception e)
            {
                Console.warning(e.ToString());
            }
        }
    }

    public class StoreItem
    {
        public int no { get; private set; }
        public int store_no { get; private set; }
        public int item_no { get; private set; }
        public int price { get; private set; }
        public int number { get; private set; }
        public int discount { get; private set; }

        public StoreItem(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            store_no = Convert.ToInt32(rs["store_no"]);
            item_no = Convert.ToInt32(rs["item_no"]);
            price = Convert.ToInt32(rs["price"]);
            number = Convert.ToInt32(rs["number"]);
            discount = Convert.ToInt32(rs["discount"]);
        }
    }
}
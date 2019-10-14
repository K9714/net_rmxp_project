using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace NRP_Server
{
    class Store
    {
        public static Dictionary<int, Store> List = new Dictionary<int, Store>();
        public static void loadData()
        {
            int count = 0;
            try
            {
                Store obj;
                DataTable ds = Mysql.Query("SELECT * FROM store");

                foreach (DataRow rs in ds.Rows)
                {
                    obj = new Store(rs);
                    List.Add(obj.no, obj);
                    count++;
                }
            }
            catch (MySqlException e)
            {
                Msg.Error(e.ToString());
            }
            Msg.Info("[상점] " + count.ToString() + "개 로드 완료.");
        }

        public static void Show(UserCharacter u, int no)
        {
            Store storeData = List[no];
            foreach (StoreItem item in storeData.Items.Values)
                u.userData.clientData.SendPacket(Packet.StoreItem(storeData, item));
        }

        public static void Buy(UserCharacter u, int store_no, int item_no, int number)
        {
            if (List.ContainsKey(store_no))
            {
                Store storeData = List[store_no];
                if (number <= 0) { u.userData.clientData.SendPacket(Packet.Dialog(0, "구매 불가", "구매 개수를 정확히 입력해주세요.")); return; }
                if (storeData.Items[item_no].number >= number || storeData.Items[item_no].number == -1)
                {
                    int gold = storeData.Items[item_no].price * number;
                    if (u.gold >= gold)
                    {
                        if (storeData.Items[item_no].number != -1)
                            storeData.Items[item_no].number -= number;
                        u.loseGold(gold);
                        Command.gainItem(u, storeData.Items[item_no].item_no, number);
                        u.userData.clientData.SendPacket(Packet.StoreItem(storeData, storeData.Items[item_no]));
                        u.userData.clientData.SendPacket(Packet.Dialog(0, "구매 완료", $"{Item.Items[storeData.Items[item_no].item_no].name} 아이템을 {number}개 구매했습니다."));
                    }
                    else
                        u.userData.clientData.SendPacket(Packet.Dialog(0, "구매 불가", "보유 금액이 부족합니다."));
                }
                else
                    u.userData.clientData.SendPacket(Packet.Dialog(0, "구매 불가", "상점의 아이템 개수가 부족합니다."));
            }
        }

        public static void Sell(UserCharacter u, Item item, int number)
        {
            if (item.type != 0 && number == 0) { u.userData.clientData.SendPacket(Packet.Dialog(0, "판매 불가", "판매 개수를 정확히 입력해주세요.")); return; }

            if (u.Inventory[item].number >= number)
            {
                int gold = number == 0 ? item.price : item.price * number;
                u.gainGold(gold);
                u.loseItem(item, number);
                u.userData.clientData.SendPacket(Packet.Dialog(0, "판매 완료", $"아이템을 {gold}골드에 판매하였습니다."));
                if (item.type == 0)
                {
                    Mysql.Query($"DELETE FROM storage_equipment WHERE no = '{item.no}'");
                    Item.Equipments.Remove(item.no);
                }

            }
            else
            {
                u.userData.clientData.SendPacket(Packet.Dialog(0, "판매 불가", "아이템의 개수를 확인해주세요."));
            }
        }

        public int no { get; private set; }
        public string name { get; private set; }
        public Dictionary<int, StoreItem> Items;

        private Store(DataRow rs)
        {
            no = Convert.ToInt32(rs["no"]);
            name = rs["name"].ToString();
            loadItemData();
        }

        public void loadItemData()
        {
            Items = new Dictionary<int, StoreItem>();
            StoreItem obj;
            DataTable ds = Mysql.Query($"SELECT * FROM store_item WHERE store_no = '{no}'");
            foreach (DataRow rs in ds.Rows)
            {
                obj = new StoreItem(rs);
                Items.Add(obj.no, obj);
            }
        }
    }

    class StoreItem
    {
        public int no { get; private set; }
        public int store_no { get; private set; }
        public int item_no { get; private set; }
        public int price { get; private set; }
        public int number { get; set; }
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

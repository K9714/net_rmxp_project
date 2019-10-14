using System;
using System.Data;

namespace NRP_Server
{
    class DropItem : Character
    {
        public int pattern { get; private set; }
        public EnemyDropData dropData { get; private set; }
        public string field { get; private set; }
        public string values { get; private set; }
        public bool trash { get; private set; }
        public int number { get; private set; }
        public DropItem(int index, int _x, int _y, EnemyDropData data)
        {
            no = index;
            x = _x;
            y = _y;
            dropData = data;
            image = dropData.image;
            name = Item.Items[dropData.item_no].name;
            pattern = dropData.pattern_x;
            direction = (dropData.pattern_y + 1) * 2;
            trash = false;
            values = "";
            setData();
        }

        public DropItem(int index, int _x, int _y, Item _item, int _num=1)
        {
            no = index;
            x = _x;
            y = _y;
            number = _num;
            dropData = new EnemyDropData(_item.no, _item.type, "193-Support01.png", 0, 2);
            image = dropData.image;
            name = _item.name;
            pattern = dropData.pattern_x;
            direction = (dropData.pattern_y + 1) * 2;
            values = "";
            trash = true;
        }

        private void setData()
        {
            Item item = Item.Items[dropData.item_no];
            if (item.type == 0)
            {
                int ability = Command.rand.Next(dropData.min_ability, dropData.max_ability + 1);
                field = "item_no, price, str, dex, `int` ,luk, hp, mp, solid, max_ability, ability, lv_cost,";
                values = $"'{item.no}',";
                values += $"'{Command.rand.Next(dropData.min_price, dropData.max_price + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_str, dropData.max_str + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_dex, dropData.max_dex + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_int, dropData.max_int + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_luk, dropData.max_luk + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_hp, dropData.max_hp + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_mp, dropData.max_mp + 1)}',";
                values += $"'{Command.rand.Next(dropData.min_solid, dropData.max_solid + 1)}',";
                values += $"'{ability}','{ability}',";
                values += $"'{Command.rand.Next(dropData.min_cost, dropData.max_cost + 1)}',";
                field += "trade, sell, `use`, `character`";
                values += $"'{(item.trade ? 1 : 0)}','{(item.sell ? 1 : 0)}','{(item.use ? 1 : 0)}',";
            }
        }

        public void gain(UserCharacter u)
        {
            values += $"'{u.name}'";
            Command.gainItem(u, this);
            u.userData.clientData.SendPacket(Packet.EventTrigger());
        }
    }
}

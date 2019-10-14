using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NRP_Server
{
    class UserItem
    {
        public int number { get; set; }
        public Item itemData { get; set; }

        public UserItem(Item item, int _number)
        {
            itemData = item;
            number = _number;
        }
    }
}

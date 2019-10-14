using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Manager
{
    public partial class addDropItemForm : Form
    {
        public bool modification { get; private set; }
        public ItemData itemData { get; private set; }
        public EnemyDropItem itemDropData { get; private set; }
        public EnemyData enemy { get; private set; }
        public mainForm main_form;
        public addDropItemForm(mainForm _mainForm, EnemyData _enemy, EnemyDropItem _item = null)
        {
            main_form = _mainForm;
            InitializeComponent();
            modification = false;
            enemy = _enemy;
            loadData();
            if (_item != null)
                modificationData(_item);
        }

        private void loadData()
        {
            if (main_form.itemListData != null)
            {
                itemlist_box.Items.Clear();
                foreach (ItemData data in main_form.itemListData)
                {
                    itemlist_box.Items.Add(data.name);
                }
                trade_box.Text = trade_box.Items[1].ToString();
                sell_box.Text = sell_box.Items[1].ToString();
                use_box.Text = use_box.Items[1].ToString();
            }
        }

        private void modificationData(EnemyDropItem item)
        {
            itemlist_box.Enabled = false;
            
            itemDropData = item;
            itemData = main_form.getItemData(item.item_no);
            modification = true;
            add_button.Text = "수정";

            itemlist_box.Text = itemData.name;
            rate_numbox.Value = item.rate;
            image_textbox.Text = item.image;

            pattern_x_numbox.Value = item.pattern_x;
            pattern_y_numbox.Value = item.pattern_y;

            min_price_numbox.Value = item.min_price;
            min_str_numbox.Value = item.min_str;
            min_dex_numbox.Value = item.min_dex;
            min_int_numbox.Value = item.min_int;
            min_luk_numbox.Value = item.min_luk;
            min_solid_numbox.Value = item.min_solid;
            min_hp_numbox.Value = item.min_hp;
            min_mp_numbox.Value = item.min_mp;
            min_ability_numbox.Value = item.min_ability;
            min_cost_numbox.Value = item.min_cost;
            //------------------------------------------
            max_price_numbox.Value = item.max_price;
            max_str_numbox.Value = item.max_str;
            max_dex_numbox.Value = item.max_dex;
            max_int_numbox.Value = item.max_int;
            max_luk_numbox.Value = item.max_luk;
            max_solid_numbox.Value = item.max_solid;
            max_hp_numbox.Value = item.max_hp;
            max_mp_numbox.Value = item.max_mp;
            max_ability_numbox.Value = item.max_ability;
            max_cost_numbox.Value = item.max_cost;

            trade_box.Text = trade_box.Items[item.trade ? 1 : 0].ToString();
            sell_box.Text = sell_box.Items[item.sell ? 1 : 0].ToString();
            use_box.Text = use_box.Items[item.use ? 1 : 0].ToString();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void itemlist_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable;
            itemData = main_form.getItemDataIndex(itemlist_box.SelectedIndex);

            enable = itemData.type == 0 ? true : false;

            min_price_numbox.Enabled = enable;
            min_str_numbox.Enabled = enable;
            min_dex_numbox.Enabled = enable;
            min_int_numbox.Enabled = enable;
            min_luk_numbox.Enabled = enable;
            min_solid_numbox.Enabled = enable;
            min_ability_numbox.Enabled = enable;
            min_hp_numbox.Enabled = enable;
            min_mp_numbox.Enabled = enable;
            min_cost_numbox.Enabled = enable;

            max_price_numbox.Enabled = enable;
            max_str_numbox.Enabled = enable;
            max_dex_numbox.Enabled = enable;
            max_int_numbox.Enabled = enable;
            max_luk_numbox.Enabled = enable;
            max_solid_numbox.Enabled = enable;
            max_ability_numbox.Enabled = enable;
            max_hp_numbox.Enabled = enable;
            max_mp_numbox.Enabled = enable;
            max_cost_numbox.Enabled = enable;

            trade_box.Enabled = enable;
            sell_box.Enabled = enable;
            use_box.Enabled = enable;
        }

        // 추가 / 수정
        private void add_button_Click(object sender, EventArgs e)
        {
            if (modification)
            {
                string str = "";
                str += $"item_no='{itemData.no}',rate='{rate_numbox.Value}',image='{image_textbox.Text}',pattern_x='{pattern_x_numbox.Value}',pattern_y='{pattern_y_numbox.Value}',";
                str += $"min_price='{min_price_numbox.Value}',min_str='{min_str_numbox.Value}',min_dex='{min_dex_numbox.Value}',min_int='{min_int_numbox.Value}',min_luk='{min_luk_numbox.Value}',min_solid='{min_solid_numbox.Value}',";
                str += $"min_hp='{min_hp_numbox.Value}',min_mp='{min_mp_numbox.Value}',min_ability='{min_ability_numbox.Value}',min_cost='{min_cost_numbox.Value}',";
                str += $"max_price='{max_price_numbox.Value}',max_str='{max_str_numbox.Value}',max_dex='{max_dex_numbox.Value}',max_int='{max_int_numbox.Value}',max_luk='{max_luk_numbox.Value}',max_solid='{max_solid_numbox.Value}',";
                str += $"max_hp='{max_hp_numbox.Value}',max_mp='{max_mp_numbox.Value}',max_ability='{max_ability_numbox.Value}',max_cost='{max_cost_numbox.Value}',";
                str += $"trade='{trade_box.SelectedIndex}',sell='{sell_box.SelectedIndex}',`use`='{use_box.SelectedIndex}'";

                Mysql.Query($"UPDATE enemy_dropitem SET {str} WHERE no = '{itemDropData.no}'");
                Console.info($"성공적으로 데이터를 수정했습니다. (몬스터 드랍아이템 : {itemData.name})");
            }
            else
            {
                string fields = "";
                string values = "";
                fields += "enemy_no,item_no,rate,image,pattern_x,pattern_y,";
                fields += "min_price,min_str,min_dex,min_int,min_luk,min_hp,min_mp,min_solid,min_ability,min_cost,";
                fields += "max_price,max_str,max_dex,max_int,max_luk,max_hp,max_mp,max_solid,max_ability,max_cost,";
                fields += "trade,sell,`use`";
                values += $"'{enemy.no}','{itemData.no}','{rate_numbox.Value}','{image_textbox.Text}','{pattern_x_numbox.Value}','{pattern_y_numbox.Value}',";
                values += $"'{min_price_numbox.Value}','{min_str_numbox.Value}','{min_dex_numbox.Value}','{min_int_numbox.Value}','{min_luk_numbox.Value}','{min_solid_numbox.Value}',";
                values += $"'{min_hp_numbox.Value}','{min_mp_numbox.Value}','{min_ability_numbox.Value}','{min_cost_numbox.Value}',";
                values += $"'{max_price_numbox.Value}','{max_str_numbox.Value}','{max_dex_numbox.Value}','{max_int_numbox.Value}','{max_luk_numbox.Value}','{max_solid_numbox.Value}',";
                values += $"'{max_hp_numbox.Value}','{max_mp_numbox.Value}','{max_ability_numbox.Value}','{max_cost_numbox.Value}',";
                values += $"'{trade_box.SelectedIndex}','{sell_box.SelectedIndex}','{use_box.SelectedIndex}'";

                Mysql.Query($"INSERT INTO enemy_dropitem ({fields}) VALUES ({values})");
                Console.info($"성공적으로 데이터를 추가했습니다. (몬스터 드랍아이템 : {itemData.name})");
            }
            main_form.enemy_drop_item_load(enemy);
            Close();
        }
    }
}

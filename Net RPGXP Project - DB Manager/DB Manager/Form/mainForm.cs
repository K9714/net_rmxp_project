using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Manager
{
    public partial class mainForm : Form
    {
        private static int ToInt(object data)
        {
            return Convert.ToInt32(data);
        }
        // 구분자 int로 바꿀 것
        public ArrayList npcListData;
        public ArrayList itemListData;
        public ArrayList storeListData;
        public ArrayList enemyListData;
        public ArrayList skillListData;
        public NPCData npcData;
        public Form stopData;

        // 메인
        public mainForm()
        {
            InitializeComponent();
            Console.setup(consoleBox);
            path_textbox.Click += new EventHandler(path_textbox_click_event);
        }


        public void path_textbox_click_event(object sender, EventArgs e)
        {
            // 보류.
        }

        public ItemData getItemData(int no)
        {
            foreach(ItemData obj in itemListData)
                if (obj.no == no) { return obj; }

            return null;
        }
        public ItemData getItemDataIndex(int index)
        {
            if (itemListData[index] != null)
                return itemListData[index] as ItemData;
            return null;
        }

        #region 툴팁 컨트롤
        private void dBManager정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, $"Net RMXP Project DB Manager\n버전 {Config.VERSION}\n\nKnsoF(optikingsun@naver.com)\nAll rights reserved.", "DB Manager 정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
        #region MySQL 연결/연결해제 및 데이터 세팅
        // 연결
        private void connect_button_Click(object sender, EventArgs e)
        {
            try
            {
                string ip, db, uid, pw;
                ip = ip_textbox.Text;
                db = dbname_textbox.Text;
                uid = user_textbox.Text;
                pw = pw_textbox.Text;
                pw_textbox.Text = "";
                Mysql.connect(ip, db, uid, pw);
                Console.info("DB 연결 완료.");
                disconnect_button.Enabled = true;
                connect_button.Enabled = false;
                loadData();
            }
            catch (Exception err)
            {
                Console.warning(err.ToString());
            }
        }
        // 연결 해제
        private void disconnect_button_Click(object sender, EventArgs e)
        {
            try
            {
                Mysql.disconnect();
                Console.info("DB 연결 해제.");
                connect_button.Enabled = true;
                disconnect_button.Enabled = false;
            }
            catch (Exception err)
            {
                Console.warning(err.ToString());
            }
        }

        public void loadData()
        {
            if (Mysql.ping())
            {
                // NPC 데이터 로드
                object obj;
                npcListData = new ArrayList();
                DataTable rs = Mysql.Query("SELECT * From npc");
                npc_listbox.Items.Clear();
                foreach (DataRow data in rs.Rows)
                {
                    obj = new NPC(data);
                    npcListData.Add(obj);
                    npc_listbox.Items.Add((obj as NPC).name);
                }
                // 아이템 로드
                ListViewItem list;
                ListViewItem.ListViewSubItem item;
                itemListData = new ArrayList();
                item_listview.Items.Clear();
                rs = Mysql.Query("SELECT * FROM storage_item");
                foreach (DataRow data in rs.Rows)
                {
                    obj = new ItemData(data);
                    list = new ListViewItem();
                    list.Text = (obj as ItemData).name;
                    item = new ListViewItem.ListViewSubItem();
                    item.Text = item_type_box.Items[(obj as ItemData).type].ToString();
                    list.SubItems.Add(item);
                    item_listview.Items.Add(list);
                    itemListData.Add((obj as ItemData));
                }
                // 상점 로드
                storeListData = new ArrayList();
                store_listbox.Items.Clear();
                rs = Mysql.Query("SELECT * FROM store");
                foreach (DataRow data in rs.Rows)
                {
                    obj = new StoreData(data);
                    storeListData.Add(obj);
                    store_listbox.Items.Add((obj as StoreData).name);
                }
                // 몬스터 로드
                enemyListData = new ArrayList();
                enemy_listbox.Items.Clear();
                rs = Mysql.Query("SELECT * From enemy");
                foreach (DataRow data in rs.Rows)
                {
                    obj = new EnemyData(data);
                    enemyListData.Add(obj);
                    enemy_listbox.Items.Add((obj as EnemyData).name);
                }
                // 스킬 로드
                skillListData = new ArrayList();
                skill_listbox.Items.Clear();
                rs = Mysql.Query("SELECT * FROM storage_skill");
                foreach (DataRow data in rs.Rows)
                {
                    obj = new SkillData(data);
                    skillListData.Add(obj);
                    skill_listbox.Items.Add((obj as SkillData).name);
                }
            }
            else
                MessageBoxEx.Show(this, "DB와 연결되어있지 않습니다.");
        }
        #endregion

        #region NPC 탭 컨트롤
    
        // 리스트박스 선택
        private void npc_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (npc_listbox.SelectedIndex != -1)
                {
                    NPC npc = npcListData[npc_listbox.SelectedIndex] as NPC;
                    // Form Update
                    npc_no_textbox.Text = npc.no.ToString();
                    npc_name_textbox.Text = npc.name;
                    npc_image_textbox.Text = npc.image;

                    npc_id_numbox.Value = npc.id;
                    npc_mapid_numbox.Value = npc.mapid;
                    npc_x_numbox.Value = npc.x;
                    npc_y_numbox.Value = npc.y;

                    npc_dir_box.Text = npc_dir_box.Items[npc.direction / 2 - 1].ToString();
                    npc_pattern_box.Text = npc_pattern_box.Items[npc.pattern].ToString();
                    npc_speed_box.Text = npc.move_speed.ToString();

                    npc_action_numbox.Value = npc.default_action;
                    // DataLoad
                    npcData = new NPCData(path_textbox.Text, npc.no, npc);
                    loadNPCData();
                }
            }
            catch (Exception err)
            {
                Console.warning(err.ToString());
            }
        }
        // 클리어
        public void information_clear()
        {
            npc_no_textbox.Text = "";
            npc_name_textbox.Text = "";
            npc_image_textbox.Text = "";

            npc_id_numbox.Value = 0;
            npc_mapid_numbox.Value = 0;
            npc_x_numbox.Value = 0;
            npc_y_numbox.Value = 0;

            npc_dir_box.Text = "";
            npc_pattern_box.Text = "";
            npc_speed_box.Text = "";

            npc_action_numbox.Value = 0;
            if (npcData != null)
                loadNPCData();
        }
        public void loadNPCData()
        {
            string text;
            string[] data;
            NPCMessage npcMsg;
            NPCAction npcAct;
            NPCStore npcStore;
            NPCFunction npcFunc;
            npc_data_listbox.Items.Clear();
            foreach (object obj in npcData.List)
            {
                text = "";
                if (obj is NPCMessage)
                {
                    npcMsg = obj as NPCMessage;
                    text = $"<문장:{npcMsg.index}> \"{npcMsg.text}\"";
                    if (npcMsg.button)
                    {
                        text += $", 버튼[";
                        for (int i = 0; i < npcMsg.actions.Length; i++)
                        {
                            text += $"{npcMsg.actions[i]}";
                            if (i < npcMsg.actions.Length - 1) { text += ", "; }
                        }
                        text += "]";
                    }
                    else
                        text += $", 액션[{npcMsg.actions[0]}]";
                }
                if (obj is NPCAction)
                {
                    npcAct = obj as NPCAction;
                    text = $"<액션:{npcAct.index}> ";
                    if (npcAct.text != "")
                        text += $"\"{npcAct.text}\", ";
                    if (npcAct.split_command[0] == "IF")
                    {
                        data = npcAct.command.Split(';');
                        data[0] = data[0].Replace("IF:", "");
                        // 연산자 변환
                        data[0] = data[0].Replace("[EQU]", " == ");
                        data[0] = data[0].Replace("[UNE]", " != ");
                        data[0] = data[0].Replace("[MOR]", " >= ");
                        data[0] = data[0].Replace("[BEL]", " <= ");
                        data[0] = data[0].Replace("[EXC]", " > ");
                        data[0] = data[0].Replace("[UND]", " < ");
                        //
                        text += $"조건[{data[0]} ? {command_text(data[1].Split(':')[0], data[1].Split(':'))} : {command_text(data[2].Split(':')[0], data[2].Split(':'))}]";
                    }
                    else
                        text += command_text(npcAct.split_command[0], npcAct.split_command);
                }
                if (obj is NPCStore)
                {
                    npcStore = obj as NPCStore;
                    text = $"<상점:{npcStore.index}> 상점표시[{npcStore.store_no}], 액션[{npcStore.action}]";
                }
                if (obj is NPCFunction)
                {
                    npcFunc = obj as NPCFunction;
                    text = $"<함수실행:{npcFunc.index}> 함수[{npcFunc.func}], 액션[{npcFunc.action}]";
                }
                npc_data_listbox.Items.Insert(npc_data_listbox.Items.Count, text);
            }
        }
        private string command_text(string text, string[] cmd)
        {
            string str = "";
            switch (text)
            {
                case "MESSAGE":
                    str += $"문장표시({cmd[1]})";
                    break;
                case "END":
                    str += "처리 종료";
                    break;
                case "STORE":
                    str += $"상점호출({cmd[1]})";
                    break;
                case "FUNCTION":
                    str += $"함수실행({cmd[1]})";
                    break;
            }

            return str;
        }
        // 데이터 파일 추가
        private void npc_data_add_button_Click(object sender, EventArgs e)
        {
            if (npcData != null)
            {
                addDataForm addData = new addDataForm();
                addData.StartPosition = FormStartPosition.Manual;
                addData.Location = new Point(Location.X + (Width - addData.Width) / 2, Location.Y + (Height - addData.Height) / 2);
                addData.Owner = this;
                addData.ShowDialog();
            }
            else
                MessageBoxEx.Show(this, "NPC DB 정보를 먼저 불러와주세요.");
        }
        // 데이터를 추가
        public void addData(int type, string data)
        {

            npcData.addData(data);
            loadNPCData();
        }
        // DB 데이터 추가
        private void npc_db_create_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 0);
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }
        // 데이터 삭제
        private void npc_data_delete_button_Click(object sender, EventArgs e)
        {
            if (npc_data_listbox.SelectedIndex != -1)
            {
                if (Mysql.ping())
                    if (MessageBoxEx.Show(this, "정말로 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        npcData.delData(npcData.List[npc_data_listbox.SelectedIndex]);
                        loadNPCData();
                    }
            }
        }
        // DB 데이터 삭제
        private void npc_db_delete_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 1);
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }
        // 데이터 저장
        private void npc_data_save_button_Click(object sender, EventArgs e)
        {
            if (npcData == null)
                return;
            string filePath = $"{path_textbox.Text}\\NPC{npc_no_textbox.Text}.dat";
            if (File.Exists(filePath))
                if (MessageBoxEx.Show("이미 데이터 파일이 존재합니다.\n계속하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                    return;
            string fileData = "";
            foreach (object obj in npcData.List)
            {
                if (obj is NPCMessage)
                    fileData += ((NPCMessage)obj).string_command + '\n';
                if (obj is NPCAction)
                    fileData += ((NPCAction)obj).string_command + '\n';
                if (obj is NPCStore)
                    fileData += ((NPCStore)obj).string_command + '\n';
                if (obj is NPCFunction)
                    fileData += ((NPCFunction)obj).string_command + '\n';
            }
            File.WriteAllText(filePath, fileData);
            MessageBoxEx.Show("파일 저장이 완료되었습니다.", "데이터 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // DB 데이터 저장
        private void npc_db_save_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
            {
                if (MessageBoxEx.Show(this, "현재의 데이터를 저장하시겠습니까?", "DB 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try {
                        DataTable rs = Mysql.Query($"SELECT * FROM npc WHERE no = '{npc_no_textbox.Text}'");
                        if (rs.Rows.Count == 0)
                        {
                            MessageBoxEx.Show(this, "잘못된 식별번호입니다.", "DB 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string sql = "UPDATE npc SET ";
                        sql += $"no = '{npc_no_textbox.Text}',";
                        sql += $"name = '{npc_name_textbox.Text}',";
                        sql += $"image = '{npc_image_textbox.Text}',";
                        sql += $"id = '{npc_id_numbox.Value}',";
                        sql += $"map_id = '{npc_mapid_numbox.Value}',";
                        sql += $"map_x = '{npc_x_numbox.Value}',";
                        sql += $"map_y = '{npc_y_numbox.Value}',";
                        sql += $"direction = '{(npc_dir_box.SelectedIndex + 1) * 2}',";
                        sql += $"pattern = '{npc_pattern_box.SelectedIndex}',";
                        sql += $"move_speed = '{npc_speed_box.SelectedIndex}',";
                        sql += $"default_action = '{npc_action_numbox.Value}' ";
                        sql += $"WHERE no = '{npc_no_textbox.Text}'";

                        Mysql.Query(sql);
                        loadData();

                        Console.info($"성공적으로 데이터를 업데이트했습니다. (NPC 데이터 업데이트 : {npc_name_textbox.Text})");
                        MessageBoxEx.Show(this, "성공적으로 저장되었습니다.", "DB 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        Console.warning(err.ToString());
                    }
                }
            }
        }
        #endregion

        #region 아이템 탭 컨트롤
        private void item_listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mysql.ping())
                if (item_listview.SelectedItems.Count > 0)
                {
                    ItemData obj = itemListData[item_listview.SelectedIndices[0]] as ItemData;
                    item_no_textbox.Text = obj.no.ToString();
                    item_name_textbox.Text = obj.name;
                    item_icon_textbox.Text = obj.icon;
                    item_desc_textbox.Text = obj.description;
                    item_type_box.Text = item_type_box.Items[obj.type].ToString();
                    item_equip_box.Text = item_equip_box.Items[obj.equip].ToString();
                    item_price_numbox.Value = obj.price;
                    item_str_numbox.Value = obj.str;
                    item_dex_numbox.Value = obj.dex;
                    item_int_numbox.Value = obj.Int;
                    item_luk_numbox.Value = obj.luk;
                    item_hp_numbox.Value = obj.hp;
                    item_mp_numbox.Value = obj.mp;
                    item_solid_numbox.Value = obj.solid;
                    item_max_ability_numbox.Value = obj.max_ability;
                    item_ability_numbox.Value = obj.ability;
                    item_lv_numbox.Value = obj.lv_cost;
                    item_rank_box.Text = item_rank_box.Items[obj.rank].ToString();

                    item_trade_box.Text = item_trade_box.Items[obj.trade ? 1 : 0].ToString();
                    item_sell_box.Text = item_sell_box.Items[obj.sell ? 1 : 0].ToString();
                    item_use_box.Text = item_use_box.Items[obj.use ? 1 : 0].ToString();

                    item_method_box.Text = obj.method_name;
                    item_method_numbox.Value = obj.method_arg;
                    item_animation_numbox.Value = obj.animation_id;
                }
        }

        private void item_db_create_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 0, "storage_item");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void item_db_save_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
                if (MessageBoxEx.Show(this, "현재의 데이터를 저장하시겠습니까?", "DB 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable rs = Mysql.Query($"SELECT * FROM storage_item WHERE no = '{item_no_textbox.Text}'");
                        if (rs.Rows.Count == 0)
                        {
                            MessageBoxEx.Show(this, "잘못된 식별번호입니다.", "DB 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string sql = "UPDATE storage_item SET ";
                        sql += $"no = '{item_no_textbox.Text}',";
                        sql += $"name = '{item_name_textbox.Text}',";
                        sql += $"icon = '{item_icon_textbox.Text}',";
                        sql += $"description = '{item_desc_textbox.Text}',";
                        sql += $"type = '{item_type_box.SelectedIndex}',";
                        sql += $"equip_type = '{item_equip_box.SelectedIndex}',";
                        sql += $"price = '{item_price_numbox.Value}',";
                        sql += $"str = '{item_str_numbox.Value}',";
                        sql += $"dex = '{item_dex_numbox.Value}',";
                        sql += $"`int` = '{item_int_numbox.Value}',";
                        sql += $"luk = '{item_luk_numbox.Value}',";
                        sql += $"hp = '{item_hp_numbox.Value}',";
                        sql += $"mp = '{item_mp_numbox.Value}',";
                        sql += $"solid = '{item_solid_numbox.Value}',";
                        sql += $"max_ability = '{item_max_ability_numbox.Value}',";
                        sql += $"ability = '{item_ability_numbox.Value}',";
                        sql += $"lv_cost = '{item_lv_numbox.Value}',";
                        sql += $"rank = '{item_rank_box.SelectedIndex}',";
                        sql += $"trade = '{item_trade_box.SelectedIndex}',";
                        sql += $"sell = '{item_sell_box.SelectedIndex}',";
                        sql += $"`use` = '{item_use_box.SelectedIndex}',";

                        sql += $"method_name = '{item_method_box.Text}',";
                        sql += $"method_arg = '{item_method_numbox.Value}',";
                        sql += $"animation_id = '{item_animation_numbox.Value}' ";

                        sql += $"WHERE no = '{item_no_textbox.Text}'";
                        Mysql.Query(sql);
                        loadData();

                        Console.info($"성공적으로 데이터를 업데이트했습니다. (아이템 데이터 업데이트 : {item_name_textbox.Text})");
                        MessageBoxEx.Show(this, "성공적으로 저장되었습니다.", "DB 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        Console.warning(err.ToString());
                    }
                }
        }

        private void item_db_delete_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 1, "storage_item");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }
        #endregion

        #region 몬스터 탭 컨트롤
        private void enemy_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = enemy_listbox.SelectedIndex;
            if (index != -1)
            {
                EnemyData obj = (enemyListData[index] as EnemyData);

                enemy_no_textbox.Text = obj.no.ToString();
                enemy_name_textbox.Text = obj.name;
                enemy_image_textbox.Text = obj.image;
                enemy_exp_numbox.Value = obj.exp;
                enemy_lv_numbox.Value = obj.level;
                enemy_sight_numbox.Value = obj.sight;
                enemy_hp_numbox.Value = obj.maxhp;
                enemy_mp_numbox.Value = obj.maxmp;
                enemy_str_numbox.Value = obj.str;
                enemy_dex_numbox.Value = obj.dex;
                enemy_int_numbox.Value = obj.Int;
                enemy_luk_numbox.Value = obj.luk;
                enemy_dir_box.Text = enemy_dir_box.Items[obj.direction / 2 - 1].ToString();
                enemy_speed_numbox.Value = obj.move_speed;
                enemy_delay_numbox.Value = obj.delay;
                enemy_rebirth_numbox.Value = obj.rebirth_time;
                enemy_animation_numbox.Value = obj.animation_id;
                enemy_drop_item_load(obj);
                enemy_position_load(obj);
            }
        }

        public void enemy_drop_item_load(EnemyData obj)
        {
            ListViewItem list;
            ListViewItem.ListViewSubItem item;
            ItemData itemData;
            enemy_listview.Items.Clear();
            obj.loadDropItem();
            foreach (EnemyDropItem data in obj.dropData)
            {
                itemData = getItemData(data.item_no);
                list = new ListViewItem();
                list.Text = itemData.name;
                // 타입
                item = new ListViewItem.ListViewSubItem();
                item.Text = item_type_box.Items[itemData.type].ToString();
                list.SubItems.Add(item);
                // 확률
                item = new ListViewItem.ListViewSubItem();
                item.Text = (data.rate / 10.0).ToString("#.#") + "%";
                list.SubItems.Add(item);

                enemy_listview.Items.Add(list);
            }
        }

        public void enemy_position_load(EnemyData obj)
        {
            ListViewItem list;
            ListViewItem.ListViewSubItem item;
            enemy_pos_listview.Items.Clear();
            obj.loadPosition();
            foreach (EnemyPosition data in obj.posData)
            {
                list = new ListViewItem();
                list.Text = data.mapid.ToString() + "번 맵";
                // Map X
                item = new ListViewItem.ListViewSubItem();
                item.Text = data.x.ToString();
                list.SubItems.Add(item);
                // Map Y
                item = new ListViewItem.ListViewSubItem();
                item.Text = data.y.ToString();
                list.SubItems.Add(item);
                enemy_pos_listview.Items.Add(list);
            }
        }

        private void enemy_drop_add_button_Click(object sender, EventArgs e)
        {
            if (enemy_listbox.SelectedItems.Count == 1)
            {
                int index = enemy_listbox.SelectedIndex;
                EnemyData obj = (enemyListData[index] as EnemyData);
                addDropItemForm addDropItem = new addDropItemForm(this, obj);
                addDropItem.StartPosition = FormStartPosition.Manual;
                addDropItem.Location = new Point(Location.X + (Width - addDropItem.Width) / 2, Location.Y + (Height - addDropItem.Height) / 2);
                addDropItem.Owner = this;
                addDropItem.ShowDialog();
            }
        }

        private void enemy_drop_delete_button_Click(object sender, EventArgs e)
        {
            if (enemy_listview.SelectedIndices[0] != -1)
            {
                if (Mysql.ping())
                    if (MessageBoxEx.Show(this, "정말로 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int index = enemy_listbox.SelectedIndex;
                        EnemyData obj = (enemyListData[index] as EnemyData);
                        Mysql.Query($"DELETE FROM enemy_dropitem WHERE no = '{(obj.dropData[enemy_listview.SelectedIndices[0]] as EnemyDropItem).no}'");
                        Console.info($"성공적으로 데이터를 삭제했습니다. (몬스터 드랍아이템 : {getItemData((obj.dropData[enemy_listview.SelectedIndices[0]] as EnemyDropItem).item_no).name})");
                        enemy_drop_item_load(obj);
                    }
            }
        }

        private void enemy_listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (enemy_listview.SelectedItems.Count == 1)
            {
                int index = enemy_listbox.SelectedIndex;
                EnemyData obj = (enemyListData[index] as EnemyData);
                addDropItemForm addDropItem = new addDropItemForm(this, obj, ((enemyListData[enemy_listbox.SelectedIndices[0]] as EnemyData).dropData[enemy_listview.SelectedIndices[0]] as EnemyDropItem));
                addDropItem.StartPosition = FormStartPosition.Manual;
                addDropItem.Location = new Point(Location.X + (Width - addDropItem.Width) / 2, Location.Y + (Height - addDropItem.Height) / 2);
                addDropItem.Owner = this;
                addDropItem.ShowDialog();
            }
        }

        private void enemy_db_create_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 0, "enemy");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void enemy_db_delete_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 1, "enemy");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void enemy_db_save_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
            {
                if (MessageBoxEx.Show(this, "현재의 데이터를 저장하시겠습니까?", "DB 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable rs = Mysql.Query($"SELECT * FROM enemy WHERE no = '{enemy_no_textbox.Text}'");
                        if (rs.Rows.Count == 0)
                        {
                            MessageBoxEx.Show(this, "잘못된 식별번호입니다.", "DB 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string sql = "UPDATE enemy SET ";
                        sql += $"no = '{enemy_no_textbox.Text}',";
                        sql += $"name = '{enemy_name_textbox.Text}',";
                        sql += $"image = '{enemy_image_textbox.Text}',";

                        sql += $"exp = '{enemy_exp_numbox.Value}',";
                        sql += $"level = '{enemy_lv_numbox.Value}',";
                        sql += $"sight = '{enemy_sight_numbox.Value}',";
                        sql += $"maxhp = '{enemy_hp_numbox.Value}',";
                        sql += $"maxmp = '{enemy_mp_numbox.Value}',";
                        sql += $"str = '{enemy_str_numbox.Value}',";
                        sql += $"dex = '{enemy_dex_numbox.Value}',";
                        sql += $"`int` = '{enemy_int_numbox.Value}',";
                        sql += $"luk = '{enemy_luk_numbox.Value}',";
                        sql += $"direction = '{(enemy_dir_box.SelectedIndex + 1) * 2}',";
                        sql += $"move_speed = '{enemy_speed_numbox.Value}',";
                        sql += $"delay = '{enemy_delay_numbox.Value}',";
                        sql += $"rebirth_time = '{enemy_rebirth_numbox.Value}',";
                        sql += $"pattern = '{enemy_pattern_numbox.Value}',";
                        sql += $"animation_id = '{enemy_animation_numbox.Value}'";

                        sql += $"WHERE no = '{enemy_no_textbox.Text}'";

                        Mysql.Query(sql);
                        loadData();

                        Console.info($"성공적으로 데이터를 업데이트했습니다. (몬스터 데이터 업데이트 : {enemy_name_textbox.Text})");
                        MessageBoxEx.Show(this, "성공적으로 저장되었습니다.", "DB 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        Console.warning(err.ToString());
                    }
                }
            }
        }

        private void enemy_pos_add_button_Click(object sender, EventArgs e)
        {
            if (enemy_listbox.SelectedItems.Count == 1)
            {
                int index = enemy_listbox.SelectedIndex;
                EnemyData obj = (enemyListData[index] as EnemyData);
                addEnemyPositionForm addPosition = new addEnemyPositionForm(this, obj);
                addPosition.StartPosition = FormStartPosition.Manual;
                addPosition.Location = new Point(Location.X + (Width - addPosition.Width) / 2, Location.Y + (Height - addPosition.Height) / 2);
                addPosition.Owner = this;
                addPosition.ShowDialog();
            }
        }

        private void enemy_pos_delete_button_Click(object sender, EventArgs e)
        {
            if (enemy_pos_listview.SelectedIndices[0] != -1)
            {
                if (Mysql.ping())
                    if (MessageBoxEx.Show(this, "정말로 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int index = enemy_listbox.SelectedIndex;
                        EnemyData obj = (enemyListData[index] as EnemyData);
                        Mysql.Query($"DELETE FROM enemy_position WHERE no = '{(obj.posData[enemy_pos_listview.SelectedIndices[0]] as EnemyPosition).no}'");
                        Console.info($"성공적으로 데이터를 삭제했습니다. (몬스터 위치 : {(obj.posData[enemy_pos_listview.SelectedIndices[0]] as EnemyPosition).no})");
                        enemy_position_load(obj);
                    }
            }
        }

        #endregion

        #region 상점 탭 컨트롤
        private void store_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = store_listbox.SelectedIndex;
            if (index != -1)
            {
                StoreData obj = (storeListData[index] as StoreData);

                store_no_textbox.Text = obj.no.ToString();
                store_name_textbox.Text = obj.name;
                store_item_load(obj);
            }
        }

        public void store_item_load(StoreData obj)
        {
            ListViewItem list;
            ListViewItem.ListViewSubItem item;
            ItemData itemData;
            store_listview.Items.Clear();
            obj.loadItems();
            foreach (StoreItem data in obj.itemData)
            {
                itemData = getItemData(data.item_no);
                list = new ListViewItem();
                list.Text = itemData.name;
                // 수량
                item = new ListViewItem.ListViewSubItem();
                item.Text = (data.number == -1 ? "무제한" : data.number.ToString());
                list.SubItems.Add(item);
                // 가격
                item = new ListViewItem.ListViewSubItem();
                item.Text = data.price.ToString() + $" ({100-data.discount}%)";
                list.SubItems.Add(item);

                store_listview.Items.Add(list);
            }
            store_item_box.Items.Clear();
            foreach (ItemData data in itemListData)
            {
                store_item_box.Items.Add(data.name.ToString());
            }
        }

        private void store_db_create_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 0, "store");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void store_db_delete_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 1, "store");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void store_db_save_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
            {
                if (MessageBoxEx.Show(this, "현재의 데이터를 저장하시겠습니까?", "DB 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable rs = Mysql.Query($"SELECT * FROM store WHERE no = '{store_no_textbox.Text}'");
                        if (rs.Rows.Count == 0)
                        {
                            MessageBoxEx.Show(this, "잘못된 식별번호입니다.", "DB 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string sql = "UPDATE store SET ";
                        sql += $"no = '{store_no_textbox.Text}',";
                        sql += $"name = '{store_name_textbox.Text}'";

                        sql += $"WHERE no = '{store_no_textbox.Text}'";

                        Mysql.Query(sql);
                        loadData();

                        Console.info($"성공적으로 데이터를 업데이트했습니다. (상점 데이터 업데이트 : {store_name_textbox.Text})");
                        MessageBoxEx.Show(this, "성공적으로 저장되었습니다.", "DB 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        Console.warning(err.ToString());
                    }
                }
            }
        }
        
        private void store_item_add_button_Click(object sender, EventArgs e)
        {
            if (store_listbox.SelectedItems.Count == 1)
            {
                int index = store_listbox.SelectedIndex;
                if (store_item_box.SelectedIndex >= 0)
                {
                    StoreData obj = (storeListData[index] as StoreData);
                    ItemData item = itemListData[store_item_box.SelectedIndex] as ItemData;
                    string str;
                    str = $"'{obj.no}', '{item.no}', '{store_item_num_numbox.Value}', '{store_item_price_numbox.Value}', '{store_item_discount_numbox.Value}'";
                    Mysql.Query($"INSERT INTO store_item (store_no, item_no, number, price, discount) VALUES ({str})");
                    store_item_box.Text = "";
                    store_item_num_numbox.Value = -1;
                    store_item_price_numbox.Value = 0;
                    store_item_discount_numbox.Value = 0;
                    Console.info($"성공적으로 데이터를 추가했습니다. (상점 아이템 : {item.name})");
                    store_item_load(obj);
                }
                else
                    MessageBoxEx.Show(this, "상품을 선택해주세요.", "상품 추가 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void store_item_delete_button_Click(object sender, EventArgs e)
        {
            if (store_listview.SelectedIndices[0] != -1)
            {
                if (Mysql.ping())
                    if (MessageBoxEx.Show(this, "정말로 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int index = store_listbox.SelectedIndex;
                        StoreData obj = (storeListData[index] as StoreData);
                        Mysql.Query($"DELETE FROM store_item WHERE no = '{(obj.itemData[store_listview.SelectedIndices[0]] as StoreItem).no}'");
                        Console.info($"성공적으로 데이터를 삭제했습니다. (상점 아이템 : {getItemData((obj.itemData[store_listview.SelectedIndices[0]] as StoreItem).item_no).name})");
                        store_item_load(obj);
                    }
            }
        }
        #endregion

        #region 스킬 탭 컨트롤
        private void skill_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = skill_listbox.SelectedIndex;
            if (index != -1)
            {
                SkillData obj = (skillListData[index] as SkillData);

                skill_no_textbox.Text = obj.no.ToString();
                skill_name_textbox.Text = obj.name;
                skill_icon_textbox.Text = obj.icon;
                skill_desc_textbox.Text = obj.description;
                skill_lv_numbox.Value = obj.max_level;
                skill_power_numbox.Value = obj.power;
                skill_factor_numbox.Value = obj.power_factor;
                skill_lv_damage_numbox.Value = obj.level_power;
                skill_range_type_numbox.Value = obj.range_type;
                skill_range_numbox.Value = obj.range;
                skill_count_numbox.Value = obj.count;
                skill_delay_numbox.Value = obj.delay;
                skill_wait_numbox.Value = obj.wait_time;
                skill_cost_numbox.Value = obj.cost;
                skill_use_animation_numbox.Value = obj.use_animation;
                skill_target_animation_numbox.Value = obj.target_animation;
                skill_function_textbox.Text = obj.function;
            }
        }

        private void skill_db_create_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 0, "storage_skill");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void skill_db_delete_button_Click(object sender, EventArgs e)
        {
            Dialog dataForm = new Dialog(this, 1, "storage_skill");
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.ShowDialog();
        }

        private void skill_db_save_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
            {
                if (MessageBoxEx.Show(this, "현재의 데이터를 저장하시겠습니까?", "DB 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable rs = Mysql.Query($"SELECT * FROM storage_skill WHERE no = '{skill_no_textbox.Text}'");
                        if (rs.Rows.Count == 0)
                        {
                            MessageBoxEx.Show(this, "잘못된 식별번호입니다.", "DB 저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string sql = "UPDATE storage_skill SET ";
                        sql += $"no = '{skill_no_textbox.Text}',";
                        sql += $"name = '{skill_name_textbox.Text}',";
                        sql += $"icon = '{skill_icon_textbox.Text}',";
                        sql += $"description = '{skill_desc_textbox.Text}',";
                        sql += $"max_level = '{skill_lv_numbox.Value}',";
                        sql += $"power = '{skill_power_numbox.Value}',";
                        sql += $"power_factor = '{skill_factor_numbox.Value}',";
                        sql += $"level_power = '{skill_lv_damage_numbox.Value}',";
                        sql += $"range_type = '{skill_range_type_numbox.Value}',";
                        sql += $"`range` = '{skill_range_numbox.Value}',";
                        sql += $"count = '{skill_count_numbox.Value}',";
                        sql += $"delay = '{skill_delay_numbox.Value}',";
                        sql += $"wait_time = '{skill_wait_numbox.Value}',";
                        sql += $"cost = '{skill_cost_numbox.Value}',";
                        sql += $"use_animation = '{skill_use_animation_numbox.Value}',";
                        sql += $"target_animation = '{skill_target_animation_numbox.Value}',";
                        sql += $"function = '{skill_function_textbox.Text}'";

                        sql += $"WHERE no = '{skill_no_textbox.Text}'";

                        Mysql.Query(sql);
                        loadData();

                        Console.info($"성공적으로 데이터를 업데이트했습니다. (기술 데이터 업데이트 : {skill_name_textbox.Text})");
                        MessageBoxEx.Show(this, "성공적으로 저장되었습니다.", "DB 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        Console.warning(err.ToString());
                    }
                }
            }
        }
        #endregion
    }
}

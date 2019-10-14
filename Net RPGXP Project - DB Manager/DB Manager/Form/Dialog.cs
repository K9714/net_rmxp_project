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
    public partial class Dialog : Form
    {
        public mainForm main_form;
        private int type;
        private string table;
        private string[] msg = {
            "추가시킬 데이터의 이름(`name`)을 입력해주세요.",
            "삭제시킬 데이터의 식별번호(`no`)를 입력해주세요."
        };
        public Dialog(mainForm _mainForm, int _type, string _table="npc")
        {
            main_form = _mainForm;
            InitializeComponent();
            type = _type;
            table = _table;
            textlabel.Text = msg[type];
        }

        private void addData(string str)
        {
            try
            {
                Mysql.Query($"INSERT INTO {table} (name) VALUES ('{str}')");
                Console.info($"성공적으로 데이터를 추가했습니다. ({table} 데이터 추가 : {str})");
                main_form.loadData();
            }
            catch(Exception e)
            {
                Console.warning(e.ToString());
            }
        }
        private void delData(int no)
        {
            try
            {
                DataTable rs = Mysql.Query($"SELECT * FROM {table} WHERE no = '{no}'");
                if (rs.Rows.Count == 0)
                {
                    MessageBoxEx.Show(this, "존재하지 않는 식별번호입니다.", "DB 작업 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Mysql.Query($"DELETE FROM {table} WHERE no = '{no}'");
                if (table == "enemy")
                    Mysql.Query($"DELETE FROM enemy_dropitem WHERE enemy_no = '{no}'");
                if (table == "store")
                    Mysql.Query($"DELETE FROM store_item WHERE store_no = '{no}'");
                Console.info($"성공적으로 데이터를 제거했습니다. ({table} 데이터 제거 : {no})");
                main_form.loadData();
            }
            catch(Exception e)
            {
                Console.warning(e.ToString());
            }
        }

        private void dialog_button_Click(object sender, EventArgs e)
        {
            if (Mysql.ping())
            {
                switch (type)
                {
                    case 0:
                        addData(input_textbox.Text);
                        break;
                    case 1:
                        delData(Convert.ToInt32(input_textbox.Text));
                        break;
                }
            }
            Close();
        }
    }
}

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
    public partial class addEnemyPositionForm : Form
    {
        public EnemyData enemy { get; private set; }
        public mainForm main_form;
        public addEnemyPositionForm(mainForm _mainForm, EnemyData _enemy)
        {
            InitializeComponent();
            main_form = _mainForm;
            enemy = _enemy;
        }
        private void msg(string str)
        {
            MessageBoxEx.Show(this, str, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (mapid_numbox.Value == 0) { msg("Map ID 의 값은 '0' 일 수 없습니다."); return; }
            string fields = "";
            string values = "";
            fields += "enemy_no,map_id,map_x,map_y";
            values += $"'{enemy.no}','{mapid_numbox.Value}','{x_numbox.Value}','{y_numbox.Text}'";

            Mysql.Query($"INSERT INTO enemy_position ({fields}) VALUES ({values})");
            Console.info($"성공적으로 데이터를 추가했습니다. (몬스터 위치 : {enemy.name})");
            main_form.enemy_position_load(enemy);
            Close();
        }
    }
}

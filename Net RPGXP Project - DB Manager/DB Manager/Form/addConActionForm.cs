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
    public partial class addConActionForm : Form
    {
        private string recvData;

        public addConActionForm()
        {
            InitializeComponent();
            true_textbox.Click += new EventHandler(true_textbox_click_event);
            false_textbox.Click += new EventHandler(false_textbox_click_event);
        }
        private void msg(string str)
        {
            MessageBoxEx.Show(this, str, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void true_textbox_click_event(object sender, EventArgs e)
        {
            recvData = true_textbox.Text;
            addActionForm dataForm = new addActionForm(true);
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
            true_textbox.Text = recvData;
        }
        public void false_textbox_click_event(object sender, EventArgs e)
        {
            recvData = false_textbox.Text;
            addActionForm dataForm = new addActionForm(true);
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
            false_textbox.Text = recvData;
        }

        public void addData(int type, string data)
        {
            recvData = data;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (action_id.Value == 0) { msg("액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (main_var_box.Text == "") { msg("첫번째 조건 변수를 입력해주세요."); return; }
            if (!var_radio_button.Checked && !num_radio_button.Checked) { msg("두번째 조건을 선택해주세요."); return; }
            if (var_radio_button.Checked && sub_var_box.Text == "") { msg("두번째 조건을 입력해주세요."); return; }
            if (num_radio_button.Checked && sub_num_box.Value == 0) { msg("두번째 조건을 입력해주세요."); return; }
            if (oper_box.Text == "") { msg("조건 비교를 선택해주세요."); return; }
            if (true_textbox.Text == "") { msg("조건이 참일때 실행될 식을 입력해주세요."); return; }
            if (false_textbox.Text == "") { msg("조건이 거짓일때 실행될 식을 입력해주세요."); return; }
            if (((mainForm)((addDataForm)Owner).Owner).npcData != null)
                foreach (object obj in ((mainForm)((addDataForm)Owner).Owner).npcData.List)
                    if (obj is NPCAction)
                        if (((NPCAction)obj).index == action_id.Value) { msg("이미 존재하는 액션 번호입니다."); return; }

            string head, body, str;
            head = $"ACTION={action_id.Value},,";
            body = "IF:";
            body += $"{main_var_box.Text}";
            str = "";
            switch (oper_box.SelectedIndex)
            {
                case 0:
                    str = "[EQU]";
                    break;
                case 1:
                    str = "[UNE]";
                    break;
                case 2:
                    str = "[MOR]";
                    break;
                case 3:
                    str = "[BEL]";
                    break;
                case 4:
                    str = "[EXC]";
                    break;
                case 5:
                    str = "[UND]";
                    break;
            }
            body += str;
            if (var_radio_button.Checked)
                body += $"{sub_var_box.Text};";
            if (num_radio_button.Checked)
                body += $"{sub_num_box.Value};";
            body += $"{true_textbox.Text};{false_textbox.Text}";
             ((addDataForm)Owner).addData(1, head + body);
            Close();
        }
    }
}

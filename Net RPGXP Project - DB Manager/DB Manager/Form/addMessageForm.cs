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
    public partial class addMessageForm : Form
    {
        public addMessageForm()
        {
            InitializeComponent();
        }

        private void msg(string str)
        {
            MessageBoxEx.Show(this, str, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.CheckState = CheckState.Indeterminate;
            checkBox1.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            act_02_id.Enabled = checkBox2.Checked;
            buttonCheckBox.Checked = (checkBox2.Checked ? true : buttonCheckBox.Checked);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            act_03_id.Enabled = checkBox3.Checked;
            buttonCheckBox.Checked = (checkBox3.Checked ? true : buttonCheckBox.Checked);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            act_04_id.Enabled = checkBox4.Checked;
            buttonCheckBox.Checked = (checkBox4.Checked ? true : buttonCheckBox.Checked);
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 추가
        private void add_button_Click(object sender, EventArgs e)
        {
            // 값을 검사함
            if (message_id.Value == 0) { msg("메세지 번호의 값은 '0' 일 수 없습니다."); return; }
            if (textbox.Text == "") { msg("텍스트를 입력해주세요."); return; }
            if (act_01_id.Value == 0) { msg("1번 액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (checkBox2.Checked && act_02_id.Value == 0) { msg("액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (checkBox3.Checked && act_03_id.Value == 0) { msg("액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (checkBox4.Checked && act_04_id.Value == 0) { msg("액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (((addDataForm)Owner).Owner is mainForm)
                if (((mainForm)((addDataForm)Owner).Owner).npcData != null)
                    foreach (object obj in ((mainForm)((addDataForm)Owner).Owner).npcData.List)
                        if (obj is NPCMessage)
                            if (((NPCMessage)obj).index == message_id.Value) { msg("이미 존재하는 메세지 번호입니다."); return; }
            string str, button;
            int count;
            str = $"MESSAGE={message_id.Value},";
            if (buttonCheckBox.Checked)
            {
                count = 1;
                button = $"{act_01_id.Value}";
                if (checkBox2.Checked) { count++; button += $",{act_02_id.Value}"; }
                if (checkBox3.Checked) { count++; button += $",{act_03_id.Value}"; }
                if (checkBox4.Checked) { count++; button += $",{act_04_id.Value}"; }
                str += $"{count}[{button}],";
            }
            else
            {
                str += $"{act_01_id.Value},";
            }
            str += $"{textbox.Text.Replace("\n", "\\n")}";

            ((addDataForm)Owner).addData(0, str);
            Close();
        }
    }
}

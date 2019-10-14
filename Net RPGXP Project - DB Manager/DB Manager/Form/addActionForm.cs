using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Manager
{
    public partial class addActionForm : Form
    {
        public bool conAction { get; private set; }
        public addActionForm(bool _conAction = false)
        {
            InitializeComponent();
            conAction = _conAction;
            if (conAction)
            {
                action_id.Enabled = false;
                checkBox1.Enabled = false;
            }
        }
        private void msg(string str)
        {
            MessageBoxEx.Show(this, str, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void radio_button_control(RadioButton obj)
        {
            bool check = obj.Checked;
            if (!check) { return; }
            if (obj != msg_radio_button)
                msg_radio_button.Checked = false;
            if (obj != end_radio_button)
                end_radio_button.Checked = false;
            if (obj != store_radio_button)
                store_radio_button.Checked = false;
            if (obj != func_radio_button)
                func_radio_button.Checked = false;
        }

        private bool radio_button_IsSelect()
        {
            if (msg_radio_button.Checked)
                return true;
            if (end_radio_button.Checked)
                return true;
            if (store_radio_button.Checked)
                return true;
            if (func_radio_button.Checked)
                return true;
            return false;
        }

        private void msg_radio_button_CheckedChanged(object sender, EventArgs e)
        {
            radio_button_control(msg_radio_button);
        }
        private void end_radio_button_CheckedChanged(object sender, EventArgs e)
        {
            radio_button_control(end_radio_button);
        }
        private void store_radio_button_CheckedChanged(object sender, EventArgs e)
        {
            radio_button_control(store_radio_button);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button_textbox.Enabled = checkBox1.Checked;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (action_id.Value == 0 && !conAction) { msg("액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (!radio_button_IsSelect()) { msg("추가할 액션을 선택해주세요."); return; }
            if (msg_radio_button.Checked && msg_id.Value == 0) { msg("문장 번호의 값은 '0' 일 수 없습니다."); return; }
            if (store_radio_button.Checked && store_id.Value == 0) { msg("상점 번호의 값은 '0' 일 수 없습니다."); return; }
            if (func_radio_button.Checked && func_id.Value == 0) { msg("함수 실행 번호의 값은 '0' 일 수 없습니다."); return; }
            if (Owner is addDataForm)
                if(((mainForm)((addDataForm)Owner).Owner).npcData != null)
                    foreach (object obj in ((mainForm)((addDataForm)Owner).Owner).npcData.List)
                        if (obj is NPCAction)
                            if (((NPCAction)obj).index == action_id.Value) { msg("이미 존재하는 액션 번호입니다."); return; }
            string head, body;
            head = $"ACTION={action_id.Value},{button_textbox.Text},";
            body = "";
            if (msg_radio_button.Checked)
                body += $"MESSAGE:{msg_id.Value}";
            if (end_radio_button.Checked)
                body += $"END";
            if (store_radio_button.Checked)
                body += $"STORE:{store_id.Value}";
            if (func_radio_button.Checked)
                body += $"FUNCTION:{func_id.Value}";
            if(conAction)
                ((addConActionForm)Owner).addData(2, body);
            else
                ((addDataForm)Owner).addData(2, head + body);
            Close();
        }
    }
}

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
    public partial class addFunctionForm : Form
    {
        public addFunctionForm()
        {
            InitializeComponent();
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
            // 값을 검사함
            if (func_index_numbox.Value == 0) { msg("함수 실행 호출 번호의 값은 '0' 일 수 없습니다."); return; }
            if (func_action_numbox.Value == 0) { msg("실행할 액션 번호의 값은 '0' 일 수 없습니다."); return; }
            if (func_name_textbox.Text == "") { msg("함수 이름의 값은 공백일 수 없습니다."); return; }

            if (((addDataForm)Owner).Owner is mainForm)
                if (((mainForm)((addDataForm)Owner).Owner).npcData != null)
                    foreach (object obj in ((mainForm)((addDataForm)Owner).Owner).npcData.List)
                        if (obj is NPCFunction)
                            if (((NPCFunction)obj).index == func_index_numbox.Value) { msg("이미 존재하는 상점 호출 번호입니다."); return; }
            string str;
            str = $"FUNCTION={func_index_numbox.Value},";
            str += $"{func_action_numbox.Value},";
            str += $"{func_name_textbox.Text}";

            ((addDataForm)Owner).addData(0, str);
            Close();
        }
    }
}

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
    public partial class addStoreForm : Form
    {
        public addStoreForm()
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
            if (store_index_numbox.Value == 0) { msg("상점 호출 번호의 값은 '0' 일 수 없습니다."); return; }
            if (action_numbox.Value == 0) { msg("실행할 액션 번호의 값은 '0' 일 수 없습니다."); return; }

            if (((addDataForm)Owner).Owner is mainForm)
                if (((mainForm)((addDataForm)Owner).Owner).npcData != null)
                    foreach (object obj in ((mainForm)((addDataForm)Owner).Owner).npcData.List)
                        if (obj is NPCStore)
                            if (((NPCStore)obj).index == store_index_numbox.Value) { msg("이미 존재하는 상점 호출 번호입니다."); return; }
            string str;
            str = $"STORE={store_index_numbox.Value},";
            str += $"{store_no_numbox.Value},";
            str += $"{action_numbox.Value}";

            ((addDataForm)Owner).addData(0, str);
            Close();
        }
    }
}

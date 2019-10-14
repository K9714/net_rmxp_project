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
    public partial class addDataForm : Form
    {
        private Form dataForm;
        public string recvData;
        public addDataForm()
        {
            InitializeComponent();
            
            FormClosed += new FormClosedEventHandler(FormCloseEvent);
        }

        private void FormCloseEvent(object sender, FormClosedEventArgs e)
        {
            //Owner.Visible = true;
        }
        public void addData(int type, string data)
        {
            if(Owner is mainForm)
                ((mainForm)Owner).addData(type, data);
            else
                ((addConActionForm)Owner).addData(type, data);
            Close();
        }

        private void add_msg_button_Click(object sender, EventArgs e)
        {
            dataForm = new addMessageForm();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
        }

        private void add_con_button_Click(object sender, EventArgs e)
        {
            dataForm = new addConActionForm();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
        }

        private void add_action_button_Click(object sender, EventArgs e)
        {
            dataForm = new addActionForm();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
        }

        private void add_store_button_Click(object sender, EventArgs e)
        {
            dataForm = new addStoreForm();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
        }

        private void add_func_button_Click(object sender, EventArgs e)
        {
            dataForm = new addFunctionForm();
            dataForm.StartPosition = FormStartPosition.Manual;
            dataForm.Location = new Point(Location.X + (Width - dataForm.Width) / 2, Location.Y + (Height - dataForm.Height) / 2);
            dataForm.Owner = this;
            dataForm.ShowDialog();
        }
    }
}

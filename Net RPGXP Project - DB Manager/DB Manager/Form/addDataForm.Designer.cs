namespace DB_Manager
{
    partial class addDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.add_store_button = new System.Windows.Forms.Button();
            this.add_con_button = new System.Windows.Forms.Button();
            this.add_action_button = new System.Windows.Forms.Button();
            this.add_msg_button = new System.Windows.Forms.Button();
            this.add_func_button = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 237);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.add_func_button);
            this.tabPage1.Controls.Add(this.add_store_button);
            this.tabPage1.Controls.Add(this.add_con_button);
            this.tabPage1.Controls.Add(this.add_action_button);
            this.tabPage1.Controls.Add(this.add_msg_button);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(252, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "일반";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // add_store_button
            // 
            this.add_store_button.Location = new System.Drawing.Point(3, 35);
            this.add_store_button.Name = "add_store_button";
            this.add_store_button.Size = new System.Drawing.Size(117, 23);
            this.add_store_button.TabIndex = 3;
            this.add_store_button.Text = "상점 호출";
            this.add_store_button.UseVisualStyleBackColor = true;
            this.add_store_button.Click += new System.EventHandler(this.add_store_button_Click);
            // 
            // add_con_button
            // 
            this.add_con_button.Location = new System.Drawing.Point(129, 6);
            this.add_con_button.Name = "add_con_button";
            this.add_con_button.Size = new System.Drawing.Size(117, 23);
            this.add_con_button.TabIndex = 2;
            this.add_con_button.Text = "조건 액션";
            this.add_con_button.UseVisualStyleBackColor = true;
            this.add_con_button.Click += new System.EventHandler(this.add_con_button_Click);
            // 
            // add_action_button
            // 
            this.add_action_button.Location = new System.Drawing.Point(129, 35);
            this.add_action_button.Name = "add_action_button";
            this.add_action_button.Size = new System.Drawing.Size(117, 23);
            this.add_action_button.TabIndex = 1;
            this.add_action_button.Text = "단일 액션";
            this.add_action_button.UseVisualStyleBackColor = true;
            this.add_action_button.Click += new System.EventHandler(this.add_action_button_Click);
            // 
            // add_msg_button
            // 
            this.add_msg_button.Location = new System.Drawing.Point(3, 6);
            this.add_msg_button.Name = "add_msg_button";
            this.add_msg_button.Size = new System.Drawing.Size(117, 23);
            this.add_msg_button.TabIndex = 0;
            this.add_msg_button.Text = "문장 표시";
            this.add_msg_button.UseVisualStyleBackColor = true;
            this.add_msg_button.Click += new System.EventHandler(this.add_msg_button_Click);
            // 
            // add_func_button
            // 
            this.add_func_button.Location = new System.Drawing.Point(3, 64);
            this.add_func_button.Name = "add_func_button";
            this.add_func_button.Size = new System.Drawing.Size(117, 23);
            this.add_func_button.TabIndex = 4;
            this.add_func_button.Text = "함수 실행";
            this.add_func_button.UseVisualStyleBackColor = true;
            this.add_func_button.Click += new System.EventHandler(this.add_func_button_Click);
            // 
            // addDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "addDataForm";
            this.Text = "NPC 실행내용 추가";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button add_action_button;
        private System.Windows.Forms.Button add_msg_button;
        private System.Windows.Forms.Button add_con_button;
        private System.Windows.Forms.Button add_store_button;
        private System.Windows.Forms.Button add_func_button;
    }
}
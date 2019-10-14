namespace DB_Manager
{
    partial class addConActionForm
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
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.main_var_box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.var_radio_button = new System.Windows.Forms.RadioButton();
            this.num_radio_button = new System.Windows.Forms.RadioButton();
            this.sub_var_box = new System.Windows.Forms.ComboBox();
            this.sub_num_box = new System.Windows.Forms.NumericUpDown();
            this.oper_box = new System.Windows.Forms.ComboBox();
            this.true_textbox = new System.Windows.Forms.TextBox();
            this.false_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.action_id = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sub_num_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_id)).BeginInit();
            this.SuspendLayout();
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(82, 198);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(93, 23);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "추가";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(181, 198);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(93, 23);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "취소";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "변수";
            // 
            // main_var_box
            // 
            this.main_var_box.FormattingEnabled = true;
            this.main_var_box.Location = new System.Drawing.Point(70, 34);
            this.main_var_box.Name = "main_var_box";
            this.main_var_box.Size = new System.Drawing.Size(121, 20);
            this.main_var_box.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "가";
            // 
            // var_radio_button
            // 
            this.var_radio_button.AutoSize = true;
            this.var_radio_button.Location = new System.Drawing.Point(17, 61);
            this.var_radio_button.Name = "var_radio_button";
            this.var_radio_button.Size = new System.Drawing.Size(47, 16);
            this.var_radio_button.TabIndex = 5;
            this.var_radio_button.TabStop = true;
            this.var_radio_button.Text = "변수";
            this.var_radio_button.UseVisualStyleBackColor = true;
            // 
            // num_radio_button
            // 
            this.num_radio_button.AutoSize = true;
            this.num_radio_button.Location = new System.Drawing.Point(17, 91);
            this.num_radio_button.Name = "num_radio_button";
            this.num_radio_button.Size = new System.Drawing.Size(47, 16);
            this.num_radio_button.TabIndex = 6;
            this.num_radio_button.TabStop = true;
            this.num_radio_button.Text = "상수";
            this.num_radio_button.UseVisualStyleBackColor = true;
            // 
            // sub_var_box
            // 
            this.sub_var_box.FormattingEnabled = true;
            this.sub_var_box.Location = new System.Drawing.Point(70, 60);
            this.sub_var_box.Name = "sub_var_box";
            this.sub_var_box.Size = new System.Drawing.Size(121, 20);
            this.sub_var_box.TabIndex = 7;
            // 
            // sub_num_box
            // 
            this.sub_num_box.Location = new System.Drawing.Point(70, 91);
            this.sub_num_box.Name = "sub_num_box";
            this.sub_num_box.Size = new System.Drawing.Size(121, 21);
            this.sub_num_box.TabIndex = 8;
            // 
            // oper_box
            // 
            this.oper_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oper_box.FormattingEnabled = true;
            this.oper_box.Items.AddRange(new object[] {
            "와 같은 값",
            "와 다른 값",
            "이상",
            "이하",
            "초과",
            "미만"});
            this.oper_box.Location = new System.Drawing.Point(105, 118);
            this.oper_box.Name = "oper_box";
            this.oper_box.Size = new System.Drawing.Size(86, 20);
            this.oper_box.TabIndex = 9;
            // 
            // true_textbox
            // 
            this.true_textbox.Location = new System.Drawing.Point(105, 144);
            this.true_textbox.Name = "true_textbox";
            this.true_textbox.ReadOnly = true;
            this.true_textbox.Size = new System.Drawing.Size(169, 21);
            this.true_textbox.TabIndex = 10;
            // 
            // false_textbox
            // 
            this.false_textbox.Location = new System.Drawing.Point(105, 171);
            this.false_textbox.Name = "false_textbox";
            this.false_textbox.ReadOnly = true;
            this.false_textbox.Size = new System.Drawing.Size(169, 21);
            this.false_textbox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "일 경우";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "이 아닐 경우";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "액션 번호";
            // 
            // action_id
            // 
            this.action_id.Location = new System.Drawing.Point(70, 7);
            this.action_id.Name = "action_id";
            this.action_id.Size = new System.Drawing.Size(100, 21);
            this.action_id.TabIndex = 15;
            // 
            // addConActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.action_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.false_textbox);
            this.Controls.Add(this.true_textbox);
            this.Controls.Add(this.oper_box);
            this.Controls.Add(this.sub_num_box);
            this.Controls.Add(this.sub_var_box);
            this.Controls.Add(this.num_radio_button);
            this.Controls.Add(this.var_radio_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.main_var_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.add_button);
            this.MaximizeBox = false;
            this.Name = "addConActionForm";
            this.Text = "조건 액션 추가";
            ((System.ComponentModel.ISupportInitialize)(this.sub_num_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_id)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox main_var_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton var_radio_button;
        private System.Windows.Forms.RadioButton num_radio_button;
        private System.Windows.Forms.ComboBox sub_var_box;
        private System.Windows.Forms.NumericUpDown sub_num_box;
        private System.Windows.Forms.ComboBox oper_box;
        private System.Windows.Forms.TextBox true_textbox;
        private System.Windows.Forms.TextBox false_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown action_id;
    }
}
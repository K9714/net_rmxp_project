namespace DB_Manager
{
    partial class addMessageForm
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
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.message_id = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.act_01_id = new System.Windows.Forms.NumericUpDown();
            this.act_03_id = new System.Windows.Forms.NumericUpDown();
            this.act_02_id = new System.Windows.Forms.NumericUpDown();
            this.act_04_id = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.buttonCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.message_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_01_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_03_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_02_id)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_04_id)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(12, 39);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(437, 98);
            this.textbox.TabIndex = 0;
            this.textbox.Text = "";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(223, 294);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(110, 23);
            this.add_button.TabIndex = 1;
            this.add_button.Text = "추가";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(339, 294);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(110, 23);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "취소";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "특수 명령";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "\\R = 코드 이후 텍스트의 색깔을 원래 색깔로 바꿈";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "\\C[r,g,b] = 코드 이후 텍스트의 색깔을 (r, g, b)로 바꿈";
            // 
            // message_id
            // 
            this.message_id.Location = new System.Drawing.Point(97, 12);
            this.message_id.Name = "message_id";
            this.message_id.Size = new System.Drawing.Size(87, 21);
            this.message_id.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "문장표시 번호";
            // 
            // act_01_id
            // 
            this.act_01_id.Location = new System.Drawing.Point(116, 143);
            this.act_01_id.Name = "act_01_id";
            this.act_01_id.Size = new System.Drawing.Size(68, 21);
            this.act_01_id.TabIndex = 6;
            // 
            // act_03_id
            // 
            this.act_03_id.Enabled = false;
            this.act_03_id.Location = new System.Drawing.Point(302, 143);
            this.act_03_id.Name = "act_03_id";
            this.act_03_id.Size = new System.Drawing.Size(68, 21);
            this.act_03_id.TabIndex = 7;
            // 
            // act_02_id
            // 
            this.act_02_id.Enabled = false;
            this.act_02_id.Location = new System.Drawing.Point(116, 170);
            this.act_02_id.Name = "act_02_id";
            this.act_02_id.Size = new System.Drawing.Size(68, 21);
            this.act_02_id.TabIndex = 8;
            // 
            // act_04_id
            // 
            this.act_04_id.Enabled = false;
            this.act_04_id.Location = new System.Drawing.Point(302, 170);
            this.act_04_id.Name = "act_04_id";
            this.act_04_id.Size = new System.Drawing.Size(68, 21);
            this.act_04_id.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBox1.Location = new System.Drawing.Point(12, 144);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "1번 액션 번호";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 171);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 16);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "2번 액션 번호";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(198, 144);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 16);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "3번 액션 번호";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(198, 171);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(98, 16);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.Text = "4번 액션 번호";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // buttonCheckBox
            // 
            this.buttonCheckBox.AutoSize = true;
            this.buttonCheckBox.Location = new System.Drawing.Point(198, 13);
            this.buttonCheckBox.Name = "buttonCheckBox";
            this.buttonCheckBox.Size = new System.Drawing.Size(104, 16);
            this.buttonCheckBox.TabIndex = 14;
            this.buttonCheckBox.Text = "버튼 표시 사용";
            this.buttonCheckBox.UseVisualStyleBackColor = true;
            // 
            // addMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(461, 329);
            this.Controls.Add(this.buttonCheckBox);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.act_04_id);
            this.Controls.Add(this.act_02_id);
            this.Controls.Add(this.act_03_id);
            this.Controls.Add(this.act_01_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.message_id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.textbox);
            this.MaximizeBox = false;
            this.Name = "addMessageForm";
            this.Text = "문장표시 편집";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.message_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_01_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_03_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_02_id)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.act_04_id)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textbox;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown message_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown act_01_id;
        private System.Windows.Forms.NumericUpDown act_03_id;
        private System.Windows.Forms.NumericUpDown act_02_id;
        private System.Windows.Forms.NumericUpDown act_04_id;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox buttonCheckBox;
    }
}
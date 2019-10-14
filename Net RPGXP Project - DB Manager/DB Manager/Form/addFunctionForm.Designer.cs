namespace DB_Manager
{
    partial class addFunctionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.func_index_numbox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.func_name_textbox = new System.Windows.Forms.TextBox();
            this.func_action_numbox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.func_index_numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.func_action_numbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "함수 호출 식별 번호";
            // 
            // func_index_numbox
            // 
            this.func_index_numbox.Location = new System.Drawing.Point(12, 24);
            this.func_index_numbox.Name = "func_index_numbox";
            this.func_index_numbox.Size = new System.Drawing.Size(120, 21);
            this.func_index_numbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "실행할 함수명";
            // 
            // func_name_textbox
            // 
            this.func_name_textbox.Location = new System.Drawing.Point(12, 72);
            this.func_name_textbox.Name = "func_name_textbox";
            this.func_name_textbox.Size = new System.Drawing.Size(171, 21);
            this.func_name_textbox.TabIndex = 3;
            // 
            // func_action_numbox
            // 
            this.func_action_numbox.Location = new System.Drawing.Point(12, 121);
            this.func_action_numbox.Name = "func_action_numbox";
            this.func_action_numbox.Size = new System.Drawing.Size(120, 21);
            this.func_action_numbox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "실행할 액션 번호";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(12, 159);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 6;
            this.add_button.Text = "추가";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(110, 159);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "취소";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // addFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 194);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.func_action_numbox);
            this.Controls.Add(this.func_name_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.func_index_numbox);
            this.Controls.Add(this.label1);
            this.Name = "addFunctionForm";
            this.Text = "함수 추가";
            ((System.ComponentModel.ISupportInitialize)(this.func_index_numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.func_action_numbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown func_index_numbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox func_name_textbox;
        private System.Windows.Forms.NumericUpDown func_action_numbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
    }
}
namespace DB_Manager
{
    partial class addStoreForm
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
            this.store_index_numbox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.store_no_numbox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.action_numbox = new System.Windows.Forms.NumericUpDown();
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.store_index_numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_no_numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_numbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "상점 호출 번호";
            // 
            // store_index_numbox
            // 
            this.store_index_numbox.Location = new System.Drawing.Point(99, 12);
            this.store_index_numbox.Name = "store_index_numbox";
            this.store_index_numbox.Size = new System.Drawing.Size(120, 21);
            this.store_index_numbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "호출할 상점 식별 번호";
            // 
            // store_no_numbox
            // 
            this.store_no_numbox.Location = new System.Drawing.Point(10, 71);
            this.store_no_numbox.Name = "store_no_numbox";
            this.store_no_numbox.Size = new System.Drawing.Size(102, 21);
            this.store_no_numbox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "실행할 액션 번호";
            // 
            // action_numbox
            // 
            this.action_numbox.Location = new System.Drawing.Point(10, 120);
            this.action_numbox.Name = "action_numbox";
            this.action_numbox.Size = new System.Drawing.Size(102, 21);
            this.action_numbox.TabIndex = 5;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(10, 166);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(95, 23);
            this.add_button.TabIndex = 6;
            this.add_button.Text = "추가";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(128, 166);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(95, 23);
            this.cancel_button.TabIndex = 7;
            this.cancel_button.Text = "취소";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // addStoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 198);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.action_numbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.store_no_numbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.store_index_numbox);
            this.Controls.Add(this.label1);
            this.Name = "addStoreForm";
            this.Text = "상점 호출 추가";
            ((System.ComponentModel.ISupportInitialize)(this.store_index_numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.store_no_numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.action_numbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown store_index_numbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown store_no_numbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown action_numbox;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
    }
}
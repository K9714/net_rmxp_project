namespace DB_Manager
{
    partial class addEnemyPositionForm
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
            this.mapid_numbox = new System.Windows.Forms.NumericUpDown();
            this.x_numbox = new System.Windows.Forms.NumericUpDown();
            this.y_numbox = new System.Windows.Forms.NumericUpDown();
            this.add_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapid_numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_numbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_numbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map ID";
            // 
            // mapid_numbox
            // 
            this.mapid_numbox.Location = new System.Drawing.Point(11, 24);
            this.mapid_numbox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.mapid_numbox.Name = "mapid_numbox";
            this.mapid_numbox.Size = new System.Drawing.Size(82, 21);
            this.mapid_numbox.TabIndex = 1;
            // 
            // x_numbox
            // 
            this.x_numbox.Location = new System.Drawing.Point(99, 24);
            this.x_numbox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.x_numbox.Name = "x_numbox";
            this.x_numbox.Size = new System.Drawing.Size(82, 21);
            this.x_numbox.TabIndex = 2;
            // 
            // y_numbox
            // 
            this.y_numbox.Location = new System.Drawing.Point(187, 24);
            this.y_numbox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.y_numbox.Name = "y_numbox";
            this.y_numbox.Size = new System.Drawing.Size(82, 21);
            this.y_numbox.TabIndex = 3;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(12, 62);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(114, 23);
            this.add_button.TabIndex = 4;
            this.add_button.Text = "추가";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(155, 62);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(114, 23);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "취소";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Map X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Map Y";
            // 
            // addEnemyPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 96);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.y_numbox);
            this.Controls.Add(this.x_numbox);
            this.Controls.Add(this.mapid_numbox);
            this.Controls.Add(this.label1);
            this.Name = "addEnemyPositionForm";
            this.Text = "몬스터 위치 추가";
            ((System.ComponentModel.ISupportInitialize)(this.mapid_numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_numbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_numbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown mapid_numbox;
        private System.Windows.Forms.NumericUpDown x_numbox;
        private System.Windows.Forms.NumericUpDown y_numbox;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
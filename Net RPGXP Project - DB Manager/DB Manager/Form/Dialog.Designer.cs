namespace DB_Manager
{
    partial class Dialog
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
            this.input_textbox = new System.Windows.Forms.TextBox();
            this.dialog_button = new System.Windows.Forms.Button();
            this.textlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input_textbox
            // 
            this.input_textbox.Location = new System.Drawing.Point(14, 66);
            this.input_textbox.Name = "input_textbox";
            this.input_textbox.Size = new System.Drawing.Size(209, 21);
            this.input_textbox.TabIndex = 0;
            // 
            // dialog_button
            // 
            this.dialog_button.Location = new System.Drawing.Point(229, 64);
            this.dialog_button.Name = "dialog_button";
            this.dialog_button.Size = new System.Drawing.Size(75, 23);
            this.dialog_button.TabIndex = 1;
            this.dialog_button.Text = "입력";
            this.dialog_button.UseVisualStyleBackColor = true;
            this.dialog_button.Click += new System.EventHandler(this.dialog_button_Click);
            // 
            // textlabel
            // 
            this.textlabel.AutoSize = true;
            this.textlabel.Location = new System.Drawing.Point(12, 27);
            this.textlabel.Name = "textlabel";
            this.textlabel.Size = new System.Drawing.Size(52, 12);
            this.textlabel.TabIndex = 2;
            this.textlabel.Text = "textlabel";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 99);
            this.Controls.Add(this.textlabel);
            this.Controls.Add(this.dialog_button);
            this.Controls.Add(this.input_textbox);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_textbox;
        private System.Windows.Forms.Button dialog_button;
        private System.Windows.Forms.Label textlabel;
    }
}
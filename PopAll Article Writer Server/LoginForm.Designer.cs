namespace PopAll_Article_Writer_Server
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.tb_serial = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.tm_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tb_serial
            // 
            this.tb_serial.Location = new System.Drawing.Point(12, 12);
            this.tb_serial.Name = "tb_serial";
            this.tb_serial.ReadOnly = true;
            this.tb_serial.Size = new System.Drawing.Size(327, 21);
            this.tb_serial.TabIndex = 0;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(12, 45);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(142, 21);
            this.tb_name.TabIndex = 1;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(160, 39);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(179, 31);
            this.bt_send.TabIndex = 2;
            this.bt_send.Text = "Request";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // tm_timer
            // 
            this.tm_timer.Enabled = true;
            this.tm_timer.Interval = 3500;
            this.tm_timer.Tick += new System.EventHandler(this.tm_timer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(351, 82);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_serial);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "PopAll Article Writer Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_serial;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Timer tm_timer;
    }
}
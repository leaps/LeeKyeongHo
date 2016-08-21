namespace PopAll_Article_Writer_Server
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_main = new System.Windows.Forms.TabControl();
            this.tp_1 = new System.Windows.Forms.TabPage();
            this.lv_login = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tp_2 = new System.Windows.Forms.TabPage();
            this.lv_vpn = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tp_3 = new System.Windows.Forms.TabPage();
            this.lv_article = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tp_4 = new System.Windows.Forms.TabPage();
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_reset = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_article = new System.Windows.Forms.Button();
            this.bt_vpn = new System.Windows.Forms.Button();
            this.bt_id = new System.Windows.Forms.Button();
            this.tb_article = new System.Windows.Forms.TextBox();
            this.tb_vpn = new System.Windows.Forms.TextBox();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tc_main.SuspendLayout();
            this.tp_1.SuspendLayout();
            this.tp_2.SuspendLayout();
            this.tp_3.SuspendLayout();
            this.tp_4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_1);
            this.tc_main.Controls.Add(this.tp_2);
            this.tc_main.Controls.Add(this.tp_3);
            this.tc_main.Controls.Add(this.tp_4);
            this.tc_main.Location = new System.Drawing.Point(12, 15);
            this.tc_main.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(554, 308);
            this.tc_main.TabIndex = 0;
            // 
            // tp_1
            // 
            this.tp_1.Controls.Add(this.lv_login);
            this.tp_1.Location = new System.Drawing.Point(4, 24);
            this.tp_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_1.Name = "tp_1";
            this.tp_1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_1.Size = new System.Drawing.Size(546, 280);
            this.tp_1.TabIndex = 0;
            this.tp_1.Text = "ID";
            this.tp_1.UseVisualStyleBackColor = true;
            // 
            // lv_login
            // 
            this.lv_login.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lv_login.Location = new System.Drawing.Point(6, 7);
            this.lv_login.Name = "lv_login";
            this.lv_login.Size = new System.Drawing.Size(534, 266);
            this.lv_login.TabIndex = 0;
            this.lv_login.UseCompatibleStateImageBehavior = false;
            this.lv_login.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "State";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Condition";
            this.columnHeader9.Width = 120;
            // 
            // tp_2
            // 
            this.tp_2.Controls.Add(this.lv_vpn);
            this.tp_2.Location = new System.Drawing.Point(4, 24);
            this.tp_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_2.Name = "tp_2";
            this.tp_2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_2.Size = new System.Drawing.Size(546, 280);
            this.tp_2.TabIndex = 1;
            this.tp_2.Text = "VPN";
            this.tp_2.UseVisualStyleBackColor = true;
            // 
            // lv_vpn
            // 
            this.lv_vpn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_vpn.Location = new System.Drawing.Point(6, 7);
            this.lv_vpn.Name = "lv_vpn";
            this.lv_vpn.Size = new System.Drawing.Size(534, 270);
            this.lv_vpn.TabIndex = 0;
            this.lv_vpn.UseCompatibleStateImageBehavior = false;
            this.lv_vpn.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IP";
            this.columnHeader3.Width = 309;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Uid";
            this.columnHeader4.Width = 98;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PW";
            this.columnHeader5.Width = 109;
            // 
            // tp_3
            // 
            this.tp_3.Controls.Add(this.lv_article);
            this.tp_3.Location = new System.Drawing.Point(4, 24);
            this.tp_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_3.Name = "tp_3";
            this.tp_3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_3.Size = new System.Drawing.Size(546, 280);
            this.tp_3.TabIndex = 2;
            this.tp_3.Text = "Article";
            this.tp_3.UseVisualStyleBackColor = true;
            // 
            // lv_article
            // 
            this.lv_article.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lv_article.Location = new System.Drawing.Point(6, 7);
            this.lv_article.Name = "lv_article";
            this.lv_article.Size = new System.Drawing.Size(534, 266);
            this.lv_article.TabIndex = 0;
            this.lv_article.UseCompatibleStateImageBehavior = false;
            this.lv_article.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Title";
            this.columnHeader6.Width = 265;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Body";
            this.columnHeader7.Width = 248;
            // 
            // tp_4
            // 
            this.tp_4.Controls.Add(this.bt_stop);
            this.tp_4.Controls.Add(this.bt_start);
            this.tp_4.Controls.Add(this.bt_reset);
            this.tp_4.Controls.Add(this.bt_save);
            this.tp_4.Controls.Add(this.bt_article);
            this.tp_4.Controls.Add(this.bt_vpn);
            this.tp_4.Controls.Add(this.bt_id);
            this.tp_4.Controls.Add(this.tb_article);
            this.tp_4.Controls.Add(this.tb_vpn);
            this.tp_4.Controls.Add(this.tb_id);
            this.tp_4.Location = new System.Drawing.Point(4, 24);
            this.tp_4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_4.Name = "tp_4";
            this.tp_4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp_4.Size = new System.Drawing.Size(546, 280);
            this.tp_4.TabIndex = 3;
            this.tp_4.Text = "Setting";
            this.tp_4.UseVisualStyleBackColor = true;
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(152, 250);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(140, 23);
            this.bt_stop.TabIndex = 9;
            this.bt_stop.Text = "중지";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(6, 250);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(140, 23);
            this.bt_start.TabIndex = 8;
            this.bt_start.Text = "시작";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(406, 94);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(134, 23);
            this.bt_reset.TabIndex = 7;
            this.bt_reset.Text = "초기화";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(266, 94);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(134, 23);
            this.bt_save.TabIndex = 6;
            this.bt_save.Text = "저장";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_article
            // 
            this.bt_article.Location = new System.Drawing.Point(456, 65);
            this.bt_article.Name = "bt_article";
            this.bt_article.Size = new System.Drawing.Size(84, 23);
            this.bt_article.TabIndex = 5;
            this.bt_article.Text = "글 찾기";
            this.bt_article.UseVisualStyleBackColor = true;
            this.bt_article.Click += new System.EventHandler(this.bt_article_Click);
            // 
            // bt_vpn
            // 
            this.bt_vpn.Location = new System.Drawing.Point(456, 36);
            this.bt_vpn.Name = "bt_vpn";
            this.bt_vpn.Size = new System.Drawing.Size(84, 23);
            this.bt_vpn.TabIndex = 3;
            this.bt_vpn.Text = "VPN 찾기";
            this.bt_vpn.UseVisualStyleBackColor = true;
            this.bt_vpn.Click += new System.EventHandler(this.bt_vpn_Click);
            // 
            // bt_id
            // 
            this.bt_id.Location = new System.Drawing.Point(456, 7);
            this.bt_id.Name = "bt_id";
            this.bt_id.Size = new System.Drawing.Size(84, 23);
            this.bt_id.TabIndex = 1;
            this.bt_id.Text = "계정 찾기";
            this.bt_id.UseVisualStyleBackColor = true;
            this.bt_id.Click += new System.EventHandler(this.bt_id_Click);
            // 
            // tb_article
            // 
            this.tb_article.Location = new System.Drawing.Point(6, 65);
            this.tb_article.Name = "tb_article";
            this.tb_article.Size = new System.Drawing.Size(444, 23);
            this.tb_article.TabIndex = 4;
            // 
            // tb_vpn
            // 
            this.tb_vpn.Location = new System.Drawing.Point(6, 36);
            this.tb_vpn.Name = "tb_vpn";
            this.tb_vpn.Size = new System.Drawing.Size(444, 23);
            this.tb_vpn.TabIndex = 2;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(6, 7);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(444, 23);
            this.tb_id.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Time";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "mnl",
            "jlhlj",
            "jhkjh",
            "hjfgjg",
            "hfutyf"});
            this.comboBox1.Location = new System.Drawing.Point(424, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(578, 336);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tc_main);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tc_main.ResumeLayout(false);
            this.tp_1.ResumeLayout(false);
            this.tp_2.ResumeLayout(false);
            this.tp_3.ResumeLayout(false);
            this.tp_4.ResumeLayout(false);
            this.tp_4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_main;
        private System.Windows.Forms.TabPage tp_1;
        private System.Windows.Forms.ListView lv_login;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tp_2;
        private System.Windows.Forms.ListView lv_vpn;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage tp_3;
        private System.Windows.Forms.TabPage tp_4;
        private System.Windows.Forms.ListView lv_article;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_article;
        private System.Windows.Forms.Button bt_vpn;
        private System.Windows.Forms.Button bt_id;
        private System.Windows.Forms.TextBox tb_article;
        private System.Windows.Forms.TextBox tb_vpn;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}


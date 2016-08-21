namespace PopAll_Article_Writer_Server
{
    partial class MainForm
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
            this.gb_list = new System.Windows.Forms.GroupBox();
            this.lv_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_stand = new System.Windows.Forms.Label();
            this.tb_stand = new System.Windows.Forms.TextBox();
            this.lb_timer = new System.Windows.Forms.Label();
            this.tb_timer = new System.Windows.Forms.TextBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.lv_log = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.tb_body = new System.Windows.Forms.TextBox();
            this.lv_id = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cm_id = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.계정불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_list.SuspendLayout();
            this.cm_id.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_list
            // 
            this.gb_list.Controls.Add(this.lv_list);
            this.gb_list.Location = new System.Drawing.Point(247, 13);
            this.gb_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_list.Name = "gb_list";
            this.gb_list.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_list.Size = new System.Drawing.Size(668, 306);
            this.gb_list.TabIndex = 0;
            this.gb_list.TabStop = false;
            this.gb_list.Text = "Client List";
            // 
            // lv_list
            // 
            this.lv_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_list.GridLines = true;
            this.lv_list.Location = new System.Drawing.Point(6, 24);
            this.lv_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_list.Name = "lv_list";
            this.lv_list.Size = new System.Drawing.Size(656, 274);
            this.lv_list.TabIndex = 1;
            this.lv_list.UseCompatibleStateImageBehavior = false;
            this.lv_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Condition";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.Width = 130;
            // 
            // lb_stand
            // 
            this.lb_stand.AutoSize = true;
            this.lb_stand.Location = new System.Drawing.Point(9, 421);
            this.lb_stand.Name = "lb_stand";
            this.lb_stand.Size = new System.Drawing.Size(89, 15);
            this.lb_stand.TabIndex = 3;
            this.lb_stand.Text = "Stand by Login";
            // 
            // tb_stand
            // 
            this.tb_stand.Location = new System.Drawing.Point(104, 418);
            this.tb_stand.Name = "tb_stand";
            this.tb_stand.Size = new System.Drawing.Size(46, 23);
            this.tb_stand.TabIndex = 4;
            this.tb_stand.Text = "10";
            // 
            // lb_timer
            // 
            this.lb_timer.AutoSize = true;
            this.lb_timer.Location = new System.Drawing.Point(35, 450);
            this.lb_timer.Name = "lb_timer";
            this.lb_timer.Size = new System.Drawing.Size(37, 15);
            this.lb_timer.TabIndex = 5;
            this.lb_timer.Text = "Timer";
            // 
            // tb_timer
            // 
            this.tb_timer.Location = new System.Drawing.Point(104, 447);
            this.tb_timer.Name = "tb_timer";
            this.tb_timer.Size = new System.Drawing.Size(46, 23);
            this.tb_timer.TabIndex = 6;
            this.tb_timer.Text = "20";
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(12, 480);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 7;
            this.bt_start.Text = "Start";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.Enabled = false;
            this.bt_stop.Location = new System.Drawing.Point(93, 480);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 23);
            this.bt_stop.TabIndex = 8;
            this.bt_stop.Text = "Stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // lv_log
            // 
            this.lv_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lv_log.GridLines = true;
            this.lv_log.Location = new System.Drawing.Point(409, 326);
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(506, 177);
            this.lv_log.TabIndex = 9;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Time";
            this.columnHeader6.Width = 115;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IP";
            this.columnHeader7.Width = 122;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 122;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Result";
            this.columnHeader9.Width = 130;
            // 
            // tb_subject
            // 
            this.tb_subject.Location = new System.Drawing.Point(12, 23);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(229, 23);
            this.tb_subject.TabIndex = 1;
            // 
            // tb_body
            // 
            this.tb_body.Location = new System.Drawing.Point(12, 52);
            this.tb_body.Multiline = true;
            this.tb_body.Name = "tb_body";
            this.tb_body.Size = new System.Drawing.Size(229, 267);
            this.tb_body.TabIndex = 2;
            // 
            // lv_id
            // 
            this.lv_id.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10});
            this.lv_id.ContextMenuStrip = this.cm_id;
            this.lv_id.Location = new System.Drawing.Point(247, 326);
            this.lv_id.Name = "lv_id";
            this.lv_id.Size = new System.Drawing.Size(156, 177);
            this.lv_id.TabIndex = 0;
            this.lv_id.UseCompatibleStateImageBehavior = false;
            this.lv_id.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID/PW";
            this.columnHeader10.Width = 138;
            // 
            // cm_id
            // 
            this.cm_id.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.계정불러오기ToolStripMenuItem});
            this.cm_id.Name = "cm_id";
            this.cm_id.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cm_id.Size = new System.Drawing.Size(151, 26);
            // 
            // 계정불러오기ToolStripMenuItem
            // 
            this.계정불러오기ToolStripMenuItem.Name = "계정불러오기ToolStripMenuItem";
            this.계정불러오기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.계정불러오기ToolStripMenuItem.Text = "계정 불러오기";
            this.계정불러오기ToolStripMenuItem.Click += new System.EventHandler(this.계정불러오기ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(927, 515);
            this.Controls.Add(this.lv_id);
            this.Controls.Add(this.tb_body);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.lv_log);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.lb_timer);
            this.Controls.Add(this.tb_timer);
            this.Controls.Add(this.gb_list);
            this.Controls.Add(this.tb_stand);
            this.Controls.Add(this.lb_stand);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PopAll Article Writer Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gb_list.ResumeLayout(false);
            this.cm_id.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_list;
        private System.Windows.Forms.ListView lv_list;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lb_stand;
        private System.Windows.Forms.TextBox tb_stand;
        private System.Windows.Forms.Label lb_timer;
        private System.Windows.Forms.TextBox tb_timer;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.ListView lv_log;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.TextBox tb_body;
        private System.Windows.Forms.ListView lv_id;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ContextMenuStrip cm_id;
        private System.Windows.Forms.ToolStripMenuItem 계정불러오기ToolStripMenuItem;
    }
}
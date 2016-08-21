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
            this.gb_list = new System.Windows.Forms.GroupBox();
            this.lv_list = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_indexon = new System.Windows.Forms.Button();
            this.lb_stand = new System.Windows.Forms.Label();
            this.tb_stand = new System.Windows.Forms.TextBox();
            this.lb_timer = new System.Windows.Forms.Label();
            this.tb_timer = new System.Windows.Forms.TextBox();
            this.bt_indexoff = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gb_list.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_list
            // 
            this.gb_list.Controls.Add(this.lv_list);
            this.gb_list.Location = new System.Drawing.Point(12, 13);
            this.gb_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_list.Name = "gb_list";
            this.gb_list.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gb_list.Size = new System.Drawing.Size(639, 306);
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
            this.lv_list.Size = new System.Drawing.Size(627, 274);
            this.lv_list.TabIndex = 1;
            this.lv_list.UseCompatibleStateImageBehavior = false;
            this.lv_list.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 160;
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
            this.columnHeader4.Width = 118;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time";
            this.columnHeader5.Width = 129;
            // 
            // bt_indexon
            // 
            this.bt_indexon.Location = new System.Drawing.Point(12, 326);
            this.bt_indexon.Name = "bt_indexon";
            this.bt_indexon.Size = new System.Drawing.Size(75, 23);
            this.bt_indexon.TabIndex = 0;
            this.bt_indexon.Text = "FTP ON";
            this.bt_indexon.UseVisualStyleBackColor = true;
            // 
            // lb_stand
            // 
            this.lb_stand.AutoSize = true;
            this.lb_stand.Location = new System.Drawing.Point(9, 361);
            this.lb_stand.Name = "lb_stand";
            this.lb_stand.Size = new System.Drawing.Size(89, 15);
            this.lb_stand.TabIndex = 2;
            this.lb_stand.Text = "Stand by Login";
            // 
            // tb_stand
            // 
            this.tb_stand.Location = new System.Drawing.Point(104, 358);
            this.tb_stand.Name = "tb_stand";
            this.tb_stand.Size = new System.Drawing.Size(46, 23);
            this.tb_stand.TabIndex = 3;
            // 
            // lb_timer
            // 
            this.lb_timer.AutoSize = true;
            this.lb_timer.Location = new System.Drawing.Point(35, 390);
            this.lb_timer.Name = "lb_timer";
            this.lb_timer.Size = new System.Drawing.Size(37, 15);
            this.lb_timer.TabIndex = 4;
            this.lb_timer.Text = "Timer";
            // 
            // tb_timer
            // 
            this.tb_timer.Location = new System.Drawing.Point(104, 387);
            this.tb_timer.Name = "tb_timer";
            this.tb_timer.Size = new System.Drawing.Size(46, 23);
            this.tb_timer.TabIndex = 5;
            // 
            // bt_indexoff
            // 
            this.bt_indexoff.Location = new System.Drawing.Point(93, 326);
            this.bt_indexoff.Name = "bt_indexoff";
            this.bt_indexoff.Size = new System.Drawing.Size(75, 23);
            this.bt_indexoff.TabIndex = 1;
            this.bt_indexoff.Text = "FTP OFF";
            this.bt_indexoff.UseVisualStyleBackColor = true;
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(12, 420);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 6;
            this.bt_start.Text = "Start";
            this.bt_start.UseVisualStyleBackColor = true;
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(93, 420);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 23);
            this.bt_stop.TabIndex = 7;
            this.bt_stop.Text = "Stop";
            this.bt_stop.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(174, 326);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(477, 177);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(663, 515);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.bt_indexoff);
            this.Controls.Add(this.lb_timer);
            this.Controls.Add(this.tb_timer);
            this.Controls.Add(this.gb_list);
            this.Controls.Add(this.tb_stand);
            this.Controls.Add(this.bt_indexon);
            this.Controls.Add(this.lb_stand);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PopAll Article Writer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gb_list.ResumeLayout(false);
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
        private System.Windows.Forms.Button bt_indexon;
        private System.Windows.Forms.Label lb_stand;
        private System.Windows.Forms.TextBox tb_stand;
        private System.Windows.Forms.Label lb_timer;
        private System.Windows.Forms.TextBox tb_timer;
        private System.Windows.Forms.Button bt_indexoff;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.ListView listView1;
    }
}
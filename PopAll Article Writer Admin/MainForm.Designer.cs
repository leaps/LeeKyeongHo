namespace PopAll_Article_Writer_Admin
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
            this.components = new System.ComponentModel.Container();
            this.lv_request = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cm_request = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refusalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lv_ok = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cm_ok = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bt_refresh = new System.Windows.Forms.Button();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cm_request.SuspendLayout();
            this.cm_ok.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_request
            // 
            this.lv_request.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_request.ContextMenuStrip = this.cm_request;
            this.lv_request.GridLines = true;
            this.lv_request.Location = new System.Drawing.Point(12, 15);
            this.lv_request.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_request.Name = "lv_request";
            this.lv_request.Size = new System.Drawing.Size(365, 232);
            this.lv_request.TabIndex = 0;
            this.lv_request.UseCompatibleStateImageBehavior = false;
            this.lv_request.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "HDD Serial";
            this.columnHeader2.Width = 182;
            // 
            // cm_request
            // 
            this.cm_request.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceptToolStripMenuItem,
            this.refusalToolStripMenuItem});
            this.cm_request.Name = "cm_request";
            this.cm_request.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cm_request.Size = new System.Drawing.Size(113, 48);
            // 
            // acceptToolStripMenuItem
            // 
            this.acceptToolStripMenuItem.Name = "acceptToolStripMenuItem";
            this.acceptToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.acceptToolStripMenuItem.Text = "Accept";
            this.acceptToolStripMenuItem.Click += new System.EventHandler(this.acceptToolStripMenuItem_Click);
            // 
            // refusalToolStripMenuItem
            // 
            this.refusalToolStripMenuItem.Name = "refusalToolStripMenuItem";
            this.refusalToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.refusalToolStripMenuItem.Text = "Refusal";
            this.refusalToolStripMenuItem.Click += new System.EventHandler(this.refusalToolStripMenuItem_Click);
            // 
            // lv_ok
            // 
            this.lv_ok.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lv_ok.ContextMenuStrip = this.cm_ok;
            this.lv_ok.GridLines = true;
            this.lv_ok.Location = new System.Drawing.Point(383, 15);
            this.lv_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv_ok.Name = "lv_ok";
            this.lv_ok.Size = new System.Drawing.Size(365, 232);
            this.lv_ok.TabIndex = 1;
            this.lv_ok.UseCompatibleStateImageBehavior = false;
            this.lv_ok.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 170;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "HDD Serial";
            this.columnHeader4.Width = 182;
            // 
            // cm_ok
            // 
            this.cm_ok.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.cm_ok.Name = "cm_ok";
            this.cm_ok.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cm_ok.Size = new System.Drawing.Size(153, 48);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(12, 254);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(736, 42);
            this.bt_refresh.TabIndex = 4;
            this.bt_refresh.Text = "Refresh";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(760, 308);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.lv_ok);
            this.Controls.Add(this.lv_request);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PopAll Article Writer Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cm_request.ResumeLayout(false);
            this.cm_ok.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_request;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lv_ok;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip cm_request;
        private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refusalToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cm_ok;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}


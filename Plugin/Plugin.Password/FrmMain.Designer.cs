namespace Plugin.Password
{
    partial class FrmMain
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
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn1 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn2 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn3 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn4 = new DSkin.Controls.DSkinGridListColumn();
            DSkin.Controls.DSkinGridListColumn dSkinGridListColumn5 = new DSkin.Controls.DSkinGridListColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dSkinTreeView1 = new DSkin.Controls.DSkinTreeView();
            this.dSkinContextMenuStrip1 = new DSkin.Controls.DSkinContextMenuStrip();
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSkinGridList1 = new DSkin.Controls.DSkinGridList();
            this.dSkinContextMenuStrip2 = new DSkin.Controls.DSkinContextMenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinTreeView1)).BeginInit();
            this.dSkinContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSkinGridList1)).BeginInit();
            this.dSkinContextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinTreeView1
            // 
            this.dSkinTreeView1.BackColor = System.Drawing.Color.White;
            this.dSkinTreeView1.Borders.AllColor = System.Drawing.Color.Black;
            this.dSkinTreeView1.Borders.BottomColor = System.Drawing.Color.Black;
            this.dSkinTreeView1.Borders.LeftColor = System.Drawing.Color.Black;
            this.dSkinTreeView1.Borders.RightColor = System.Drawing.Color.Black;
            this.dSkinTreeView1.Borders.TopColor = System.Drawing.Color.Black;
            this.dSkinTreeView1.ContextMenuStrip = this.dSkinContextMenuStrip1;
            this.dSkinTreeView1.Location = new System.Drawing.Point(21, 37);
            this.dSkinTreeView1.Name = "dSkinTreeView1";
            this.dSkinTreeView1.ShowCheckBox = false;
            this.dSkinTreeView1.ShowIcon = false;
            this.dSkinTreeView1.Size = new System.Drawing.Size(137, 338);
            this.dSkinTreeView1.TabIndex = 0;
            this.dSkinTreeView1.Text = "dSkinTreeView1";
            this.dSkinTreeView1.SelectedNodeChanged += new System.EventHandler(this.dSkinTreeView1_SelectedNodeChanged);
            // 
            // dSkinContextMenuStrip1
            // 
            this.dSkinContextMenuStrip1.Arrow = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip1.Back = System.Drawing.Color.White;
            this.dSkinContextMenuStrip1.BackRadius = 4;
            this.dSkinContextMenuStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.dSkinContextMenuStrip1.CheckedImage = null;
            this.dSkinContextMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dSkinContextMenuStrip1.Fore = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.dSkinContextMenuStrip1.ItemAnamorphosis = true;
            this.dSkinContextMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip1.ItemBorderShow = true;
            this.dSkinContextMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip1.ItemRadius = 4;
            this.dSkinContextMenuStrip1.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.dSkinContextMenuStrip1.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip1.Name = "dSkinContextMenuStrip1";
            this.dSkinContextMenuStrip1.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            this.dSkinContextMenuStrip1.SkinAllColor = true;
            this.dSkinContextMenuStrip1.TitleAnamorphosis = true;
            this.dSkinContextMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.dSkinContextMenuStrip1.TitleRadius = 4;
            this.dSkinContextMenuStrip1.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新增ToolStripMenuItem.Text = "新增";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // dSkinGridList1
            // 
            // 
            // 
            // 
            this.dSkinGridList1.BackPageButton.AdaptImage = true;
            this.dSkinGridList1.BackPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList1.BackPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.BackPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList1.BackPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.BackPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.BackPageButton.Location = new System.Drawing.Point(386, 4);
            this.dSkinGridList1.BackPageButton.Name = "BtnBackPage";
            this.dSkinGridList1.BackPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList1.BackPageButton.Radius = 0;
            this.dSkinGridList1.BackPageButton.Size = new System.Drawing.Size(50, 24);
            this.dSkinGridList1.BackPageButton.Text = "上一页";
            this.dSkinGridList1.BackPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList1.BackPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList1.Borders.AllColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.Borders.BottomColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.Borders.LeftColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.Borders.RightColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.Borders.TopColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.ColumnFill = true;
            this.dSkinGridList1.ColumnHeight = 30;
            dSkinGridListColumn1.Name = "ID";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 81;
            dSkinGridListColumn2.Name = "标题";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = 81;
            dSkinGridListColumn3.Name = "用户名";
            dSkinGridListColumn3.Visble = true;
            dSkinGridListColumn3.Width = 81;
            dSkinGridListColumn4.Name = "链接";
            dSkinGridListColumn4.Visble = true;
            dSkinGridListColumn4.Width = 81;
            dSkinGridListColumn5.Name = "备注";
            dSkinGridListColumn5.Visble = true;
            dSkinGridListColumn5.Width = 84;
            this.dSkinGridList1.Columns.AddRange(new DSkin.Controls.DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2,
            dSkinGridListColumn3,
            dSkinGridListColumn4,
            dSkinGridListColumn5});
            this.dSkinGridList1.ContextMenuStrip = this.dSkinContextMenuStrip2;
            this.dSkinGridList1.DoubleItemsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dSkinGridList1.EnabledOrder = false;
            // 
            // 
            // 
            this.dSkinGridList1.FirstPageButton.AdaptImage = true;
            this.dSkinGridList1.FirstPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList1.FirstPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.FirstPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList1.FirstPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.FirstPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.FirstPageButton.Location = new System.Drawing.Point(338, 4);
            this.dSkinGridList1.FirstPageButton.Name = "BtnFistPage";
            this.dSkinGridList1.FirstPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList1.FirstPageButton.Radius = 0;
            this.dSkinGridList1.FirstPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList1.FirstPageButton.Text = "首页";
            this.dSkinGridList1.FirstPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList1.FirstPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // 
            // 
            this.dSkinGridList1.GoPageButton.AdaptImage = true;
            this.dSkinGridList1.GoPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList1.GoPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dSkinGridList1.GoPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList1.GoPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.GoPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.GoPageButton.Location = new System.Drawing.Point(290, 4);
            this.dSkinGridList1.GoPageButton.Name = "BtnGoPage";
            this.dSkinGridList1.GoPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList1.GoPageButton.Radius = 0;
            this.dSkinGridList1.GoPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList1.GoPageButton.Text = "跳转";
            this.dSkinGridList1.GoPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList1.GoPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList1.GridLineColor = System.Drawing.Color.Silver;
            this.dSkinGridList1.HeaderFont = new System.Drawing.Font("微软雅黑", 9F);
            // 
            // 
            // 
            this.dSkinGridList1.HScrollBar.AutoSize = false;
            this.dSkinGridList1.HScrollBar.Fillet = true;
            this.dSkinGridList1.HScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.HScrollBar.Location = new System.Drawing.Point(0, 56);
            this.dSkinGridList1.HScrollBar.Maximum = 390;
            this.dSkinGridList1.HScrollBar.Name = "";
            this.dSkinGridList1.HScrollBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.dSkinGridList1.HScrollBar.ScrollBarLenght = 10;
            this.dSkinGridList1.HScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.dSkinGridList1.HScrollBar.Size = new System.Drawing.Size(490, 12);
            this.dSkinGridList1.HScrollBar.Visible = false;
            // 
            // 
            // 
            this.dSkinGridList1.LastPageButton.AdaptImage = true;
            this.dSkinGridList1.LastPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList1.LastPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.LastPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList1.LastPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.LastPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.LastPageButton.Location = new System.Drawing.Point(494, 4);
            this.dSkinGridList1.LastPageButton.Name = "BtnLastPage";
            this.dSkinGridList1.LastPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList1.LastPageButton.Radius = 0;
            this.dSkinGridList1.LastPageButton.Size = new System.Drawing.Size(44, 24);
            this.dSkinGridList1.LastPageButton.Text = "末页";
            this.dSkinGridList1.LastPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList1.LastPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList1.Location = new System.Drawing.Point(164, 38);
            this.dSkinGridList1.Name = "dSkinGridList1";
            // 
            // 
            // 
            this.dSkinGridList1.NextPageButton.AdaptImage = true;
            this.dSkinGridList1.NextPageButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dSkinGridList1.NextPageButton.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.NextPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dSkinGridList1.NextPageButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.NextPageButton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dSkinGridList1.NextPageButton.Location = new System.Drawing.Point(440, 4);
            this.dSkinGridList1.NextPageButton.Name = "BtnNextPage";
            this.dSkinGridList1.NextPageButton.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(179)))));
            this.dSkinGridList1.NextPageButton.Radius = 0;
            this.dSkinGridList1.NextPageButton.Size = new System.Drawing.Size(50, 24);
            this.dSkinGridList1.NextPageButton.Text = "下一页";
            this.dSkinGridList1.NextPageButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinGridList1.NextPageButton.TextRenderMode = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.dSkinGridList1.SelectedItem = null;
            this.dSkinGridList1.Size = new System.Drawing.Size(490, 337);
            this.dSkinGridList1.TabIndex = 1;
            this.dSkinGridList1.Text = "dSkinGridList1";
            // 
            // 
            // 
            this.dSkinGridList1.VScrollBar.AutoSize = false;
            this.dSkinGridList1.VScrollBar.BitmapCache = true;
            this.dSkinGridList1.VScrollBar.Fillet = true;
            this.dSkinGridList1.VScrollBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinGridList1.VScrollBar.LargeChange = 1000;
            this.dSkinGridList1.VScrollBar.Location = new System.Drawing.Point(477, 1);
            this.dSkinGridList1.VScrollBar.Margin = new System.Windows.Forms.Padding(1);
            this.dSkinGridList1.VScrollBar.Maximum = 10000;
            this.dSkinGridList1.VScrollBar.Name = "";
            this.dSkinGridList1.VScrollBar.ScrollBarPartitionWidth = new System.Windows.Forms.Padding(5);
            this.dSkinGridList1.VScrollBar.Size = new System.Drawing.Size(12, 272);
            this.dSkinGridList1.VScrollBar.SmallChange = 500;
            this.dSkinGridList1.VScrollBar.Visible = false;
            this.dSkinGridList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dSkinGridList1_MouseDoubleClick);
            // 
            // dSkinContextMenuStrip2
            // 
            this.dSkinContextMenuStrip2.Arrow = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip2.Back = System.Drawing.Color.White;
            this.dSkinContextMenuStrip2.BackRadius = 4;
            this.dSkinContextMenuStrip2.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.dSkinContextMenuStrip2.CheckedImage = null;
            this.dSkinContextMenuStrip2.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.dSkinContextMenuStrip2.Fore = System.Drawing.Color.Black;
            this.dSkinContextMenuStrip2.HoverFore = System.Drawing.Color.White;
            this.dSkinContextMenuStrip2.ItemAnamorphosis = true;
            this.dSkinContextMenuStrip2.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip2.ItemBorderShow = true;
            this.dSkinContextMenuStrip2.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip2.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip2.ItemRadius = 4;
            this.dSkinContextMenuStrip2.ItemRadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.dSkinContextMenuStrip2.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.dSkinContextMenuStrip2.Name = "dSkinContextMenuStrip1";
            this.dSkinContextMenuStrip2.RadiusStyle = DSkin.Common.RoundStyle.All;
            this.dSkinContextMenuStrip2.Size = new System.Drawing.Size(101, 70);
            this.dSkinContextMenuStrip2.SkinAllColor = true;
            this.dSkinContextMenuStrip2.TitleAnamorphosis = true;
            this.dSkinContextMenuStrip2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.dSkinContextMenuStrip2.TitleRadius = 4;
            this.dSkinContextMenuStrip2.TitleRadiusStyle = DSkin.Common.RoundStyle.All;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "新增";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = "编辑";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem3.Text = "删除";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 397);
            this.Controls.Add(this.dSkinGridList1);
            this.Controls.Add(this.dSkinTreeView1);
            this.DoubleClickMaximized = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "密码管理";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinTreeView1)).EndInit();
            this.dSkinContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinGridList1)).EndInit();
            this.dSkinContextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinTreeView dSkinTreeView1;
        private DSkin.Controls.DSkinGridList dSkinGridList1;
        private DSkin.Controls.DSkinContextMenuStrip dSkinContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DSkin.Controls.DSkinContextMenuStrip dSkinContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}
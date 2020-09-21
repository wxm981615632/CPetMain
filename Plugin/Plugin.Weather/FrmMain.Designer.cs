namespace Plugin.Weather
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.置顶ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSkinPictureBox1 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel4 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel5 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel6 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel1 = new DSkin.Controls.DSkinPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.置顶ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 置顶ToolStripMenuItem
            // 
            this.置顶ToolStripMenuItem.Checked = true;
            this.置顶ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.置顶ToolStripMenuItem.Name = "置顶ToolStripMenuItem";
            this.置顶ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.置顶ToolStripMenuItem.Text = "置顶";
            this.置顶ToolStripMenuItem.Click += new System.EventHandler(this.置顶ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // dSkinPictureBox1
            // 
            this.dSkinPictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinPictureBox1.Image = null;
            this.dSkinPictureBox1.Images = null;
            this.dSkinPictureBox1.Location = new System.Drawing.Point(101, 3);
            this.dSkinPictureBox1.Name = "dSkinPictureBox1";
            this.dSkinPictureBox1.Size = new System.Drawing.Size(92, 69);
            this.dSkinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dSkinPictureBox1.TabIndex = 2;
            this.dSkinPictureBox1.Text = "dSkinPictureBox1";
            this.dSkinPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinPictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinPictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel1.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel1.Location = new System.Drawing.Point(7, 73);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(45, 21);
            this.dSkinLabel1.TabIndex = 5;
            this.dSkinLabel1.Text = "09-01";
            this.dSkinLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel1.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel1.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel2.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel2.Location = new System.Drawing.Point(61, 73);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(48, 21);
            this.dSkinLabel2.TabIndex = 6;
            this.dSkinLabel2.Text = "星期六";
            this.dSkinLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel2.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel2.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel3
            // 
            this.dSkinLabel3.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel3.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel3.Location = new System.Drawing.Point(115, 73);
            this.dSkinLabel3.Name = "dSkinLabel3";
            this.dSkinLabel3.Size = new System.Drawing.Size(63, 21);
            this.dSkinLabel3.TabIndex = 7;
            this.dSkinLabel3.Text = "七月十四";
            this.dSkinLabel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel3.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel3.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel4
            // 
            this.dSkinLabel4.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel4.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel4.Location = new System.Drawing.Point(7, 91);
            this.dSkinLabel4.Name = "dSkinLabel4";
            this.dSkinLabel4.Size = new System.Drawing.Size(100, 21);
            this.dSkinLabel4.TabIndex = 8;
            this.dSkinLabel4.Text = "阴    35 ~25℃";
            this.dSkinLabel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel4.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel4.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel5
            // 
            this.dSkinLabel5.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel5.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel5.Location = new System.Drawing.Point(8, 109);
            this.dSkinLabel5.Name = "dSkinLabel5";
            this.dSkinLabel5.Size = new System.Drawing.Size(63, 21);
            this.dSkinLabel5.TabIndex = 9;
            this.dSkinLabel5.Text = "东风微风";
            this.dSkinLabel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel5.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel5.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinLabel6
            // 
            this.dSkinLabel6.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.dSkinLabel6.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel6.Location = new System.Drawing.Point(8, 128);
            this.dSkinLabel6.Name = "dSkinLabel6";
            this.dSkinLabel6.Size = new System.Drawing.Size(117, 21);
            this.dSkinLabel6.TabIndex = 10;
            this.dSkinLabel6.Text = "更新时间    01:15";
            this.dSkinLabel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinLabel6.MouseLeave += new System.EventHandler(this.hide1);
            this.dSkinLabel6.MouseHover += new System.EventHandler(this.show1);
            this.dSkinLabel6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinLabel6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // dSkinPanel1
            // 
            this.dSkinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dSkinPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dSkinPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.dSkinPanel1.Location = new System.Drawing.Point(5, 69);
            this.dSkinPanel1.Name = "dSkinPanel1";
            this.dSkinPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel1.RightBottom")));
            this.dSkinPanel1.Size = new System.Drawing.Size(187, 1);
            this.dSkinPanel1.TabIndex = 11;
            this.dSkinPanel1.Text = "dSkinPanel1";
            this.dSkinPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.dSkinPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.dSkinPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "余杭";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "28";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(65, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 27);
            this.label3.TabIndex = 14;
            this.label3.Text = "℃";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AllowDrop = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CanResize = false;
            this.CaptionShowMode = DSkin.TextShowModes.None;
            this.ClientSize = new System.Drawing.Size(200, 150);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dSkinPanel1);
            this.Controls.Add(this.dSkinPictureBox1);
            this.Controls.Add(this.dSkinLabel6);
            this.Controls.Add(this.dSkinLabel5);
            this.Controls.Add(this.dSkinLabel4);
            this.Controls.Add(this.dSkinLabel3);
            this.Controls.Add(this.dSkinLabel2);
            this.Controls.Add(this.dSkinLabel1);
            this.DoubleClickMaximized = false;
            this.DragChangeBackImage = false;
            this.DrawIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MoveMode = DSkin.Forms.MoveModes.None;
            this.Name = "FrmMain";
            this.Opacity = 0.8D;
            this.Radius = 10;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ShowSystemButtons = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmMain";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.down);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.move);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.up);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 置顶ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox1;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
        private DSkin.Controls.DSkinLabel dSkinLabel4;
        private DSkin.Controls.DSkinLabel dSkinLabel5;
        private DSkin.Controls.DSkinLabel dSkinLabel6;
        private DSkin.Controls.DSkinPanel dSkinPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
    }
}
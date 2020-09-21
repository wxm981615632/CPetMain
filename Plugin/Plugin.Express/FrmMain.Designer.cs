namespace Plugin.Express
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dSkinTextBox1 = new DSkin.Controls.DSkinTextBox();
            this.dcSkinComboBox1 = new DSkin.Controls.DCSkinComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinDataGridView1 = new DSkin.Controls.DSkinDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSkinButton1 = new DSkin.Controls.DSkinButton();
            this.dSkinToolTip1 = new DSkin.Controls.DSkinToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dSkinTextBox1
            // 
            this.dSkinTextBox1.BitmapCache = false;
            this.dSkinTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinTextBox1.Location = new System.Drawing.Point(183, 49);
            this.dSkinTextBox1.Name = "dSkinTextBox1";
            this.dSkinTextBox1.Size = new System.Drawing.Size(256, 29);
            this.dSkinTextBox1.TabIndex = 0;
            this.dSkinTextBox1.TransparencyKey = System.Drawing.Color.Empty;
            this.dSkinTextBox1.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinTextBox1.WaterText = "";
            this.dSkinTextBox1.WaterTextOffset = new System.Drawing.Point(0, 0);
            this.dSkinTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dSkinTextBox1_KeyDown);
            // 
            // dcSkinComboBox1
            // 
            this.dcSkinComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dcSkinComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dcSkinComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcSkinComboBox1.FormattingEnabled = true;
            this.dcSkinComboBox1.Location = new System.Drawing.Point(20, 49);
            this.dcSkinComboBox1.Name = "dcSkinComboBox1";
            this.dcSkinComboBox1.Size = new System.Drawing.Size(157, 30);
            this.dcSkinComboBox1.TabIndex = 1;
            this.dcSkinComboBox1.WaterText = "";
            this.dcSkinComboBox1.SelectedIndexChanged += new System.EventHandler(this.dcSkinComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.ForeColor = System.Drawing.Color.Red;
            this.dSkinLabel1.Location = new System.Drawing.Point(20, 370);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(93, 21);
            this.dSkinLabel1.TabIndex = 10;
            this.dSkinLabel1.Text = "dSkinLabel1";
            // 
            // dSkinDataGridView1
            // 
            this.dSkinDataGridView1.AllowUserToAddRows = false;
            this.dSkinDataGridView1.AllowUserToDeleteRows = false;
            this.dSkinDataGridView1.AlternatingCellBackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            this.dSkinDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dSkinDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dSkinDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dSkinDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dSkinDataGridView1.ColumnFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dSkinDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dSkinDataGridView1.ColumnHeadersHeight = 30;
            this.dSkinDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dSkinDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dSkinDataGridView1.ColumnSelectBackColor = System.Drawing.Color.LightSkyBlue;
            this.dSkinDataGridView1.ColumnSelectForeColor = System.Drawing.Color.Black;
            this.dSkinDataGridView1.DefaultCellBackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dSkinDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dSkinDataGridView1.EnableHeadersVisualStyles = false;
            this.dSkinDataGridView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinDataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dSkinDataGridView1.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinDataGridView1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.dSkinDataGridView1.Location = new System.Drawing.Point(20, 94);
            this.dSkinDataGridView1.MouseCellBackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dSkinDataGridView1.Name = "dSkinDataGridView1";
            this.dSkinDataGridView1.ReadOnly = true;
            this.dSkinDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dSkinDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dSkinDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dSkinDataGridView1.RowTemplate.Height = 30;
            this.dSkinDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dSkinDataGridView1.ShowCellErrors = false;
            this.dSkinDataGridView1.ShowCellToolTips = false;
            this.dSkinDataGridView1.ShowEditingIcon = false;
            this.dSkinDataGridView1.ShowRowErrors = false;
            this.dSkinDataGridView1.Size = new System.Drawing.Size(495, 270);
            this.dSkinDataGridView1.SkinGridColor = System.Drawing.Color.Silver;
            this.dSkinDataGridView1.TabIndex = 11;
            this.dSkinDataGridView1.TitleBack = null;
            this.dSkinDataGridView1.TitleBackColorBegin = System.Drawing.Color.White;
            this.dSkinDataGridView1.TitleBackColorEnd = System.Drawing.Color.WhiteSmoke;
            this.dSkinDataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dSkinDataGridView1_CellMouseEnter);
            this.dSkinDataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dSkinDataGridView1_CellMouseLeave);
            this.dSkinDataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dSkinDataGridView1_Scroll);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dSkinButton1
            // 
            this.dSkinButton1.ButtonBorderWidth = 1;
            this.dSkinButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dSkinButton1.HoverColor = System.Drawing.Color.Empty;
            this.dSkinButton1.HoverImage = null;
            this.dSkinButton1.Location = new System.Drawing.Point(445, 48);
            this.dSkinButton1.Name = "dSkinButton1";
            this.dSkinButton1.NormalImage = null;
            this.dSkinButton1.PressColor = System.Drawing.Color.Empty;
            this.dSkinButton1.PressedImage = null;
            this.dSkinButton1.Radius = 10;
            this.dSkinButton1.ShowButtonBorder = true;
            this.dSkinButton1.Size = new System.Drawing.Size(70, 31);
            this.dSkinButton1.TabIndex = 12;
            this.dSkinButton1.Text = "查询";
            this.dSkinButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dSkinButton1.TextPadding = 0;
            this.dSkinButton1.Click += new System.EventHandler(this.dSkinButton1_Click);
            // 
            // dSkinToolTip1
            // 
            this.dSkinToolTip1.AutoPopDelay = 5000;
            this.dSkinToolTip1.InitialDelay = 500;
            this.dSkinToolTip1.IsBalloon = true;
            this.dSkinToolTip1.OwnerDraw = true;
            this.dSkinToolTip1.ReshowDelay = 800;
            this.dSkinToolTip1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 403);
            this.Controls.Add(this.dSkinButton1);
            this.Controls.Add(this.dSkinDataGridView1);
            this.Controls.Add(this.dSkinLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dcSkinComboBox1);
            this.Controls.Add(this.dSkinTextBox1);
            this.DoubleClickMaximized = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "快递查询";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSkinDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSkin.Controls.DSkinTextBox dSkinTextBox1;
        private DSkin.Controls.DCSkinComboBox dcSkinComboBox1;
        private System.Windows.Forms.Button button1;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinDataGridView dSkinDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DSkin.Controls.DSkinButton dSkinButton1;
        private DSkin.Controls.DSkinToolTip dSkinToolTip1;
    }
}
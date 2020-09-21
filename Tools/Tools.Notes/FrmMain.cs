using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools.Notes
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width- new Random().Next(50), 50 + new Random().Next(50));
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(置顶ToolStripMenuItem.Checked)
            {
                置顶ToolStripMenuItem.Checked = false;
                this.TopMost = false;
            }
            else
            {
                置顶ToolStripMenuItem.Checked = true;
                this.TopMost = true;
            }
        }

        private void 不透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            不透明ToolStripMenuItem.Checked = true;
            this.Opacity = 1;
            toolStripMenuItem2.Checked = toolStripMenuItem3.Checked = toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = true;
            this.Opacity = 0.75;
            不透明ToolStripMenuItem.Checked = toolStripMenuItem3.Checked = toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripMenuItem3.Checked = true;
            this.Opacity = 0.5;
            不透明ToolStripMenuItem.Checked = toolStripMenuItem2.Checked = toolStripMenuItem4.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4.Checked = true;
            this.Opacity = 0.25;
            不透明ToolStripMenuItem.Checked = toolStripMenuItem2.Checked = toolStripMenuItem3.Checked = false;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog ftFile = new FontDialog();
            ftFile.Font = this.dSkinChatRichTextBox1.SelectionFont;
            if (ftFile.ShowDialog() == DialogResult.OK)
            {
                this.dSkinChatRichTextBox1.SelectionFont = ftFile.Font;
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog clrFile = new ColorDialog();
            clrFile.Color = this.dSkinChatRichTextBox1.SelectionColor;
            if (clrFile.ShowDialog() == DialogResult.OK)
            {
                this.dSkinChatRichTextBox1.SelectionColor = clrFile.Color;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savFile = new SaveFileDialog();
            savFile.Title = "导出便签文本";
            savFile.Filter = "文本文档(*.txt)|*.txt";
            if (savFile.ShowDialog() == DialogResult.OK)
                File.WriteAllText(savFile.FileName, dSkinChatRichTextBox1.Text);
        }
    }
}

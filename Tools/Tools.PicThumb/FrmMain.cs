using DSkin.Controls;
using DSkin.DirectUI;
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

namespace Tools.PicThumb
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            dSkinCheckBox1.Checked = true;
            label1.Visible = dSkinTextBox1.Visible = button1.Visible = false;
        }

        private void dSkinCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (dSkinCheckBox1.Checked)
            {
                label1.Visible = dSkinTextBox1.Visible = button1.Visible = false;
            }
            else
            {
                label1.Visible = dSkinTextBox1.Visible = button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.dSkinTextBox1.Text = path.SelectedPath;
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if(!dSkinCheckBox1.Checked&& !Directory.Exists(this.dSkinTextBox1.Text))
            {
                DSkinMessageBox.Show("目录不存在");
                return;
            }
            for(int i = 0; i < dSkinGridList1.RowCount; i++)
            {
                if (dSkinCheckBox1.Checked)
                {
                    if (!Directory.Exists("temp"))
                    {
                        Directory.CreateDirectory("temp");
                    }
                }
               // DSkinMessageBox.Show(dSkinGridList1.Rows[i].Cells[1].Value.ToString());
                Common.ImageHelper.CompressImage(
                    dSkinGridList1.Rows[i].Cells[1].Value.ToString(),
                    dSkinCheckBox1.Checked? ("temp/"+ dSkinGridList1.Rows[i].Cells[0].Value.ToString()) : (this.dSkinTextBox1.Text+"/"+ dSkinGridList1.Rows[i].Cells[0].Value.ToString()),
                    dSkinTrackBar1.Value,
                    Convert.ToInt32(dSkinNumericUpDown1.Value)
                    );
                if (dSkinCheckBox1.Checked)
                {
                    if (!Directory.Exists("temp"))
                    {
                        Directory.CreateDirectory("temp");
                    }
                    File.Copy("temp/"+ dSkinGridList1.Rows[i].Cells[0].Value.ToString(), dSkinGridList1.Rows[i].Cells[1].Value.ToString(), true);
                    File.Delete("temp/" + dSkinGridList1.Rows[i].Cells[0].Value.ToString());
                }
                
            }
            
        }

        private void dSkinListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))      //判断该文件是否可以转换到文件放置格式
            {
                e.Effect = DragDropEffects.Link;       //放置效果为链接放置
            }
            else
            {
                e.Effect = DragDropEffects.None;      //不接受该数据,无法放置，后续事件也无法触发
            }
        }

        private void dSkinListBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] img = { ".jpg", ".png", ".bmp" };
            foreach (string path in files)
            {
                if (File.Exists(path))
                {
                    string filename = System.IO.Path.GetFileName(path);
                    string ext = System.IO.Path.GetExtension(path);
                    if (Array.IndexOf(img, ext) != -1)
                    {
                        dSkinGridList1.Rows.AddRow(filename, path);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void dSkinTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (dSkinTrackBar1.Value == 0)
            {
                dSkinTrackBar1.Value = 1;
                label3.Text = "1";
            }
            label3.Text = dSkinTrackBar1.Value.ToString();
        }

        private void 清空全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dSkinGridList1.Rows.Clear();
        }
    }
}

using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Ocr
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        Image img = null;
        private void dSkinPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowHelp = true;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(opf.FileName);
                dSkinPictureBox1.Image = img;
            }
        }
        
        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            getResult(0);
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            getResult(1);
        }

        private void dSkinButton9_Click(object sender, EventArgs e)
        {
            getResult(8);
        }

        private void getResult(int type=0,string str="")
        {
            BaseController baseController = new BaseController();
            if (img == null)
            {
                DSkinMessageBox.Show("请先选择图片");
                return;
            }
            string result = baseController.AdvancedGeneralDemo(img, type,str);
            new FrmResult(result).ShowDialog();
        }

        private void dSkinButton3_Click(object sender, EventArgs e)
        {
            FrmIdCardSelect f = new FrmIdCardSelect();
            f.ShowDialog();
            if (f.getStatus())
            {
                getResult(2,f.getSelected());
            }
            
        }

        private void dSkinButton4_Click(object sender, EventArgs e)
        {
            getResult(3);
        }

        private void dSkinButton5_Click(object sender, EventArgs e)
        {
            getResult(4);
        }

        private void dSkinButton6_Click(object sender, EventArgs e)
        {
            getResult(5);
        }

        private void dSkinButton7_Click(object sender, EventArgs e)
        {
            getResult(6);
        }

        private void dSkinButton8_Click(object sender, EventArgs e)
        {
            getResult(7);
        }
    }
}

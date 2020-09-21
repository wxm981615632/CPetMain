using DSkin.Forms;
using DSkin.OpenGL;
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
    public partial class FrmIdCardSelect : DSkinForm
    {
        public FrmIdCardSelect()
        {
            InitializeComponent();
        }
        private bool status = false;
        private void FrmIdCardSelect_Load(object sender, EventArgs e)
        {

        }

        public bool getStatus()
        {
            return status;
        }
        private string type= "front";
        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            status = true;
            type = "front";
            this.Close();
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            status = true;
            type = "back";
            this.Close();
        }

        public string getSelected()
        {
            return type;
        }
    }
}

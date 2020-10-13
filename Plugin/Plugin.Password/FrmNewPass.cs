using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Password
{
    public partial class FrmNewPass : DSkinForm
    {
        public FrmNewPass()
        {
            InitializeComponent();
        }

        private void FrmNewPass_Load(object sender, EventArgs e)
        {

        }
        public string password = "";
        public bool status = false;
        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
            ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
            ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
            ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
            ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
            password = Common.StrHelper.GetRandomString(
                    Convert.ToInt32(dSkinNumericUpDown1.Value),
                    dSkinCheckBox1.Checked,
                    dSkinCheckBox2.Checked,
                    dSkinCheckBox3.Checked,
                    dSkinCheckBox4.Checked,
                    dSkinTextBox1.Text
                );
            status = true;
            this.Close();
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Weather
{
    public partial class FrmOther : DSkinForm
    {
        public FrmOther()
        {
            InitializeComponent();
        }

        public Result result { set; get; }
        private void FrmOther_Load(object sender, EventArgs e)
        {
            if (result==null)
            {
                return;
            }
            //明天
            dSkinLabel4.Text = result.data.forecast[1].type;
            dSkinLabel7.Text = result.data.forecast[1].low.Replace("低温", "").Replace(" ", "").Replace("℃", "") + " ～" + result.data.forecast[1].high.Replace("高温", "").Replace(" ", "").Replace("℃", "") + "℃";
            dSkinLabel10.Text = result.data.forecast[1].fx + "    " + result.data.forecast[1].fl;
            dSkinPictureBox1.Image = Image.FromFile(Weather.changeImg(dSkinLabel4.Text, false)); ;
            //后天
            dSkinLabel5.Text = result.data.forecast[2].type;
            dSkinLabel8.Text = result.data.forecast[2].low.Replace("低温", "").Replace(" ", "").Replace("℃", "") + " ～" + result.data.forecast[2].high.Replace("高温", "").Replace(" ", "").Replace("℃", "") + "℃";
            dSkinLabel11.Text = result.data.forecast[2].fx + "    " + result.data.forecast[2].fl;
            dSkinPictureBox2.Image = Image.FromFile(Weather.changeImg(dSkinLabel5.Text, false)); ;
            //大后天
            dSkinLabel6.Text = result.data.forecast[3].type;
            dSkinLabel9.Text = result.data.forecast[3].low.Replace("低温", "").Replace(" ", "").Replace("℃", "") + " ～" + result.data.forecast[3].high.Replace("高温", "").Replace(" ", "").Replace("℃", "") + "℃";
            dSkinLabel12.Text = result.data.forecast[3].fx + "    " + result.data.forecast[3].fl;
            dSkinPictureBox3.Image = Image.FromFile(Weather.changeImg(dSkinLabel6.Text,false)); ;
        }

        private void FrmOther_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.timer1.Enabled = false;
            this.Hide();
        }
    }
}

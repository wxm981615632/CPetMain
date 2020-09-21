using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.AutoShutdown
{
    public partial class Form3 : Form
    {
        Thread t;
        bool on = true;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Maximized;
            Size fs = TextRenderer.MeasureText(label1.Text,label1.Font);
            label1.Location = new Point((this.Width - fs.Width) / 2, (this.Height - fs.Height) / 2);
            t = new Thread(delegate () { ShowNotice(); });
            t.Start();
        }

        private void ShowNotice()
        {
            while(on)
            {
                this.BackColor = Color.Red;
                label1.ForeColor = Color.Green;
                System.Media.SystemSounds.Question.Play();
                Thread.Sleep(200);
                this.BackColor = Color.Blue;
                label1.ForeColor = Color.Yellow;
                System.Media.SystemSounds.Exclamation.Play();
                Thread.Sleep(200);
                this.BackColor = Color.Tomato;
                label1.ForeColor = Color.SteelBlue;
                System.Media.SystemSounds.Hand.Play();
                Thread.Sleep(200);
                this.BackColor = Color.YellowGreen;
                label1.ForeColor = Color.OrangeRed;
                System.Media.SystemSounds.Beep.Play();
                Thread.Sleep(200);
                this.BackColor = Color.MediumSeaGreen;
                label1.ForeColor = Color.LightPink;
                System.Media.SystemSounds.Asterisk.Play();
                Thread.Sleep(200);
            }
            
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                try
                {
                    //t.Abort();
                    on = false;
                }
                catch
                {

                }
                this.Close();
            }
        }

        private void Form3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //t.Abort();
                on = false;
            }
            catch
            {

            }
            this.Close();
        }
    }
}

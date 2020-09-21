using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Tools.AutoShutdown
{
    public partial class FrmMain : Form
    {
        Thread thread;
        Point PHour=new Point(60,40);
        Point PMinute=new Point(60,30);
        Point PSeconds=new Point(60,20);
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重写CreateParams方法
        /// 解决控件过多加载闪烁问题(会导致视频无法播放)
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;//用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            radioButton1.Checked = true;
            for(int i=0;i<=24;i++)
            {
                comboBox1.Items.Add(i);
                comboBox9.Items.Add(i);
            }
            for(int i=0;i<=59;i++)
            {
                comboBox2.Items.Add(i);
                comboBox3.Items.Add(i);
                comboBox7.Items.Add(i);
                comboBox8.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;

            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as RadioButton).Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                int hours = Convert.ToInt32(comboBox1.SelectedItem);
                int minutes= Convert.ToInt32(comboBox2.SelectedItem);
                int seconds = Convert.ToInt32(comboBox3.SelectedItem);
                if(hours==0&&minutes==0&&seconds==0)
                {
                    MessageBox.Show("请选择延时时间！");
                }

                DateTime enddate = DateTime.Now.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
                if(MessageBox.Show("电脑将在 " + hours + "小时" + minutes + "分钟" + seconds + "秒 后"+comboBox4.SelectedItem+"，"+comboBox4.SelectedItem+"时间为 " + enddate.ToLongDateString()+enddate.ToLongTimeString(),"",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    thread = new Thread(delegate () { Tstart(enddate); });
                    thread.Start();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    button1.Enabled = false;
                }
            }
            else
            {
                int hours = Convert.ToInt32(comboBox9.SelectedItem);
                int minutes = Convert.ToInt32(comboBox8.SelectedItem);
                int seconds = Convert.ToInt32(comboBox7.SelectedItem);
                DateTime enddate= dateTimePicker1.Value.Date.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
                if((enddate-DateTime.Now).TotalSeconds<=0)
                {
                    MessageBox.Show("时间已过，请重新选择！");
                    return;
                }

                if(MessageBox.Show("电脑将在 "+enddate.ToLongDateString() + enddate.ToLongTimeString()+" "+comboBox4.SelectedItem,"",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    thread = new Thread(delegate () { Tstart(enddate); });
                    thread.Start();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    button1.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(thread!=null)
            {
                thread.Abort();
            }
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            button1.Enabled = true;
        }
        bool is_check = true;
        private void Tstart(DateTime datetime)
        {
            while(true&& is_check)
            {
                DateTime now = DateTime.Now;
                TimeSpan t = datetime - now;
                string time = t.Days + "天" + t.Hours + "小时" + t.Minutes + "分钟" + t.Seconds + "秒";
                label2.Text = time;


                if (t.TotalSeconds<=1)
                {
                    Form2 f2 = new Form2(comboBox4.SelectedIndex);
                    if(f2.ShowDialog()!=DialogResult.Yes)
                    {
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        button1.Enabled = true;
                        return;
                    }

                    switch(comboBox4.SelectedIndex)
                    {
                        case 0:ShutDown();break;
                        case 1:Restart();break;
                        case 2:LogOff();break;
                        case 3:LockPC();break;
                        case 4:Turnoffmonitor();break;
                        case 5:Notice();break;
                    }
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    button1.Enabled = true;
                    return;//执行关机程序
                }
            }
        }

        private void button1_EnabledChanged(object sender, EventArgs e)
        {
            if(button1.Enabled)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }



        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("user32")]
        public static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
        public enum MonitorState
        {
            MonitorStateOn = -1,
            MonitorStateOff = 2,
            MonitorStateStandBy = 1
        }

        //关机
        public static void ShutDown()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-s -t 00");
                System.Diagnostics.Process.Start(startinfo);
            }
            catch { }
        }

        //重启
        public static void Restart()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo startinfo = new System.Diagnostics.ProcessStartInfo("shutdown.exe", "-r -t 00");
                System.Diagnostics.Process.Start(startinfo);
            }
            catch { }
        }

        //注销
        public static void LogOff()
        {
            try
            {
                ExitWindowsEx(0, 0);
            }
            catch { }
        }

        //锁定
        public static void LockPC()
        {
            try
            {
                LockWorkStation();
            }
            catch { }
        }

        //关闭显示器
        public static void Turnoffmonitor()
        {
            SetMonitorInState(MonitorState.MonitorStateOff);
        }

        public static void Notice()
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private static void SetMonitorInState(MonitorState state)
        {
            SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(120, 120);
            Graphics.FromImage(bmp).Clear(Color.White);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel3.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawArc(new Pen(Color.Black, 9), new Rectangle(5, 5, 110, 110), 0, 360);
            g.DrawLine(new Pen(Color.Black, 5), new Point(60, 5), new Point(60, 20));
            g.DrawLine(new Pen(Color.Black, 5), new Point(60, 115), new Point(60, 100));
            g.DrawLine(new Pen(Color.Black, 5), new Point(5, 60), new Point(20, 60));
            g.DrawLine(new Pen(Color.Black, 5), new Point(115, 60), new Point(100, 60));

            g.DrawLine(new Pen(Color.Black, 3),new Point((int)(60+27.5), (int)(60-60*Math.Cos(30 * Math.PI / 180))),new Point((int)(60+20), (int)(60-40*Math.Cos(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60 + 60 * Math.Cos(30 * Math.PI / 180)), (int)(60-60 * Math.Sin(30 * Math.PI / 180))), new Point((int)(60 + 40* Math.Cos(30 * Math.PI / 180)), (int)(60-40*Math.Sin(30*Math.PI/180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60 + 27.5), (int)(60 + 60 * Math.Cos(30 * Math.PI / 180))), new Point((int)(60 + 20), (int)(60 + 40 * Math.Cos(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60 + 60 * Math.Cos(30 * Math.PI / 180)), (int)(60 + 60 * Math.Sin(30 * Math.PI / 180))), new Point((int)(60 + 40 * Math.Cos(30 * Math.PI / 180)), (int)(60 + 40 * Math.Sin(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60 - 27.5+1), (int)(60 - 60 * Math.Cos(30 * Math.PI / 180))), new Point((int)(60 - 20), (int)(60 - 40 * Math.Cos(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60+1 - 60 * Math.Cos(30 * Math.PI / 180)), (int)(60 - 60 * Math.Sin(30 * Math.PI / 180))), new Point((int)(60 - 40 * Math.Cos(30 * Math.PI / 180)), (int)(60 - 40 * Math.Sin(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60 - 27.5+1), (int)(60 + 60 * Math.Cos(30 * Math.PI / 180))), new Point((int)(60 - 20), (int)(60 + 40 * Math.Cos(30 * Math.PI / 180))));
            g.DrawLine(new Pen(Color.Black, 3), new Point((int)(60+1 - 60 * Math.Cos(30 * Math.PI / 180)), (int)(60 + 60 * Math.Sin(30 * Math.PI / 180))), new Point((int)(60 - 40 * Math.Cos(30 * Math.PI / 180)), (int)(60 + 40 * Math.Sin(30 * Math.PI / 180))));


            g.DrawLine(new Pen(Color.Black, 1),new Point(60,60), PSeconds);
            g.DrawLine(new Pen(Color.Black, 2), new Point(60, 60), PMinute);
            g.DrawLine(new Pen(Color.Black, 3), new Point(60, 60), PHour);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            is_check = false;
            this.timer1.Enabled = false;
            this.Dispose();
            //Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int h = now.Hour;
            int m = now.Minute;
            int s = now.Second;
            int totalSeconds = h * 3600 + m * 60 + s;

            int Rs = 40;
            int Rm = 30;
            int Rh = 20;//半径

            int angleS = 180 - (6 * s + 90);
            PSeconds = new Point((int)(60 + Rs * Math.Cos(angleS * Math.PI / 180)),(int)( 60 - Rs * Math.Sin(angleS * Math.PI / 180)));
            int angleM = 180 - (6 * m + 90);
            PMinute = new Point((int)(60 + Rm * Math.Cos(angleM * Math.PI / 180)), (int)(60 - Rm * Math.Sin(angleM * Math.PI / 180)));
            int angleH = 180 - (totalSeconds % (3600 * 12) / 120 + 90);
            PHour = new Point((int)(60 + Rh * Math.Cos(angleH * Math.PI / 180)), (int)(60 - Rh * Math.Sin(angleH * Math.PI / 180)));
            panel3.Invalidate();
            label7.Text = now.ToLongTimeString();
        }
    }
}

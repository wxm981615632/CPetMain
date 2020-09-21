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
    public partial class Form2 : Form
    {
        int operationType;
        public Form2(int Otype)
        {
            InitializeComponent();
            operationType = Otype;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(delegate () { count(); });
            t.Start();
        }

        private void count()
        {
            string optype="" ;
            switch (operationType)
            {
                case 0:optype = "关机";break;
                case 1:optype = "重启";break;
                case 2:optype = "注销";break;
                case 3:optype = "锁定";break;
                case 4:optype = "关闭显示器";break;
                case 5:optype = "提醒";break;
            }

            for(int i=0;i<10;i++)
            {
                label1.Text = "将在" + (10 - i) + "s后执行" + optype;
                Thread.Sleep(1000);
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

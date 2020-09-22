using Common;
using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPetMain
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            IniHelper.Instance.FileName = "conf/config.ini";
            this.Location = new Point(
                IniHelper.Instance.ReadInteger("Setting", "location_x", Screen.GetWorkingArea(this).Width - this.Width - 100),
                IniHelper.Instance.ReadInteger("Setting", "location_y", Screen.GetWorkingArea(this).Height - this.dSkinPictureBox1.Height)
            );
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //模式：1标准；2工作；3勿扰；4娱乐
        private int baseModel = 1;
        private void 标准ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseModel = 1;
            changeBaseModel();
        }

        private void 工作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseModel = 2;
            changeBaseModel();
        }

        private void 勿扰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseModel = 3;
            changeBaseModel();
        }

        private void 娱乐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseModel = 4;
            changeBaseModel();
        }

        private void changeBaseModel()
        {
            switch (baseModel)
            {
                case 2://工作
                    工作ToolStripMenuItem.Checked = true;
                    勿扰ToolStripMenuItem.Checked =
                        娱乐ToolStripMenuItem.Checked =
                        标准ToolStripMenuItem.Checked = false;
                    break;
                case 3://勿扰
                    勿扰ToolStripMenuItem.Checked = true;
                    工作ToolStripMenuItem.Checked =
                        娱乐ToolStripMenuItem.Checked =
                        标准ToolStripMenuItem.Checked = false;
                    break;
                case 4://娱乐
                    娱乐ToolStripMenuItem.Checked = true;
                    工作ToolStripMenuItem.Checked =
                        勿扰ToolStripMenuItem.Checked =
                        标准ToolStripMenuItem.Checked = false;
                    break;
                default://标准
                    标准ToolStripMenuItem.Checked = true;
                    勿扰ToolStripMenuItem.Checked =
                        娱乐ToolStripMenuItem.Checked =
                        工作ToolStripMenuItem.Checked = false;
                    break;
            }
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void 网络修复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "";
            MachineHelper.RunCmd("netsh winsock reset", out output);
            MessageBox.Show(output);
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
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

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (MessageBox.Show("是否要直接删除这" + files.Count() + "个文件", "确认重置？", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (string path in files)
                {
                    string output = "";
                    if (Directory.Exists(path))
                    {
                        MachineHelper.RunCmd("rd /s /q " + path, out output);
                    }
                    else
                    {
                        MachineHelper.RunCmd("del /f /q " + path, out output);
                    }
                    Console.WriteLine(output);
                }
            }
        }

        private void timer0_Tick(object sender, EventArgs e)
        {
            StrHelper.ClearMemory();
        }

        private void 天气温度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.Weather.FrmMain frm = new Plugin.Weather.FrmMain();
            frm.Show();
        }

        private void 快递提醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.Express.FrmMain frm = new Plugin.Express.FrmMain();
            frm.Show();
        }

        private void 文字识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.Ocr.FrmMain frm = new Plugin.Ocr.FrmMain();
            frm.Show();
        }

        private void json格式化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.FormatJson.FrmMain frm = new Tools.FormatJson.FrmMain();
            frm.Show();
        }

        private void 定时关机重启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.AutoShutdown.FrmMain frm = new Tools.AutoShutdown.FrmMain();
            frm.Show();
        }

        private void 图片压缩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.PicThumb.FrmMain frm = new Tools.PicThumb.FrmMain();
            frm.Show();
        }

        private void 屏幕截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DSkin.Controls.FrmCapture frm = new DSkin.Controls.FrmCapture();
            //frm.Show();
            Tools.ScreenCut.FrmMain frm = new Tools.ScreenCut.FrmMain();
            frm.Show();
        }

        private void 便签ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools.Notes.FrmMain frm = new Tools.Notes.FrmMain();
            frm.Show();
        }

        private void dSkinPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && is_move)
            {
                Point oMoveToPoint = default(Point);
                //以当前鼠标位置为基础，找出目标位置
                oMoveToPoint = PointToScreen(new Point(e.X, e.Y));
                oMoveToPoint.Offset(oPointClicked.X * -1, (oPointClicked.Y + SystemInformation.CaptionHeight + SystemInformation.BorderSize.Height) * -1 + 24);
                Location = oMoveToPoint;
            }
        }
        bool is_move = false;
        Point oPointClicked; // 用于窗体移动
        private void dSkinPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                is_move = false;
                IniHelper.Instance.FileName = "conf/config.ini";
                IniHelper.Instance.WriteInteger("Setting", "location_x", this.Location.X);
                IniHelper.Instance.WriteInteger("Setting", "location_y", this.Location.Y);
            }
        }

        private void dSkinPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                is_move = true;
                oPointClicked = new Point(e.X, e.Y);
            }
        }

        private void 常规ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetting fs = new FrmSetting();
            fs.ShowDialog();
        }
        //timer0    清理/加速
        //timer1    清理缓存
        //timer2    写入好感度
        //timer3    自定义定时任务
        //timer4    天气/温度提醒
        //timer5    日历/节假日/节气提醒
        //timer6    游戏互动
        //timer7    快递提醒
    }
}

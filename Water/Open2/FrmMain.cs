using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Water.Open2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
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
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string[] img = { ".lnk", ".exe"};
            if (File.Exists(path))
            {
                //string filename = System.IO.Path.GetFileName(path);
                string ext = System.IO.Path.GetExtension(path);
                if (Array.IndexOf(img, ext) != -1)
                {
                    openFile(path);
                }
            }
        }

        private void openFile(string path = "")
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            //如果是微信的
            if(Common.StrHelper.checkEquals(name,"微信")|| Common.StrHelper.checkEquals(name, "WeChat"))
            {
                Process[] localByName = Process.GetProcessesByName("WeChat");
                foreach (Process pro in localByName)
                {
                    foreach(ProcessThread thread in pro.Threads)
                    {
                        Console.WriteLine(
                            String.Format("ID:{0} Name:{1} ThreadState{2}", 
                            thread.Id, 
                            thread.StartTime, 
                            thread.ThreadState));
                    }
                }
            }
            //如果不是微信的
            Process.Start(path);
        }


    }
}

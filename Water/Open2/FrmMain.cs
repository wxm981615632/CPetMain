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
            string[] img = { ".lnk", ".exe", ".doc", ".docx", ".rar" };
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
        private void checkProcessAndClose(Process pro,string name)
        {
            ushort handle = RefreshHandles2(pro, name);
            if (handle != 0)
            {
                HandleModle.CloseProcessHandle(pro.Id, handle);
            }
        }
        private void openFile(string path = "")
        {
            ClearMemory();
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            //如果是微信的
            if(name.Equals("微信")|| name.Equals("WeChat"))
            {
                Process[] localByName = Process.GetProcessesByName("WeChat");
                foreach (Process pro in localByName)
                {
                    //WeChat_App_Instance_Identity_Mutex_Name
                    checkProcessAndClose(pro,"WeChat_App_Instance_Identity_Mutex_Name");
                }
            }
            //企业微信
            if (name.Equals("企业微信") || name.Equals("WXWork"))
            {
                Process[] localByName = Process.GetProcessesByName("WXWork");
                foreach (Process pro in localByName)
                {
                    checkProcessAndClose(pro, "Tencent.WeWork.ExclusiveObjectInstance1");
                    checkProcessAndClose(pro, "Tencent.WeWork.ExclusiveObject");
                }
            }
            //腾讯手游助手
            if (name.Equals("腾讯手游助手") || name.Equals("AppMarket"))
            {
                Process[] localByName = Process.GetProcessesByName("AppMarket");
                foreach (Process pro in localByName)
                {
                    checkProcessAndClose(pro, "_APPMARKET_1");
                }
            }
            //bilibili投稿工具
            if (name.Equals("bilibili投稿工具") || name.Equals("ugc_assistant"))
            {
                Process[] localByName = Process.GetProcessesByName("ugc_assistant");
                foreach (Process pro in localByName)
                {
                    checkProcessAndClose(pro, "qipc_sharedmemory_bilibilid");
                }
            }
            //优酷
            if (name.Equals("优酷") || name.Equals("YoukuDesktop"))
            {
                Process[] localByName = Process.GetProcessesByName("YoukuDesktop");
                foreach (Process pro in localByName)
                {
                    checkProcessAndClose(pro, "ikudesktop");
                }
            }
            Process.Start(path);
            ClearMemory();
        }
        private ushort RefreshHandles2(Process pro, string check = "")
        {
            List<Win32API.SYSTEM_HANDLE_INFORMATION> lws = HandleModle.GetHandles(pro);
            foreach (Win32API.SYSTEM_HANDLE_INFORMATION lw in lws)
            {
                string str_handle_name = HandleModle.GetFilePath(lw, pro);
                Console.WriteLine(lw.ProcessID);
                Console.WriteLine(lw.ObjectTypeNumber);
                Console.WriteLine(lw.Flags);
                Console.WriteLine(lw.Handle);
                Console.WriteLine(str_handle_name);
                Console.WriteLine("===========================");
                if ("" == str_handle_name)
                {
                    continue;
                }
                if (str_handle_name == null)
                {
                    continue;
                }
                if (str_handle_name.Contains(check))
                {
                    return lw.Handle;
                }
            }
            return 0;
        }
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary> 
        /// 释放内存
        /// </summary> 
        public void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void 选择文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;//返回文件的完整路径   
                string[] img = { ".lnk", ".exe", ".doc", ".docx", ".rar" };
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
        }
    }


}

using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
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
            if (System.IO.File.Exists(path))
            {
                //string filename = System.IO.Path.GetFileName(path);
                string ext = System.IO.Path.GetExtension(path);
                if (Array.IndexOf(img, ext) != -1)
                {
                    if (ext.Equals(".lnk"))
                    {
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(path);    //获取快捷方式对象
                        path = shortcut.TargetPath;
                    }
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
        private string base_url = "http://cpet.smallchen.com/api/Open2/";
        private void openFile(string path = "")
        {
            ClearMemory();
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("name", name);
            string str = HttpHelper.Post(base_url+ "getSoftInfo", dic);
            Result_Info res = HttpHelper.JSONString<Result_Info>(str);
            if (res.code == 1)
            {
                foreach(Map_Info mi in res.data)
                {
                    if (mi.type == 1)
                    {
                        Process[] localByName = Process.GetProcessesByName(mi.process);
                        foreach (Process pro in localByName)
                        {
                            foreach (string value in mi.values)
                            {
                                checkProcessAndClose(pro, value);
                            }
                        }
                    }
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
                    Console.WriteLine(lw.ProcessID);
                    Console.WriteLine(lw.ObjectTypeNumber);
                    Console.WriteLine(lw.Flags);
                    Console.WriteLine(lw.Handle);
                    Console.WriteLine(str_handle_name);
                    Console.WriteLine("===========================");
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
                if (System.IO.File.Exists(path))
                {
                    //string filename = System.IO.Path.GetFileName(path);
                    string ext = System.IO.Path.GetExtension(path);
                    if (Array.IndexOf(img, ext) != -1)
                    {
                        if (ext.Equals(".lnk"))
                        {
                            string initialSource = @"C:\Users\AY_Format\Desktop\QuickHider快捷方式.lnk"; //需要读取的快捷方式路径
                            WshShell shell = new WshShell();
                            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(initialSource);    //获取快捷方式对象
                            path = shortcut.TargetPath;
                        }
                        openFile(path);
                    }
                }
            }
        }

        private void 支持列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSoft fs = new FrmSoft();
            fs.ShowDialog();
        }
    }


}

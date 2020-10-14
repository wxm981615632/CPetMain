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
        ProcessHandles m_proc_handles;
        private void checkProcessAndClose(int proid,string name)
        {
            string str_handle = RefreshHandles(proid, name);
            if (str_handle != "")
            {
                UInt16 handle = Convert.ToUInt16(str_handle.Substring(2), 16);
                m_proc_handles.CloseProcessHandle(proid, handle);
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
                    checkProcessAndClose(pro.Id,"WeChat_App_Instance_Identity_Mutex_Name");
                }
            }
            //企业微信
            if (name.Equals("企业微信") || name.Equals("WXWork"))
            {
                Process[] localByName = Process.GetProcessesByName("WXWork");
                foreach (Process pro in localByName)
                {
                    checkProcessAndClose(pro.Id, "Tencent.WeWork.ExclusiveObjectInstance1");
                    checkProcessAndClose(pro.Id, "Tencent.WeWork.ExclusiveObject");
                }
            }
            Process.Start(path);
            ClearMemory();
        }

        private string RefreshHandles(int pid,string check="")
        {
            m_proc_handles = new ProcessHandles();
            List<ProcessHandles.SYSTEM_HANDLE_INFORMATION> lst_handles = m_proc_handles.GetProcessHandles(pid);

            foreach (ProcessHandles.SYSTEM_HANDLE_INFORMATION shi in lst_handles)
            {
                ProcessHandles.PROCESS_HANDLE_INFORMATION phi = m_proc_handles.GetProcessHandleInfo(shi.ProcessId, shi.Handle);
                string str_handle_name = ProcessHandles.UnicodeStringToString(phi.m_object_name_info.Name);
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
                    Console.WriteLine(shi.ProcessId.ToString());
                    Console.WriteLine("0x" + shi.Handle.ToString("X8"));
                    Console.WriteLine(ProcessHandles.UnicodeStringToString(phi.m_object_type_info.Name));
                    Console.WriteLine(str_handle_name);
                    Console.WriteLine("================================");
                    return "0x" + shi.Handle.ToString("X8");
                }
               
            }
            return "";
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

    }


}

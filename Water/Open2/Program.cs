using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;//使用DllImport的必须。
using System.Diagnostics;//引入Process 类

namespace Water.Open2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());//在这启动主窗体。
        }

    }
}
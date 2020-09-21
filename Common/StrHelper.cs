using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Common
{
    public class StrHelper
    {

        public static string explodes(string str, int per, string sp = "\r\n")
        {
            StringBuilder str2 = new StringBuilder();
            int len = str.Length / per + 1;
            int i = 0;
            for (i = 0; i < len - 1; i++)
            {
                str2.Append(str.Substring(per * i, per)).Append(sp);
            }
            str2.Append(str.Substring(per * i));
            return str2.ToString();
        }
        public static bool checkEquals(string str1 = "", string str2 = "")
        {
            if (str1 == null || str2 == null)
            {
                if (str1 != null && str2 == null)
                    return false;
                if (str1 == null && str2 != null)
                    return false;
            }
            if (str1.Equals(str2) || str1 == str2)
                return true;
            else
                return false;

        }

        public static string MD5Encrypt(string normalTxt)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(normalTxt);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                return "";
            }
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary> 
        /// 释放内存
        /// </summary> 
        public static void ClearMemory()
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

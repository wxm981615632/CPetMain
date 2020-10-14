using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Water.Open2
{
    class ProcessEnum
    {
        #region 常量

        private const int SE_PRIVILEGE_ENABLED = 0x2;

        private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        private const int TOKEN_ADJUST_DEFAULT = 0x80;
        private const int TOKEN_ADJUST_GROUPS = 0x40;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x20;
        private const int TOKEN_ADJUST_SESSIONID = 0x100;
        private const int TOKEN_ASSIGN_PRIMARY = 0x1;
        private const int TOKEN_DUPLICATE = 0x2;
        private const int TOKEN_IMPERSONATE = 0x4;
        private const int TOKEN_QUERY = 0x8;
        private const int TOKEN_QUERY_SOURCE = 0x10;
        private const int TOKEN_ALL_ACCESS =
            (STANDARD_RIGHTS_REQUIRED |
             TOKEN_ASSIGN_PRIMARY |
             TOKEN_DUPLICATE |
             TOKEN_IMPERSONATE |
             TOKEN_QUERY |
             TOKEN_QUERY_SOURCE |
             TOKEN_ADJUST_PRIVILEGES |
             TOKEN_ADJUST_GROUPS |
             TOKEN_ADJUST_SESSIONID |
             TOKEN_ADJUST_DEFAULT);

        #endregion

        #region 类型

        public struct PROCESS_INFO
        {
            internal int m_pid;
            internal string m_process_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID
        {
            internal int LowPart;
            internal int HighPart;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LUID_AND_ATTRIBUTES
        {
            internal LUID pLuid;
            internal int Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct TOKEN_PRIVILEGES
        {
            internal int PrivilegeCount;
            internal LUID_AND_ATTRIBUTES Privileges;
        }

        #endregion

        #region 提权 API

        [DllImport("kernel32.dll")]
        private static extern int GetCurrentProcess();

        [DllImport("advapi32.dll")]
        private static extern bool OpenProcessToken(int ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);

        [DllImport("advapi32.dll")]
        private static extern bool AdjustTokenPrivileges(
            IntPtr TokenHandle,
            int DisableAllPrivileges,
            ref TOKEN_PRIVILEGES NewState,
            int BufferLength,
            IntPtr PreviousState,
            IntPtr ReturnLength);

        [DllImport("advapi32.dll", EntryPoint = "LookupPrivilegeValueA")]
        private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, ref LUID lpLuid);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        #endregion

        #region 成员函数

        public ProcessEnum()
        {
            EnableTokenPrivileges();
        }

        public bool EnableTokenPrivileges()
        {
            LUID luid = new LUID();
            IntPtr token_handle = IntPtr.Zero;
            if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ALL_ACCESS, ref token_handle))
            {
                return false;
            }

            if (!LookupPrivilegeValue("", "SeDebugPrivilege", ref luid))
            {
                CloseHandle(token_handle);
                return false;
            }

            TOKEN_PRIVILEGES token_privileges = new TOKEN_PRIVILEGES();
            token_privileges.PrivilegeCount = 1;
            token_privileges.Privileges.pLuid = luid;
            token_privileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED;
            if (!AdjustTokenPrivileges(
                    token_handle, 0, ref token_privileges,
                    0, IntPtr.Zero, IntPtr.Zero))
            {
                CloseHandle(token_handle);
                return false;
            }

            return CloseHandle(token_handle);
        }

        public List<PROCESS_INFO> GetProcessesList()
        {
            List<PROCESS_INFO> lst_ret = new List<PROCESS_INFO>();
            foreach (Process proc in Process.GetProcesses())
            {
                PROCESS_INFO pi = new PROCESS_INFO();
                pi.m_pid = proc.Id;
                pi.m_process_name = proc.ProcessName;

                lst_ret.Add(pi);
            }

            return lst_ret;
        }

        #endregion
    }
}

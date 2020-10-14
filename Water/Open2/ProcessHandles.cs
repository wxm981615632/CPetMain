using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Water.Open2
{
    class ProcessHandles
    {
        #region 常量

        private const int MAX_PATH = 256;

        private const int SystemHandleInformation = 16;

        private const int ObjectBasicInformation = 0;
        private const int ObjectNameInformation = 1;
        private const int ObjectTypeInformation = 2;

        private const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;
        private const uint STATUS_SUCCESS = 0x00;

        private const int PROCESS_DUP_HANDLE = 0x40;

        private const int DUPLICATE_CLOSE_SOURCE = 0x01;
        private const int DUPLICATE_SAME_ACCESS = 0x02;

        private const int MAGIC_FLAG = 0x00120089;

        #endregion

        #region 结构体

        [StructLayout(LayoutKind.Sequential)]
        private struct OBJECT_ATTRIBUTES
        {
            internal int Length;
            internal int RootDirectory;
            internal int ObjectName;
            internal int Attributes;
            internal int SecurityDescriptor;
            internal int SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CLIENT_ID
        {
            internal int UniqueProcess;
            internal int UniqueThread;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_HANDLE_INFORMATION
        {
            internal int ProcessId;
            internal byte ObjectTypeNumber;
            internal byte Flags; // 0x01 = PROTECT_FROM_CLOSE, 0x02 = INHERIT
            internal UInt16 Handle;
            internal int Object;
            internal int GrantedAccess;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_BASIC_INFORMATION
        {
            internal int Attributes;
            internal int GrantedAccess;
            internal int HandleCount;
            internal int PointerCount;
            internal int PagedPoolUsage;
            internal int NonPagedPoolUsage;
            internal int Reserved1;
            internal int Reserved2;
            internal int Reserved3;
            internal int NameInformationLength;
            internal int TypeInformationLength;
            internal int SecurityDescriptorLength;
            internal long CreateTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNICODE_STRING
        {
            internal UInt16 Length;
            internal UInt16 MaximumLength;
            internal IntPtr Buffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_NAME_INFORMATION
        {
            internal UNICODE_STRING Name;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GENERIC_MAPPING
        {
            internal int GenericRead;
            internal int GenericWrite;
            internal int GenericExecute;
            internal int GenericAll;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OBJECT_TYPE_INFORMATION
        {
            internal UNICODE_STRING Name;
            internal int TotalNumberOfObjects;
            internal int TotalNumberOfHandles;
            internal int TotalPagedPoolUsage;
            internal int TotalNonPagedPoolUsage;
            internal int TotalNamePoolUsage;
            internal int TotalHandleTableUsage;
            internal int HighWaterNumberOfObjects;
            internal int HighWaterNumberOfHandles;
            internal int HighWaterPagedPoolUsage;
            internal int HighWaterNonPagedPoolUsage;
            internal int HighWaterNamePoolUsage;
            internal int HighWaterHandleTableUsage;
            internal int InvalidAttributes;
            internal GENERIC_MAPPING GenericMapping;
            internal int ValidAccessMask;
            internal byte SecurityRequired;
            internal byte MaintainHandleCount;
            internal int PoolType;
            internal int DefaultPagedPoolCharge;
            internal int DefaultNonPagedPoolCharge;
        }

        public struct PROCESS_HANDLE_INFORMATION
        {
            internal OBJECT_BASIC_INFORMATION m_object_basic_info;
            internal OBJECT_NAME_INFORMATION m_object_name_info;
            internal OBJECT_TYPE_INFORMATION m_object_type_info;
        }

        #endregion

        #region API

        [DllImport("ntdll.dll")]
        private static extern uint NtOpenProcess(
            ref IntPtr ProcessHandle,
            int AccessMask,
            ref OBJECT_ATTRIBUTES ObjectAttributes,
            ref CLIENT_ID ClientID);

        [DllImport("ntdll.dll")]
        private static extern uint NtDuplicateObject(
            IntPtr SourceProcessHandle,
            IntPtr SourceHandle,
            IntPtr TargetProcessHandle,
            ref IntPtr TargetHandle,
            int DesiredAccess,
            int HandleAttributes,
            int Options);

        [DllImport("ntdll.dll")]
        private static extern uint NtClose(
            IntPtr ObjectHandle);

        [DllImport("ntdll.dll", EntryPoint = "NtQuerySystemInformation")]
        private static extern uint NtQuerySystemInformation(
            int SystemInformationClass,
            byte[] SystemInformation,
            int SystemInformationLength,
            ref int ReturnLength);

        [DllImport("ntdll.dll", EntryPoint = "NtQueryObject")]
        private static extern uint NtQueryObject(
            IntPtr Handle,
            int ObjectInformationClass,
            byte[] ObjectInformation,
            int ObjectInformationLength,
            ref int ReturnLength);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        //[DllImport("kernel32.dll")]
        //private static extern bool DuplicateHandle(
        //    IntPtr hSourceProcessHandle,
        //    IntPtr hSourceHandle,
        //    IntPtr hTargetProcessHandle,
        //    ref IntPtr lpTargetHandle,
        //    int dwDesiredAccess,
        //    int bInheritHandle,
        //    int dwOptions);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(
            int dwDesiredAccess,
            int bInheritHandle,
            int dwProcessID);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        #endregion

        #region 成员变量

        private SYSTEM_HANDLE_INFORMATION[] m_arr_shis = default(SYSTEM_HANDLE_INFORMATION[]);
        public SYSTEM_HANDLE_INFORMATION[] HandleInfos
        {
            get { return m_arr_shis; }
        }

        #endregion

        #region 成员函数

        public void RefreshSystemHandles()
        {
            int buf_len = 100, ret_len = 0;
            byte[] bytes_handles = new byte[buf_len];
            while (STATUS_INFO_LENGTH_MISMATCH ==
                NtQuerySystemInformation(
                    SystemHandleInformation, bytes_handles, buf_len, ref ret_len))
            {
                buf_len *= 2;
                bytes_handles = new byte[buf_len];
            }

            int handle_count = BitConverter.ToInt32(bytes_handles, 0);
            m_arr_shis = new SYSTEM_HANDLE_INFORMATION[handle_count];
            GCHandle gch = GCHandle.Alloc(m_arr_shis, GCHandleType.Pinned);
            Marshal.Copy(bytes_handles, 4, gch.AddrOfPinnedObject(), (int)ret_len);
            gch.Free();
        }

        public static string UnicodeStringToString(UNICODE_STRING str_src)
        {
            if (0 == str_src.Length) return "";

            try
            {
                char[] arr_target_string = new char[str_src.Length];
                string str_ret = new string('\0', str_src.Length);
                Marshal.Copy(str_src.Buffer, arr_target_string, 0, (int)str_src.Length);
                return new string(arr_target_string);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public List<SYSTEM_HANDLE_INFORMATION> GetProcessHandles(int pid)
        {
            RefreshSystemHandles();
            List<SYSTEM_HANDLE_INFORMATION> lst_ret = new List<SYSTEM_HANDLE_INFORMATION>();
            foreach (SYSTEM_HANDLE_INFORMATION shi in m_arr_shis)
            {
                if (shi.ProcessId == pid)
                {
                    lst_ret.Add(shi);
                }
            }

            return lst_ret;
        }

        public OBJECT_BASIC_INFORMATION GetHandleBasicInfo(int pid, UInt16 handle)
        {
            IntPtr src_proc_handle = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);
            if (IntPtr.Zero == src_proc_handle)
            {
                return default(OBJECT_BASIC_INFORMATION);
            }

            IntPtr target_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtDuplicateObject(
                    src_proc_handle, (IntPtr)handle,
                    GetCurrentProcess(), ref target_handle,
                    0, 0, DUPLICATE_SAME_ACCESS))
            {
                CloseHandle(src_proc_handle);
                return default(OBJECT_BASIC_INFORMATION);
            }

            int ret_obj_len = 0;
            int obj_len = Marshal.SizeOf(typeof(OBJECT_BASIC_INFORMATION));
            byte[] bytes_obj_info = new byte[obj_len];
            uint ret = NtQueryObject(target_handle, ObjectBasicInformation, bytes_obj_info, obj_len, ref ret_obj_len);
            if (STATUS_SUCCESS != ret)
            {
                CloseHandle(target_handle);
                CloseHandle(src_proc_handle);
                return default(OBJECT_BASIC_INFORMATION);
            }

            GCHandle gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
            OBJECT_BASIC_INFORMATION obi = (OBJECT_BASIC_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_BASIC_INFORMATION));
            gch.Free();

            CloseHandle(target_handle);
            CloseHandle(src_proc_handle);
            return obi;
        }

        public OBJECT_TYPE_INFORMATION GetHandleTypeInfo(int pid, UInt16 handle, OBJECT_BASIC_INFORMATION obi)
        {
            IntPtr src_proc_handle = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);
            if (IntPtr.Zero == src_proc_handle)
            {
                return default(OBJECT_TYPE_INFORMATION);
            }

            IntPtr target_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtDuplicateObject(
                    src_proc_handle, (IntPtr)handle,
                    GetCurrentProcess(), ref target_handle,
                    0, 0, DUPLICATE_SAME_ACCESS))
            {
                CloseHandle(src_proc_handle);
                return default(OBJECT_TYPE_INFORMATION);
            }

            int ret_obj_len = 0;
            int obj_len = obi.TypeInformationLength + 2; // sizeof(EOF) = sizeof('\0\0') = 2
            byte[] bytes_obj_info = new byte[obj_len];
            uint ret = NtQueryObject(target_handle, ObjectTypeInformation, bytes_obj_info, obj_len, ref ret_obj_len);
            if (STATUS_SUCCESS != ret)
            {
                CloseHandle(target_handle);
                CloseHandle(src_proc_handle);
                return default(OBJECT_TYPE_INFORMATION);
            }

            GCHandle gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
            OBJECT_TYPE_INFORMATION oti = (OBJECT_TYPE_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_TYPE_INFORMATION));
            gch.Free();

            CloseHandle(target_handle);
            CloseHandle(src_proc_handle);
            return oti;
        }

        public OBJECT_NAME_INFORMATION GetHandleNameInfo(int pid, UInt16 handle, OBJECT_BASIC_INFORMATION obi)
        {
            // 枚举进程句柄 - xbgprogrammer的专栏 - 博客频道 - CSDN.NET
            // http://blog.csdn.net/xbgprogrammer/article/details/26386733

            // HOWTO: Enumerate handles - Sysinternals Forums
            // http://forum.sysinternals.com/howto-enumerate-handles_topic18892.html
            if (MAGIC_FLAG == (MAGIC_FLAG & obi.GrantedAccess))
            {
                return default(OBJECT_NAME_INFORMATION);
            }

            IntPtr src_proc_handle = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);
            if (IntPtr.Zero == src_proc_handle)
            {
                return default(OBJECT_NAME_INFORMATION);
            }

            IntPtr target_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtDuplicateObject(
                    src_proc_handle, (IntPtr)handle,
                    GetCurrentProcess(), ref target_handle,
                    0, 0, DUPLICATE_SAME_ACCESS))
            {
                CloseHandle(src_proc_handle);
                return default(OBJECT_NAME_INFORMATION);
            }

            int ret_obj_len = 0;
            int obj_len = obi.NameInformationLength + 2; // sizeof(EOF) = sizeof('\0\0') = 2
            byte[] bytes_obj_info = new byte[obj_len];
            uint ret = NtQueryObject(target_handle, ObjectNameInformation, bytes_obj_info, obj_len, ref ret_obj_len);
            if (STATUS_SUCCESS != ret)
            {
                CloseHandle(target_handle);
                CloseHandle(src_proc_handle);
                return default(OBJECT_NAME_INFORMATION);
            }

            GCHandle gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
            OBJECT_NAME_INFORMATION oni = (OBJECT_NAME_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_NAME_INFORMATION));
            gch.Free();

            CloseHandle(target_handle);
            CloseHandle(src_proc_handle);
            return oni;
        }

        public PROCESS_HANDLE_INFORMATION GetProcessHandleInfo(int pid, UInt16 handle)
        {
            IntPtr src_proc_handle = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);
            if (IntPtr.Zero == src_proc_handle)
            {
                return default(PROCESS_HANDLE_INFORMATION);
            }

            IntPtr target_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtDuplicateObject(
                    src_proc_handle, (IntPtr)handle,
                    GetCurrentProcess(), ref target_handle,
                    0, 0, DUPLICATE_SAME_ACCESS))
            {
                CloseHandle(src_proc_handle);
                return default(PROCESS_HANDLE_INFORMATION);
            }

            PROCESS_HANDLE_INFORMATION phi = new PROCESS_HANDLE_INFORMATION();

            int ret_obj_len = 0;
            int obj_len = Marshal.SizeOf(typeof(OBJECT_BASIC_INFORMATION));
            byte[] bytes_obj_info = new byte[obj_len];
            uint ret = NtQueryObject(target_handle, ObjectBasicInformation, bytes_obj_info, obj_len, ref ret_obj_len);
            if (STATUS_SUCCESS != ret)
            {
                CloseHandle(target_handle);
                CloseHandle(src_proc_handle);
                return phi;
            }

            GCHandle gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
            phi.m_object_basic_info = (OBJECT_BASIC_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_BASIC_INFORMATION));
            gch.Free();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ret_obj_len = 0;
            if (0 == phi.m_object_basic_info.TypeInformationLength)
            {
                obj_len = MAX_PATH * 2;
            }
            else
            {
                obj_len = phi.m_object_basic_info.TypeInformationLength + 2; // sizeof(EOF) = sizeof('\0\0') = 2
            }

            bytes_obj_info = new byte[obj_len];
            ret = NtQueryObject(target_handle, ObjectTypeInformation, bytes_obj_info, obj_len, ref ret_obj_len);
            if (STATUS_SUCCESS != ret)
            {
                CloseHandle(target_handle);
                CloseHandle(src_proc_handle);
                return phi;
            }

            gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
            phi.m_object_type_info = (OBJECT_TYPE_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_TYPE_INFORMATION));
            gch.Free();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // 枚举进程句柄 - xbgprogrammer的专栏 - 博客频道 - CSDN.NET
            // http://blog.csdn.net/xbgprogrammer/article/details/26386733

            // HOWTO: Enumerate handles - Sysinternals Forums
            // http://forum.sysinternals.com/howto-enumerate-handles_topic18892.html
            if (MAGIC_FLAG != (MAGIC_FLAG & phi.m_object_basic_info.GrantedAccess))
            {
                ret_obj_len = 0;
                if (0 == phi.m_object_basic_info.NameInformationLength)
                {
                    obj_len = MAX_PATH * 2;
                }
                else
                {
                    obj_len = phi.m_object_basic_info.NameInformationLength + 2; // sizeof(EOF) = sizeof('\0\0') = 2
                }

                bytes_obj_info = new byte[obj_len];
                ret = NtQueryObject(target_handle, ObjectNameInformation, bytes_obj_info, obj_len, ref ret_obj_len);
                if (STATUS_SUCCESS != ret)
                {
                    CloseHandle(target_handle);
                    CloseHandle(src_proc_handle);
                    return phi;
                }

                gch = GCHandle.Alloc(bytes_obj_info, GCHandleType.Pinned);
                phi.m_object_name_info = (OBJECT_NAME_INFORMATION)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(OBJECT_NAME_INFORMATION));
                gch.Free();
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            CloseHandle(target_handle);
            CloseHandle(src_proc_handle);
            return phi;
        }

        public bool CloseProcessHandle(int pid, UInt16 handle)
        {
            CLIENT_ID cid = new CLIENT_ID();
            OBJECT_ATTRIBUTES oa = new OBJECT_ATTRIBUTES();
            cid.UniqueProcess = pid;
            oa.Length = Marshal.SizeOf(typeof(OBJECT_ATTRIBUTES));

            IntPtr src_proc_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtOpenProcess(ref src_proc_handle, PROCESS_DUP_HANDLE, ref oa, ref cid))
            {
                return false;
            }

            IntPtr target_handle = IntPtr.Zero;
            if (STATUS_SUCCESS != NtDuplicateObject(
                    src_proc_handle, (IntPtr)handle,
                    GetCurrentProcess(), ref target_handle,
                    0, 0, DUPLICATE_CLOSE_SOURCE))
            {
                return false;
            }

            return (STATUS_SUCCESS == NtClose(target_handle));
        }

        #endregion
    }
}

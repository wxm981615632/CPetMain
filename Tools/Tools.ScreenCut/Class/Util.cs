using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;

namespace Tools.ScreenCut
{
    public class Util
    {
        /// <summary>
        /// 字母按键个数
        /// </summary>
        public static int KEY_NUM = 26;


        /// <summary>
        /// 默认截图文件保存路径
        /// </summary>
        public static string DEFAULT_SAVE_PIC_PATH = "cut";

        /// <summary>
        /// 设置-文件扩展名字段
        /// </summary>
        public static string SAVE_FILE_EXTENSION = "file_extension";
        /// <summary>
        /// 默认截图文件扩展名
        /// </summary>
        public static string DEFAULT_FILE_EXTENSION = "png";
        /// <summary>
        /// 默认截图文件扩展名
        /// </summary>
        public static string SUPPORT_EXTENSION_FILTER = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|PNG(*.png)|*.png";

        public static Pen BoardPen = new Pen(new SolidBrush(System.Drawing.SystemColors.Highlight), 1.4F);

        //绘制圆角
        public static void SetWindowRegion(Control control, int radiu) {
            Rectangle rect = new Rectangle(0, 0, control.Width - 2, control.Height - 2);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);
            GraphicsPath FormPath = GetRoundedRectPath(rect, 2);
            control.Region = new Region(FormPath);
        }

        public static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius) {
            int diameter = radius * 2;
            int arcX1 = rect.X;
            int arcX2 = rect.Right - diameter;
            int arcY1 = rect.Y;
            int arcY2 = rect.Bottom - diameter;
            GraphicsPath roundedRect = new GraphicsPath();
            //   左上角
            roundedRect.AddArc(arcX1, arcY1, diameter, diameter, 180, 90);
            //roundedRect.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y);
            //   右上角
            roundedRect.AddArc(arcX2, arcY1, diameter, diameter, 270, 90);
            //roundedRect.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom - radius - 1);
            //   右下角
            roundedRect.AddArc(arcX2, arcY2, diameter, diameter, 0, 90);
            //roundedRect.AddLine(rect.Right - radius - 1, rect.Bottom, rect.X + radius, rect.Bottom);
            //   左下角
            roundedRect.AddArc(arcX1, arcY2, diameter, diameter, 90, 90);
            //roundedRect.AddLine(rect.X, rect.Bottom - radius, rect.X, rect.Y + radius);
            //roundedRect.CloseFigure();
            roundedRect.CloseAllFigures();
            return roundedRect;
        }
        public static GraphicsPath GetRoundedRectPath(RectangleF rect, float radius) {
            float diameter = radius * 2;
            float arcX1 = rect.X;
            float arcX2 = rect.Right - diameter;
            float arcY1 = rect.Y;
            float arcY2 = rect.Bottom - diameter;
            GraphicsPath roundedRect = new GraphicsPath();
            //   左上角
            roundedRect.AddArc(arcX1, arcY1, diameter, diameter, 180, 90);
            //roundedRect.AddLine(rect.X + radius, rect.Y, rect.Right - radius, rect.Y);
            //   右上角
            roundedRect.AddArc(arcX2, arcY1, diameter, diameter, 270, 90);
            //roundedRect.AddLine(rect.Right, rect.Y + radius, rect.Right, rect.Bottom - radius - 1);
            //   右下角
            roundedRect.AddArc(arcX2, arcY2, diameter, diameter, 0, 90);
            //roundedRect.AddLine(rect.Right - radius - 1, rect.Bottom, rect.X + radius, rect.Bottom);
            //   左下角
            roundedRect.AddArc(arcX1, arcY2, diameter, diameter, 90, 90);
            //roundedRect.AddLine(rect.X, rect.Bottom - radius, rect.X, rect.Y + radius);
            //roundedRect.CloseFigure();
            roundedRect.CloseAllFigures();
            return roundedRect;
        }

        public static bool isZeroRect(Rectangle r) {
            return (r.X == 0 && r.Y == 0 && r.Height == 0 && r.Height == 0);
        }

        /// <summary>
        /// 根据控件名获取控件实例
        /// </summary>
        /// <param name="name">控件名</param>
        /// <returns>控件实例 需强制转换为对应控件类型</returns>
        public static object GetControlByName(Form frm,string name) {
            object o = frm.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance).GetValue(frm);
            return o;
        }
        /// <summary>
        /// 保存时获取当前时间字符串作为默认文件名
        /// </summary>
        /// <returns>当前时间字符串文件名</returns>
        public static string GetSavePicPath() {
            string path = "cut";
            string extention = "png";
            if (string.IsNullOrEmpty(path))
                path = Util.DEFAULT_SAVE_PIC_PATH;
            if (string.IsNullOrEmpty(extention))
                extention = Util.DEFAULT_FILE_EXTENSION;
            if (!Directory.Exists(path))
                CreateDeepFolder(path);
            return string.Format("{0}\\{1}.{2}", path, DateTime.Now.ToString("yyyyMMdd HHmmss"), extention);
        }


        private static bool CreateDeepFolder(string path) {
            bool result;
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Parent.Exists) {
                result = CreateDeepFolder(di.Parent.FullName);
            }
            di.Create();
            result = true;
            return result;
        }

        /// <summary>
        /// 生成唯一的32位字符串ID
        /// </summary>
        /// <returns></returns>
        public static string GUID {
            get { return Guid.NewGuid().ToString().Replace("-", ""); }
        }
    }

    //截图类型
    public enum PrintType
    {
        WholeScreen, ActiveWin, FreeScreen
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;                            //最左坐标
        public int Top;                             //最上坐标
        public int Right;                           //最右坐标
        public int Bottom;                          //最下坐标
    }

    //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
    [Flags()]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        WindowsKey = 8
    }
}

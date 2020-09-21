using Common;
using DSkin.Common;
using DSkin.Forms;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Plugin.Weather
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
            IniHelper.Instance.FileName = "conf/weather.ini";
            
        }

        DateTime last;
        DateTime next;
        string city = "";
        private void FrmMain_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Location = new Point(IniHelper.Instance.ReadInteger("Setting", "location_x", 0), IniHelper.Instance.ReadInteger("Setting", "location_y", 0));
            last = Convert.ToDateTime(IniHelper.Instance.ReadString("Setting","last",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            next = Convert.ToDateTime(IniHelper.Instance.ReadString("Setting", "next", last.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss")));
            IniHelper.Instance.WriteString("Setting", "last",last.ToString("yyyy-MM-dd HH:mm:ss"));
            IniHelper.Instance.WriteString("Setting", "next", next.ToString("yyyy-MM-dd HH:mm:ss"));
            city = IniHelper.Instance.ReadString("Setting", "city", "");
            this.Opacity = ((double)IniHelper.Instance.ReadInteger("Setting", "opacity", 90))/100;
            loadData(true);
        }

        private bool is_update = false;

        private void 置顶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (置顶ToolStripMenuItem.Checked)
            {
                this.TopMost = false;
                置顶ToolStripMenuItem.Checked = false;
            }
            else
            {
                this.TopMost = false;
                置顶ToolStripMenuItem.Checked = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point oPointClicked; // 用于窗体移动
        bool is_move = false;
        private void down(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                is_move = true;
                oPointClicked = new Point(e.X, e.Y);
            }
        }

        private void move(object sender, MouseEventArgs e)
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

        private void up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && is_move)
            {
                is_move = false;
                if (Location.X >= 0)
                {
                    IniHelper.Instance.WriteInteger("Setting", "location_x", Location.X);
                }
                if (Location.Y >= 0)
                {
                    IniHelper.Instance.WriteInteger("Setting", "location_y", Location.Y);
                }
            }
        }

        

        Result re = new Result ();
        private void loadData(bool status = false)
        {
            if ((next <= DateTime.Now&& is_update==false)||status)
            {
                is_update = true;
                DateTime now = last = DateTime.Now;
                next = now.AddHours(2);
                IniHelper.Instance.WriteString("Setting", "last", now.ToString("yyyy-MM-dd HH:mm:ss"));
                IniHelper.Instance.WriteString("Setting", "next", next.ToString("yyyy-MM-dd HH:mm:ss"));
                //开始获取数据
                re = Common.JsonHelper.JSONString<Result>(Action(city));
                //re = Weather.getWeather(city);
                if (re.status != 200)
                {
                    DSkinMessageBox.Show(re.message);
                    this.Close();
                }
                fo.result = re;
                dSkinPictureBox1.Image = System.Drawing.Image.FromFile(Weather.changeImg(re.data.forecast[0].type));
                label1.Text = re.cityInfo.city;
                label2.Text = re.data.wendu;
                dSkinLabel1.Text = now.ToString("MM-dd");
                dSkinLabel2.Text = re.data.forecast[0].week;
                dSkinLabel3.Text = Common.TimeHelper.GetChineseDateTime(now);
                dSkinLabel4.Text = re.data.forecast[0].type + "    " + re.data.forecast[0].low.Replace("低温", "").Replace(" ", "").Replace("℃", "") + " ～" + re.data.forecast[0].high.Replace("高温", "").Replace(" ", "").Replace("℃", "") + "℃";
                dSkinLabel5.Text = re.data.forecast[0].fx + "    " + re.data.forecast[0].fl;
                dSkinLabel6.Text = "更新时间    "+re.cityInfo.updateTime;
                //获取数据结束
                is_update = false;
            }
        }
        

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <returns></returns>
        public static bool AddCache(string City, string JsonData)
        {
            string Path = FolderName + string.Format(FileName + DateTime.Now.ToString("HH.mm.ss"), City) + CacheSuffixName;
            File.WriteAllText(Path, JsonData);
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadData();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadData(true);
        }

        #region 
        /// <summary>
        /// 缓存文件夹名称
        /// </summary>
        public static string FolderName = "conf/SHRFID-Weather/";
        /// <summary>
        /// CityCode - 时间戳  存储的数据名的格式
        /// </summary>
        public static string FileName = "{0}-";
        /// <summary>
        /// 缓存后缀名
        /// </summary>
        public static string CacheSuffixName = ".ini";
        /// <summary>
        /// 数据缓存多少秒
        /// </summary>
        public static int _CacheTime = 3600;

        /// <summary>
        /// 动作逻辑
        /// </summary>
        /// <returns></returns>
        public static string Action(string City)
        {
            //1.先查缓存
            string RetCacheData = QueryCache(City);
            if (RetCacheData != null)
            {
                //说明已经查过
                return RetCacheData;
            }
            else
            {
                //说明没查过得Get一下
                string GetData = Weather.getWeather2(City);
                if (GetData != null)
                {
                    //添加缓存
                    if (AddCache(City, GetData))
                    {
                        return GetData;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 查询缓存
        /// </summary>
        /// <returns></returns>
        public static string QueryCache(string City)
        {
            DirectoryInfo folder = new DirectoryInfo(FolderName);
            foreach (FileInfo file in folder.GetFiles("*.ini"))
            {
                if (file.Name.Length > 0)
                {
                    string[] _FileName = file.Name.Split('-');
                    if (_FileName[0].Contains(City))
                    {
                        string LsTime = _FileName[1].Replace(".ini", "").Replace(".", ":");
                        DateTime LS_Time = Convert.ToDateTime(LsTime);  //历史时间
                        DateTime DT_Time = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));  //当前时间
                        TimeSpan XXX = DT_Time - LS_Time;
                        if (XXX.TotalSeconds > 0)
                        {
                            if (XXX.TotalSeconds > _CacheTime)  //大于或者等于，则清除
                            {
                                File.Delete(FolderName + file.Name);
                            }
                            else
                            {
                                return ShowWeatherJosnData(FolderName + file.Name);
                            }
                        }
                        else
                        {
                            File.Delete(FolderName + file.Name);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 获取本地文本数据
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string ShowWeatherJosnData(string Path)
        {
            StreamReader Sr = File.OpenText(Path);
            string Node = null;
            while (!Sr.EndOfStream)
            {
                Node += Sr.ReadLine();
            }
            Sr.Dispose();
            Sr.Close();
            return Node;
        }
        #endregion
        FrmOther fo = new FrmOther();
        private void show1(object sender, EventArgs e)
        {
            getOtherLocation();
            fo.timer1.Enabled = true;
            fo.Show();
        }
        private void hide1(object sender, EventArgs e)
        {
            //fo.Hide();
        }

        private void getOtherLocation()
        {
            int x = this.Location.X;
            int y = this.Location.Y+this.Height+5;
            int px = x + fo.Width - Screen.GetWorkingArea(this).Width;
            int py = y + fo.Height - Screen.GetWorkingArea(this).Height;
            if (px > 0) x = x - px;
            if (py > 0) y = this.Location.Y - this.Height - 5;
            fo.Location = new Point(x,y);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fo.Close();
        }
    }
}

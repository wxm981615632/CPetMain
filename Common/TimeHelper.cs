using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Common
{
    public class TimeHelper
    {
        /// <summary>  
        /// 获取当前时间戳  
        /// </summary>  
        /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>  
        /// <returns></returns>  
        public static int GetTimeStamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return int.Parse(ret);
        }

        public static int GetTimeStamp(DateTime time, bool bflag = true)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 8, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return int.Parse(ret);
        }

        public static string GetTimeStamp(int time, bool bflag = true)
        {
            DateTime s = new DateTime(1970, 1, 1, 8, 0, 0, 0);
            s = s.AddSeconds(time);
            return s.ToString("HH:mm:ss");
        }
        public static DateTime ConvertTimeStampToDateTime(int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return dtStart.AddSeconds(timeStamp);
        }

        //转换农历
        //C# 获取农历日期

        ///<summary>
        /// 农历月
        ///</summary>

        ///<return s></return s>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)" };

        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };


        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<return s></return s>
        public static string GetLunisolarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }

        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<return s></return s>
        public static string GetLunisolarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days[(day - 1) / 10], days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }



        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="datetime">公历日期</param>
        ///<return s></return s>
        public static string GetChineseDateTime(DateTime datetime)
        {
            ChineseLunisolarCalendar ChineseCalendar = new ChineseLunisolarCalendar();
            int year = ChineseCalendar.GetYear(datetime);
            int month = ChineseCalendar.GetMonth(datetime);
            int day = ChineseCalendar.GetDayOfMonth(datetime);
            //获取闰月， 0 则表示没有闰月
            int leapMonth = ChineseCalendar.GetLeapMonth(year);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isleap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }

            return string.Concat(isleap ? "闰" : string.Empty, GetLunisolarMonth(month), "月", GetLunisolarDay(day));
        }
    }
}

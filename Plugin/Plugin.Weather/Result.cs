using DSkin.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Weather
{
    public class Result
    {
        public string time { set; get; }//系统更新时间
        public CityInfo cityInfo { set; get; }

        public string date { set; get; }//当前天气的当天日期
        public string message { set; get; }//返回message
        public int status { set; get; }//返回状态

        public data data { set; get; }
    }

    public class CityInfo
    {
        public string city { get; set; }//请求城市

        public string cityId { get; set; }//请求城市ID
        public string parent { get; set; }//上级，一般是省份
        public string updateTime { get; set; }//天气更新时间
    }


    public class data
    {
        public string shidu { set; get; }//湿度
        public string pm25 { set; get; }//pm2.5
        public string pm10 { set; get; }//pm10
        public string quality { set; get; }//空气质量
        public string wendu { set; get; }//温度
        public string ganmao { set; get; }//感冒提醒（指数）
        public perday yesterday { set; get; }//昨天天气

        public List<perday> forecast { set; get; }//今天+未来4天
    }

    public class perday
    {
        public string date { set; get; }//日
        public string ymd { set; get; }//年月日  （新增）
        public string week { set; get; }//星期 （新增）
        public string sunrise { set; get; }//日出
        public string high { set; get; }//当天最高温
        public string low { set; get; }//当天最低温
        public string sunset { set; get; } //空气指数
        public string aqi { set; get; }//日落
        public string fx { set; get; }//风向
        public string fl { set; get; }//风力
        public string type { set; get; }//天气
        public string notice { set; get; }//天气描述

    }

}

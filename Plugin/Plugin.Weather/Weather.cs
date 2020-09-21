using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;

namespace Plugin.Weather
{
    public class Weather
    {
        public static Result getWeather(string cityid="")
        {
            string baseurl = "http://t.weather.itboy.net/api/weather/city/";
            Result result = new Result();
            string str = Common.HttpHelper.Get(baseurl+cityid);
            result = Common.JsonHelper.JSONString<Result>(str);
            if (result.status != 200)
            {
                DSkinMessageBox.Show(result.message);
                return null;
            }
            return result;
        }

        public static string getWeather2(string cityid = "")
        {
            string baseurl = "http://t.weather.itboy.net/api/weather/city/";
            string str = Common.HttpHelper.Get(baseurl + cityid);
            return str;
        }

        

        public static string changeImg(string type = "晴",bool status=true)
        {
            int now = Convert.ToInt32(DateTime.Now.Hour);
            switch (type)
            {
                case "晴":
                    if ((now < 6 || now > 19)&&status)
                    {
                        type = "夜晴";
                    }
                    else
                    {
                        type = "日晴";
                    }
                    break;
                case "小雨":
                    type = "小雨";
                    break;
                case "小到中雨":
                    type = "小到中雨";
                    break;
                case "中雨":
                    type = "中雨";
                    break;
                case "中到大雨":
                    type = "中到大雨";
                    break;
                case "大雨":
                    type = "大雨";
                    break;
                case "大到暴雨":
                    type = "大到暴雨";
                    break;
                case "暴雨":
                    type = "暴雨";
                    break;
                case "暴雨到大暴雨":
                    type = "暴雨到大暴雨";
                    break;
                case "大暴雨":
                    type = "大暴雨";
                    break;
                case "大暴雨到特大暴雨":
                    type = "大暴雨到特大暴雨";
                    break;
                case "特大暴雨":
                    type = "特大暴雨";
                    break;
                case "冻雨":
                    type = "冻雨";
                    break;
                case "阵雨":
                    type = "阵雨";
                    break;
                case "雷阵雨":
                    type = "雷阵雨";
                    break;
                case "雨夹雪":
                    type = "雨夹雪";
                    break;
                case "雷阵雨伴有冰雹":
                    type = "雷阵雨伴有冰雹";
                    break;
                case "小雪":
                    type = "小雪";
                    break;
                case "小到中雪":
                    type = "小到中雪";
                    break;
                case "中雪":
                    type = "中雪";
                    break;
                case "中到大雪":
                    type = "中到大雪";
                    break;
                case "大雪":
                    type = "大雪";
                    break;
                case "大到暴雪":
                    type = "大到暴雪";
                    break;
                case "暴雪":
                    type = "暴雪";
                    break;
                case "阵雪":
                    type = "阵雪";
                    break;
                case "多云":
                    if ((now < 6 || now > 19) && status)
                    {
                        type = "夜间多云";
                    }
                    else
                    {
                        type = "日间多云";
                    }
                    break;
                case "阴":
                    type = "阴";
                    break;
                case "强沙尘暴":
                    type = "强沙尘暴";
                    break;
                case "扬沙":
                    type = "扬沙";
                    break;
                case "沙尘暴":
                    type = "沙尘暴";
                    break;
                case "浮尘":
                    type = "浮尘";
                    break;
                case "雾":
                    type = "雾";
                    break;
                case "大雾":
                    type = "大雾";
                    break;
                case "浓雾":
                    type = "浓雾";
                    break;
                case "强浓雾":
                    type = "强浓雾";
                    break;
                case "特强浓雾":
                    type = "特强浓雾";
                    break;
                case "霾":
                    type = "霾";
                    break;
                case "中度霾":
                    type = "中度霾";
                    break;
                case "严重霾":
                    type = "严重霾";
                    break;
                case "重度霾":
                    type = "重度霾";
                    break;
                default:
                    type = "无";
                    break;
            }
            return "img/weather/" + type + ".png";
        }
    }
}

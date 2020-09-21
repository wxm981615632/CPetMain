using DSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Plugin.Ocr
{
    public class BaseController
    {
        //https://cloud.baidu.com/doc/OCR/OCR-Csharp-SDK.html
        string APP_ID = "22370585";
        string API_KEY = "BiXZOamgnZoDjjtE4wXyGd05";
        string SECRET_KEY = "AtijlVh5MWDg9h4bfMPBTychzKW6NHKD ";

        public string AdvancedGeneralDemo(Image url, int category=0,string other= "front")
        {
            
            byte[] image = Common.ImageHelper.ImageToBytes(url);
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            JObject result = null;
            switch (category)
            {
                case 0://通用文字识别
                    result = client.AccurateBasic(image);
                    break;
                case 1://生僻字识别
                    result = client.GeneralEnhanced(image);
                    break;
                case 2://身份证识别
                    result = client.Idcard(image, other);
                    break;
                case 3://银行卡识别
                    result = client.Bankcard(image);
                    break;
                case 4://驾驶证识别
                    result = client.DrivingLicense(image);
                    break;
                case 5://行驶证识别
                    result = client.VehicleLicense(image);
                    break;
                case 6://车牌识别
                    result = client.LicensePlate(image);
                    break;
                case 7://通用票据识别
                    result = client.Receipt(image);
                    break;
                case 8://营业执照识别
                    result = client.BusinessLicense(image);
                    break;
                default://通用文字识别
                    result = client.AccurateBasic(image);
                    break;
            }
            Console.WriteLine(result);
            if (result == null)
            {
                return "";
            }
            return JsonConvert.SerializeObject(result);
        }

    }
}

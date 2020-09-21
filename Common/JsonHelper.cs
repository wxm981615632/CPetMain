﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Common
{
    public class JsonHelper
    {
        public static T JSONString<T>(string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            T objs = Serializer.Deserialize<T>(JsonStr);
            return objs;
        }
        #region 提取json对象
        /// <summary>
        /// 提取json字符串对象
        /// 例如输入：{"1":1,"a":"aa","aa":"{\"2\":2,\"bb\":\"{\\\"3\\\":3,\\\"cc\\\":\\\"ccc\\\"}\"}"}
        /// 例如输出：{"1":1,"a":"aa","aa":{"2":2,"bb":{"3":3,"cc":"ccc"}}}
        /// </summary>
        public static JObject ExtractObj(string jsonObject)
        {
            return ExtractObj(JObject.Parse(jsonObject));
        }
        /// <summary>
        /// 提取json对象
        /// 例如输入：{"1":1,"a":"aa","aa":"{\"2\":2,\"bb\":\"{\\\"3\\\":3,\\\"cc\\\":\\\"ccc\\\"}\"}"}
        /// 例如输出：{"1":1,"a":"aa","aa":{"2":2,"bb":{"3":3,"cc":"ccc"}}}
        /// </summary>
        public static JObject ExtractObj(JObject job)
        {
            foreach (var item in job)
            {
                var itemV = item.Value;
                if (itemV.Type == JTokenType.String)
                {
                    var jtStr = itemV.ToString();
                    if (!IsJson(jtStr))
                        continue;

                    JToken jToken = JToken.Parse(jtStr);
                    if (jToken.Type == JTokenType.Object)
                        job[item.Key] = ExtractObj((JObject)jToken);
                    else if (jToken.Type == JTokenType.Array)
                        job[item.Key] = ExtractArr((JArray)jToken);

                }
                else if (itemV.Type == JTokenType.Object)
                {
                    job[item.Key] = ExtractObj((JObject)itemV);
                }
                else if (itemV.Type == JTokenType.Array)
                {
                    job[item.Key] = ExtractArr((JArray)itemV);
                }
            }
            return job;
        }
        #endregion

        #region 提取json数组
        /// <summary>
        /// 提取json字符串数组
        /// 例如输入：["5","6","[\"3\",\"4\",\"[\\\"1\\\",\\\"2\\\"]\"]"]
        /// 例如输出：["5","6",["3","4",["1","2"]]]
        /// </summary>
        public static JArray ExtractArr(string jsonArr)
        {
            return ExtractArr(JArray.Parse(jsonArr));
        }
        /// <summary>
        /// 提取json数组
        /// 例如输入：["5","6","[\"3\",\"4\",\"[\\\"1\\\",\\\"2\\\"]\"]"]
        /// 例如输出：["5","6",["3","4",["1","2"]]]
        /// </summary>
        /// <param name="jArr"></param>
        /// <returns></returns>
        public static JArray ExtractArr(JArray jArr)
        {
            //方法一：慢（3700个字符耗时2.2-2.4秒）
            //for (int i = 0; i < jArr.Count; i++)
            //{
            //    try
            //    {
            //        string itemStr = jArr[i].ToString();
            //        JArray itemJArr = JArray.Parse(itemStr);
            //        JArray rArr = ExtractArr(itemJArr);
            //        jArr[i] = rArr;
            //    }
            //    catch
            //    {
            //        try
            //        {
            //            string itemStr = jArr[i].ToString();
            //            JObject itemJObj = JObject.Parse(itemStr);
            //            JObject robj = ExtractObj(itemJObj);
            //            jArr[i] = robj;
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
            //return jArr;

            //方法二：快（3700个字符耗时40-60毫秒）
            for (int i = 0; i < jArr.Count; i++)
            {
                JToken jToken = jArr[i];
                if (jToken.Type == JTokenType.String)
                {
                    var jtStr = jToken.ToString();
                    if (!IsJson(jtStr))
                        continue;

                    JToken jToken2 = JToken.Parse(jtStr);
                    if (jToken2.Type == JTokenType.Array)
                    {
                        jArr[i] = ExtractArr((JArray)jToken2);
                    }
                    else if (jToken2.Type == JTokenType.Object)
                    {
                        jArr[i] = ExtractObj((JObject)jToken2);
                    }
                }
                else if (jToken.Type == JTokenType.Array)
                {
                    jArr[i] = ExtractArr((JArray)jToken);
                }
                else if (jToken.Type == JTokenType.Object)
                {
                    jArr[i] = ExtractObj((JObject)jToken);
                }
            }
            return jArr;
        }
        #endregion

        #region 提取json对象或数组
        /// <summary>
        /// 提取json字符串（支持json字符串的对象、数组、字符串）
        /// 例如输入：["5","6","[\"3\",\"4\",\"[\\\"1\\\",\\\"2\\\"]\"]","{\"1\":2,\"a\":\"ab\"}"]
        /// 例如输出：["5","6",["3","4",["1","2"]],{"1":2,"a":"ab"}]
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JToken ExtractAll(string json)
        {
            try
            {
                return ExtractAll(JToken.Parse(json));
            }
            catch
            {
                throw new Exception("不是有效的JToken对象");
            }
        }
        /// <summary>
        /// 提取json（支持json对象、数组、字符串）
        /// 例如输入：["5","6","[\"3\",\"4\",\"[\\\"1\\\",\\\"2\\\"]\"]","{\"1\":2,\"a\":\"ab\"}"]
        /// 例如输出：["5","6",["3","4",["1","2"]],{"1":2,"a":"ab"}]
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JToken ExtractAll(JToken jToken)
        {
            if (jToken.Type == JTokenType.String)
            {
                jToken = JToken.Parse(jToken.ToString());
            }

            if (jToken.Type == JTokenType.Object)
            {
                return ExtractObj((JObject)jToken);
            }
            else if (jToken.Type == JTokenType.Array)
            {
                return ExtractArr((JArray)jToken);
            }
            else
            {
                throw new Exception("暂不支持提取[" + jToken.Type.ToString() + "]类型");
            }
        }

        #endregion

        /// <summary>
        /// 是否为json（开头是'{','['的）
        /// </summary>
        public static bool IsJson(string json)
        {
            json = json.Trim();
            if (string.IsNullOrEmpty(json))
                return false;

            var t = json.First();
            if (t == '{' || t == '[')
                return true;

            return false;
        }

    }
}

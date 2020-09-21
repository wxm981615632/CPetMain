using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Express
{
    public class Result
    {

        public string id { set; get; }
        public string name { set; get; }
        public string order { set; get; }
        public int num { set; get; }
        public string updateTime { set; get; }
        public string message { set; get; }
        public int errCode { set; get; }
        /**
         * 返回错误码：
            0：无错误， 
            1：快递KEY无效， 
            2：快递代号无效， 
            3：访问次数达到最大额度，
            4：查询服务器返回错误即返回状态码非200,
            5：程序执行出错
         */
        public int status { set; get; }
        /**
         *	订单跟踪状态：
            0：查询出错（即errCode!=0），
            1：暂无记录，
            2：在途中，
            3：派送中，
            4：已签收，
            5：拒收，
            6：疑难件
            7：退回
         * 
         */
        public List<Per> data { set; get; }
    }
    public class Per
    {
        public string time { set; get; }
        public string content { set; get; }
    }
    public class ExpressCode
    {
        public string code { set; get; }
        public string name { set; get; }
    }
}

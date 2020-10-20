using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Water.Open2
{
    public class Result_All
    {
        public int code { set; get; }
        public string msg { set; get; }
        public List<Map_All> data { set; get; }
    }

    public class Map_All
    {
        public string title { set; get; }
        public string details { set; get; }
    }

    public class Result_Info
    {
        public int code { set; get; }
        public string msg { set; get; }
        public List<Map_Info> data { set; get; }
    }

    public class Map_Info
    {
        //id,name,process,type,value
        public int id { set; get; }
        public string name { set; get; }
        public string process { set; get; }
        public int type { set; get; }
        public string[] values { set; get; }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Password
{
    public class Pass
    {
        public int id { set; get; }
        public int cate_id { set; get; }
        public string title { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string url { set; get; }
        public string details { set; get; }
    }

    public class Cate
    {
        public int id { set; get; }

        public int pid { set; get; }
        public string name { set; get; }
        public string password { set; get; }
    }
}

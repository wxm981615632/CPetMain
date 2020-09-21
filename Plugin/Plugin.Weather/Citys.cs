using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Weather
{
    public class Citys
    {
        public int id { set; get; }
        public int pid { set; get; }
        public string city_code { set; get; }
        public string city_name { set; get; }
    }

    public class Loads
    {
        public int province_id { set; get; }
        public int city_id { set; get; }
        public int town_id { set; get; }
        public List<Citys> province_list { set; get; }
        public List<Citys> city_list { set; get; }
        public List<Citys> town_list { set; get; }
    }

}

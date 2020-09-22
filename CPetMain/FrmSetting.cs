using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPetMain
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            loadWeather();
        }
        string weather_city = "101010100";
        string weather_site = "北京";
        int weather_opacity = 90;
        Plugin.Weather.Loads result;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString();
            weather_opacity = trackBar1.Value;
        }

        private void loadWeather()
        {
            Common.IniHelper.Instance.FileName = "conf/weather.ini";
            //获取citycode
            weather_city = Common.IniHelper.Instance.ReadString("Setting", "city", "101010100");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", "1");
            dic.Add("code", weather_city);
            string re = Common.HttpHelper.Post(Common.IniHelper.Instance.ReadString("Setting", "city_api", "http://cpet.smallchen.com/api/Client/getWeatherCity"), dic);
            result = Common.JsonHelper.JSONString<Plugin.Weather.Loads>(re);
            //加载城市列表
            int index = 0;
            foreach (Plugin.Weather.Citys city in result.province_list)
            {
                comboBox1.Items.Add(city.city_name);
                if (city.id == result.province_id)
                {
                    comboBox1.SelectedIndex = index;
                }
                index++;
            }
            comboBox2.Enabled = !(result.city_id == 0);
            comboBox3.Enabled = !(result.town_id == 0);
            index = 0;
            foreach (Plugin.Weather.Citys city in result.city_list)
            {
                comboBox2.Items.Add(city.city_name);
                if (city.id == result.city_id)
                {
                    comboBox2.SelectedIndex = index;
                }
                index++;
            }
            index = 0;
            foreach (Plugin.Weather.Citys city in result.town_list)
            {
                comboBox3.Items.Add(city.city_name);
                if (city.id == result.town_id)
                {
                    comboBox3.SelectedIndex = index;
                }
                index++;
            }
            weather_selected = true;
        }
        bool weather_selected = false;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weather_selected)
            {
                Common.IniHelper.Instance.FileName = "conf/weather.ini";
                //获取选中的省份ID
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                int province_id = result.province_list[comboBox1.SelectedIndex].id;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("type", "0");
                dic.Add("pid", province_id.ToString());
                string re = Common.HttpHelper.Post(Common.IniHelper.Instance.ReadString("Setting", "city_api", "http://cpet.smallchen.com/api/Client/getWeatherCity"), dic);
                List<Plugin.Weather.Citys> citys = Common.JsonHelper.JSONString<List<Plugin.Weather.Citys>>(re);
                //加载城市列表
                foreach (Plugin.Weather.Citys city in citys)
                {
                    comboBox2.Items.Add(city.city_name);
                }
                result.province_id = province_id;
                result.city_list = citys;
                if (citys.Count > 0)
                {
                    comboBox2.Enabled = true;
                }
                else
                {
                    comboBox2.Enabled = false;
                }
                if (result.province_list[comboBox1.SelectedIndex].city_code != "")
                {
                    weather_city = result.province_list[comboBox1.SelectedIndex].city_code;
                    weather_site = result.province_list[comboBox1.SelectedIndex].city_name;
                }
                comboBox2.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.IniHelper.Instance.FileName = "conf/weather.ini";
            Common.IniHelper.Instance.WriteString("Setting", "city", weather_city);
            Common.IniHelper.Instance.WriteString("Setting", "site", weather_site);
            Common.IniHelper.Instance.WriteInteger("Setting", "opacity", weather_opacity);
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weather_selected)
            {
                comboBox2.Refresh();
                Common.IniHelper.Instance.FileName = "conf/weather.ini";
                //获取选中的省份ID
                comboBox3.Items.Clear();
                int city_id = result.city_list[comboBox2.SelectedIndex].id;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("type", "0");
                dic.Add("pid", city_id.ToString());
                string re = Common.HttpHelper.Post(Common.IniHelper.Instance.ReadString("Setting", "city_api", "http://cpet.smallchen.com/api/Client/getWeatherCity"), dic);
                List<Plugin.Weather.Citys> citys = Common.JsonHelper.JSONString<List<Plugin.Weather.Citys>>(re);
                //加载城市列表
                foreach (Plugin.Weather.Citys city in citys)
                {
                    comboBox3.Items.Add(city.city_name);
                }
                result.city_id = city_id;
                result.town_list = citys;
                if (citys.Count > 0)
                {
                    comboBox3.Enabled = true;
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    if (result.city_list[comboBox2.SelectedIndex].city_code != "")
                    {
                        weather_city = result.city_list[comboBox2.SelectedIndex].city_code;
                        weather_site = result.city_list[comboBox2.SelectedIndex].city_name;
                    }
                    comboBox3.Enabled = false;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (result.town_list.Count > 0 && weather_selected)
            {
                Plugin.Weather.Citys city = result.town_list[comboBox3.SelectedIndex];
                weather_city = city.city_code;
                weather_site = city.city_name;
            }
        }
    }
}

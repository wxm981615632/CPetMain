using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools.FormatJson
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(string str="")
        {
            InitializeComponent();
            if (!Common.JsonHelper.IsJson(str))
            {
                dSkinChatRichTextBox1.Text = str;
                DSkinMessageBox.Show("不是JSON数据");
                return;
            }
            dSkinChatRichTextBox1.Text = "";
            dSkinChatRichTextBox1.AppendText(ConvertJsonString(str));
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private string ConvertJsonString(string str)
        {
            try
            {
                //格式化json字符串
                JsonSerializer serializer = new JsonSerializer();
                TextReader tr = new StringReader(str);
                JsonTextReader jtr = new JsonTextReader(tr);
                object obj = serializer.Deserialize(jtr);
                if (obj != null)
                {
                    StringWriter textWriter = new StringWriter();
                    JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4,
                        IndentChar = ' '
                    };
                    serializer.Serialize(jsonWriter, obj);
                    return textWriter.ToString();
                }

                return str;
            }
            catch (Exception ex)
            {
                DSkinMessageBox.Show(ex.ToString());
                return  "";
            }
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            string str = dSkinChatRichTextBox1.Text;
            if (!Common.JsonHelper.IsJson(str))
            {
                DSkinMessageBox.Show("不是JSON数据");
                return;
            }
            dSkinChatRichTextBox1.Text = "";
            dSkinChatRichTextBox1.AppendText(ConvertJsonString(str));
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            string str = dSkinChatRichTextBox1.Text;
            if (!Common.JsonHelper.IsJson(str))
            {
                DSkinMessageBox.Show("不是JSON数据");
                return;
            }
            dSkinChatRichTextBox1.Text = "";
            dSkinChatRichTextBox1.AppendText(JsonConvert.SerializeObject(Common.JsonHelper.ExtractObj(str)));
        }
    }
}

using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Ocr
{
    public partial class FrmResult : DSkinForm
    {
        public FrmResult()
        {
            InitializeComponent();
        }

        public FrmResult(string str)
        {
            InitializeComponent();
            dSkinChatRichTextBox1.AppendText(str);
        }

        private void FrmResult_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.FormatJson.FrmMain frm = new Tools.FormatJson.FrmMain(dSkinChatRichTextBox1.Text);
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetDataObject(dSkinChatRichTextBox1.Text);
            System.Diagnostics.Process.Start("https://www.sojson.com/");
        }
    }
}

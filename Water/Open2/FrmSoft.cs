using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Water.Open2
{
    public partial class FrmSoft : Form
    {
        public FrmSoft()
        {
            InitializeComponent();
        }
        private string base_url = "http://cpet.smallchen.com/api/Open2/";
        private void FrmSoft_Load(object sender, EventArgs e)
        {
            string str = HttpHelper.Post(base_url + "getAllSoft");
            Result_All res = HttpHelper.JSONString<Result_All>(str);
            if (res.code == 1)
            {
                foreach (Map_All ma in res.data)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = index+1;
                    this.dataGridView1.Rows[index].Cells[1].Value = ma.title;
                    this.dataGridView1.Rows[index].Cells[2].Value = ma.details;
                }
            }
        }

        
    }
}

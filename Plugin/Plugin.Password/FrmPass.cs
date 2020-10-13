using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Password
{
    public partial class FrmPass : DSkinForm
    {
        public FrmPass()
        {
            InitializeComponent();
        }
        int type = 0;
        int id = 0;
        public FrmPass(int type=0,int id=0)
        {
            InitializeComponent();
            //type==0，id为分类，新增
            //type==1，id为主键，编辑
            //type==2，id为主键，详情
            this.type = type;
            this.id = id;
        }

        private void FrmPass_Load(object sender, EventArgs e)
        {
            if (type != 0)
            {
                Pass p = LoadPass();
                dSkinTextBox1.Text = p.title;
                dSkinTextBox2.Text = p.username;
                dSkinTextBox3.Text = p.password;
                dSkinTextBox4.Text = p.url;
                dSkinTextBox5.Text = p.details;
                if (type == 2)
                {
                    dSkinTextBox1.ReadOnly = 
                        dSkinTextBox2.ReadOnly = 
                        dSkinTextBox3.ReadOnly = 
                        dSkinTextBox4.ReadOnly = 
                        dSkinTextBox5.ReadOnly = true;
                    dSkinButton1.Enabled = button1.Enabled =false;
                }
            }
        }

        private Pass LoadPass()
        {
            Pass p = new Pass();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,cate_id,title,username,password,url,details from password where id=" + id + " limit 1");
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                p.id = Convert.ToInt32(mDr[0].ToString());
                p.cate_id = Convert.ToInt32(mDr[1].ToString());
                p.title = mDr[2].ToString();
                p.username = mDr[3].ToString();
                p.password = mDr[4].ToString();
                p.url = mDr[5].ToString();
                p.details = mDr[6].ToString();
            }
            return p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNewPass frm = new FrmNewPass();
            frm.ShowDialog();
            if (frm.status)
            {
                dSkinTextBox3.Text = frm.password;
            }
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into password (cate_id,title,username,password,url,details) values (")
                    .Append(id).Append(",")
                    .Append("'").Append(dSkinTextBox1.Text).Append("',")
                    .Append("'").Append(dSkinTextBox2.Text).Append("',")
                    .Append("'").Append(dSkinTextBox3.Text).Append("',")
                    .Append("'").Append(dSkinTextBox4.Text).Append("',")
                    .Append("'").Append(dSkinTextBox5.Text).Append("')");
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("update password set ")
                    .Append("title = '").Append(dSkinTextBox1.Text).Append("',")
                    .Append("username = '").Append(dSkinTextBox2.Text).Append("',")
                    .Append("password = '").Append(dSkinTextBox3.Text).Append("',")
                    .Append("url = '").Append(dSkinTextBox4.Text).Append("',")
                    .Append("details = '").Append(dSkinTextBox5.Text).Append("'")
                    .Append(" where id = " + id);
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
            this.Close();
        }
    }
}

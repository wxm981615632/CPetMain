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
    public partial class FrmCate : DSkinForm
    {
        public FrmCate(int oid = 0)
        {
            InitializeComponent();
            this.id = oid;
            
        }
        int id = 0;
        List<Cate> lcs = new List<Cate>();
        private void FrmCate_Load(object sender, EventArgs e)
        {
            lcs.Add(new Cate()
            {
                id = 0,
                name = "一级菜单",
                password = "",
            });
            getCate();
            foreach (Cate c in lcs)
            {
                dSkinComboBox1.AddItem(c.name);
            }
            if (id > 0)
            {
                Cate cs = LoadCate();
                if (cs != null)
                {
                    dSkinTextBox1.Text = cs.name;
                    for (int i=0;i<lcs.Count();i++)
                    {
                        if (lcs[i].id == cs.pid)
                        {
                            dSkinComboBox1.SelectedIndex = i;
                            break;
                        }
                    }
                }
                dSkinComboBox1.Enabled = false;
            }
            else
            {
                dSkinComboBox1.SelectedIndex = 0;
            }
        }

        private void dSkinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getCate(int pid = 0,string lef = "")
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,name,password from password_category where pid=" + pid);
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                lcs.Add(new Cate() { 
                    id= Convert.ToInt32(mDr[0].ToString()),
                    name = lef + mDr[1].ToString(),
                    password = mDr[2].ToString(),
                });
                if (mDr != null)
                {
                    getCate(Convert.ToInt32(mDr[0].ToString()),lef+"——");
                }
            }
        }

        private Cate LoadCate()
        {
            Cate c = new Cate();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,pid,name,password from password_category where id=" + id +" limit 1");
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                c.id = Convert.ToInt32(mDr[0].ToString());
                c.pid = Convert.ToInt32(mDr[1].ToString());
                c.name = mDr[2].ToString();
                c.password = mDr[3].ToString();
            }
            return c;
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into password_category (pid,name,password) values (")
                    .Append(lcs[dSkinComboBox1.SelectedIndex].id).Append(",")
                    .Append("'").Append(dSkinTextBox1.Text).Append("','')");
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("update password_category set name = ")
                    .Append("'").Append(dSkinTextBox1.Text).Append("' where id = " + id);
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
            this.Close();
        }
    }
}

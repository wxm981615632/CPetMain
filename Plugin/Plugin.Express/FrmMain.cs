using DSkin.Common;
using DSkin.Controls;
using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Plugin.Express
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        List<ExpressCode> express;
        string typer = "";
        private void FrmMain_Load(object sender, EventArgs e)
        {
            dSkinLabel1.Text = "";
            List<ExpressCode> ex = express = Express.getExperssCode(true);
            dcSkinComboBox1.DataSource = ex;
            dcSkinComboBox1.DisplayMember = "name";
            dcSkinComboBox1.ValueMember = "code";
            dcSkinComboBox1.SelectedIndex = 0;
            dcSkinComboBox1.Refresh();
        }

        private void dcSkinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            typer = dcSkinComboBox1.SelectedValue.ToString();
            dcSkinComboBox1.Refresh();
        }

        private void dSkinTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Common.LoadingHelper.ShowLoadingScreen();
                LoadData(typer,dSkinTextBox1.Text);
                Common.LoadingHelper.CloseForm();
            }
        }
        Result result;
        private void LoadData(string type,string code)
        {
            
            dSkinDataGridView1.Rows.Clear();
            result = Express.getExpress(type,code);
            if (result == null) return;
            switch (result.status)
            {
                case 1:
                    dSkinLabel1.Text = "暂无记录";
                    break;
                case 2:
                    dSkinLabel1.Text = "在途中";
                    break;
                case 3:
                    dSkinLabel1.Text = "派送中";
                    break;
                case 4:
                    dSkinLabel1.Text = "已签收";
                    break;
                case 5:
                    dSkinLabel1.Text = "拒收";
                    break;
                case 6:
                    dSkinLabel1.Text = "疑难件";
                    break;
                case 7:
                    dSkinLabel1.Text = "退回";
                    break;
                default:
                    dSkinLabel1.Text = "缺省";
                    break;
            }
            foreach (Per d in result.data)
            {
                dSkinDataGridView1.Rows.Add(d.time,d.content);
            }
            dSkinDataGridView1.Refresh();
            addLocalData();
            
        }

        private void dSkinDataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dSkinToolTip1.Hide(dSkinDataGridView1);
        }

        private void dSkinDataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.RowIndex > result.data.Count) return;
            string str = result.data[e.RowIndex].content;
            dSkinToolTip1.SetToolTip(dSkinDataGridView1, Common.StrHelper.explodes(str,30));
        }

        private void dSkinButton1_Click(object sender, EventArgs e)
        {
            Common.LoadingHelper.ShowLoadingScreen();
            LoadData(typer, dSkinTextBox1.Text);
            Common.LoadingHelper.CloseForm();
        }

        private void addLocalData()
        {
            Result res = result;
            StringBuilder sql = new StringBuilder();
            int status = res.status > 3 ? 1 : 0;
            sql.Append("select id,typer,code from express where typer='")
                .Append(res.id)
                .Append("' and code='")
                .Append(res.order).Append("'");
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            int id = 0;
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                Console.WriteLine(mDr[0]);
                id = Convert.ToInt32(mDr[0]);
            }
            if (id > 0)
            {
                sql = new StringBuilder();
                sql.Append("update express set typer='").Append(res.id).Append("',")
                    .Append("code='").Append(res.order).Append("',")
                    .Append("name='").Append(res.name).Append("',")
                    .Append("dates='").Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("',")
                    .Append("create_time='").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',")
                    .Append("status=").Append(status).Append(" where id=").Append(id);
                Console.WriteLine(sql.ToString());
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
            else
            {
                sql = new StringBuilder();
                sql.Append("insert into express(typer,name,code,dates,create_time,status,is_continue) values ('")
                    .Append(res.id).Append("','")
                    .Append(res.name).Append("','")
                    .Append(res.order).Append("','")
                    .Append(DateTime.Now.ToString("yyyy-MM-dd")).Append("','")
                    .Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Append("',")
                    .Append(status).Append(",0);");
                Console.WriteLine(sql.ToString());
                Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLocal frm = new FrmLocal();
            frm.ShowDialog();
            string[] code = frm.getCode();
            if (code[0] == "") return;
            if (code[1] == "") return;
            int index = 0;
            Common.LoadingHelper.ShowLoadingScreen();
            foreach (ExpressCode ex in (List<ExpressCode>)dcSkinComboBox1.DataSource)
            {
                if (ex.code == code[0])
                {
                    dcSkinComboBox1.SelectedIndex = index;
                    break;
                }
                index++;
            }
            dcSkinComboBox1.Refresh();
            dSkinTextBox1.Text = code[1];
            LoadData(code[0], code[1]);
            Common.LoadingHelper.CloseForm();
        }

        private void dSkinDataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dSkinDataGridView1.Refresh();
        }
    }
}

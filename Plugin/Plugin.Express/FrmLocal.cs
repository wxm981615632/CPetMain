using DSkin.Controls;
using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.Express
{
    public partial class FrmLocal : DSkinForm
    {
        public FrmLocal()
        {
            InitializeComponent();
        }

        private void FrmLocal_Load(object sender, EventArgs e)
        {
            loadData();
        }
        string typer = "";
        string order = "";
        private void dSkinGridList1_ItemClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            
        }

        private void dSkinGridList1_ItemDoubleClick(object sender, DSkin.Controls.DSkinGridListMouseEventArgs e)
        {
            //更新交给宠物
            //MessageBox.Show(e.Item.Cells[0].Value.ToString());
            if (e.CellIndex < 0) return;
            //返回数据
            typer = e.Item.Cells[1].Value.ToString();
            order = e.Item.Cells[3].Value.ToString();
            if (typer == "") return;
            if (order == "") return;
            this.Close();
        }

        private void loadData()
        {
            Common.LoadingHelper.ShowLoadingScreen();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,typer,name,code,dates,is_continue from express where status=0 order by create_time desc");
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                dSkinGridList1.Rows.AddRow(
                    mDr[0].ToString(),
                    mDr[1].ToString(),
                    mDr[2].ToString(),
                    mDr[3].ToString(),
                    mDr[4].ToString(),
                    Common.StrHelper.checkEquals(mDr[5].ToString(), "1") ? "是" : "否"
                    );
            }
            Common.LoadingHelper.CloseForm();
        }

        public string[] getCode()
        {
            return new string[] { 
                typer,order
            };
        }
    }
}

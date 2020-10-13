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

namespace Plugin.Password
{
    public partial class FrmMain : DSkinForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadCate();
        }

        private void LoadCate()
        {
            dSkinTreeView1.Nodes.Clear();
            getCate();
            dSkinTreeView1.Refresh();
        }

        private void getCate(int pid=0, DSkinTreeViewNode node = null)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,name,password from password_category where pid="+ pid);
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                DSkinTreeViewNode n = new DSkinTreeViewNode();
                n.Name = mDr[0].ToString();
                n.Text = mDr[1].ToString();
                n.Tag = mDr[0].ToString();
                if (node == null)
                {
                    dSkinTreeView1.Nodes.Add(n);
                }
                else
                {
                    node.Nodes.Add(n);
                }
                if (mDr != null)
                {
                    getCate(Convert.ToInt32(mDr[0].ToString()),n);
                }
            }
        }

        private List<Pass> getPass(int cate_id=0)
        {
            List<Pass> lp = new List<Pass>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,title,username,password,url,details from password where cate_id=" + cate_id);
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                lp.Add(new Pass()
                {
                    id = Convert.ToInt32(mDr[0].ToString()),
                    title = mDr[1].ToString(),
                    username = mDr[2].ToString(),
                    password = mDr[3].ToString(),
                    url = mDr[4].ToString(),
                    details = mDr[5].ToString()
                });
            }
            return lp;
        }


        private void dSkinGridList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            passInfo(Convert.ToInt32(dSkinGridList1.SelectedItem.Cells[0].Value.ToString()));
        }
        //修改分类
        private void cateHandle(int id=0)
        {
            FrmCate fc = new FrmCate(id);
            fc.ShowDialog();
            LoadCate();
        }
        //新增密码
        private void passAdd(int id = 0)
        {
            FrmPass fp = new FrmPass(0, id);
            fp.ShowDialog();
            loadPass();
        }
        private void passHandle(int id = 0)
        {
            FrmPass fp = new FrmPass(1,id);
            fp.ShowDialog();
            loadPass();
        }
        //密码详情
        private void passInfo(int id = 0)
        {
            FrmPass fp = new FrmPass(2,id);
            fp.ShowDialog();
        }

        private void loadPass()
        {
            dSkinGridList1.Rows.Clear();
            int cate_id = Convert.ToInt32(dSkinTreeView1.SelectedNode.Tag.ToString());
            List<Pass> lp = getPass(cate_id);
            foreach (Pass p in lp)
            {
                dSkinGridList1.Rows.AddRow(
                    p.id,
                    p.title,
                    p.username,
                    p.password,
                    p.url,
                    p.details
                );
            }
            dSkinGridList1.Refresh();
        }

        private void dSkinTreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            loadPass();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cateHandle(0);
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dSkinTreeView1.SelectedNode == null)
            {
                return;
            }
            cateHandle(Convert.ToInt32(dSkinTreeView1.SelectedNode.Tag.ToString()));
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dSkinTreeView1.SelectedNode == null)
            {
                return;
            }
            int cate_id = Convert.ToInt32(dSkinTreeView1.SelectedNode.Tag.ToString());
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from password_category where pid=" + cate_id);
            DataSet ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                if (!Common.StrHelper.checkEquals(mDr[0].ToString(), "0"))
                {
                    DSkinMessageBox.Show("有下级数据，禁止删除");
                    return;
                }
            }
            sql = new StringBuilder();
            sql.Append("select count(*) from password where cate_id=" + cate_id);
            ds = Common.SQLiteHelper.ExecuteDataSet(sql.ToString(), CommandType.Text);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                if (!Common.StrHelper.checkEquals(mDr[0].ToString(), "0"))
                {
                    DSkinMessageBox.Show("有密码数据，禁止删除");
                    return;
                }
            }
            sql = new StringBuilder();
            sql.Append("delete from password_category where id=" + cate_id);
            Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            LoadCate();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dSkinTreeView1.SelectedNode == null)
            {
                return;
            }
            passAdd(Convert.ToInt32(dSkinTreeView1.SelectedNode.Tag.ToString()));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dSkinGridList1.SelectedItem == null)
            {
                return;
            }
            passHandle(Convert.ToInt32(dSkinGridList1.SelectedItem.Cells[0].Value.ToString()));
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dSkinGridList1.SelectedItem == null)
            {
                return;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from password where id=" + dSkinGridList1.SelectedItem.Cells[0].Value.ToString());
            Common.SQLiteHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
            loadPass();
        }
    }
}

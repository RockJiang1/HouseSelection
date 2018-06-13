using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HouseSelection.Utility;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Provider.Client.Response;
using HouseSelection.NetworkHelper;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmSelectRoleManagement : Form
    {
        public ProjectEntityTemp model = new ProjectEntityTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmSelectRoleManagement()
        {
            InitializeComponent();

            GetProjects(false);
        }

        private void GetProjects(bool isSearch)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = new ProjectEntityResponse();
            if (isSearch == false)
            {
                getProject = provide.GetAllProjects();
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getProject = provide.GetProjects(searchStr);
            }
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取项目信息失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getProject.ProjectList.Count; i++)
                {
                    getProject.ProjectList[i].Operate1 = "创建规则";
                    getProject.ProjectList[i].Operate2 = "修改规则";
                    getProject.ProjectList[i].Operate3 = "查看详情";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getProject.ProjectList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetProjects(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate1")
            {
                //可以在此打开新窗口，把参数传递过去
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmSelectRoleAdd fm = new frmSelectRoleAdd();
                fm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate2")
            {
                //可以在此打开新窗口，把参数传递过去
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmSelectRoleEdit fm = new frmSelectRoleEdit();
                fm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate3")
            {

            }
        }

        public void RefreshDataView()
        {
            clearDataView();

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取项目信息失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getProject.ProjectList.Count; i++)
                {
                    getProject.ProjectList[i].Operate = "修改项目";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getProject.ProjectList;
            }
        }

        private void clearDataView()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
        }
    }
}


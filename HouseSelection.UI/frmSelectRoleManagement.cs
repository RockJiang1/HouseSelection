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
        public static frmSelectRoleManagement frmSelectRoleMgt;
        public frmSelectRoleManagement()
        {
            InitializeComponent();

            GetProjects(false);
        }

        public static frmSelectRoleManagement GetInstance()
        {
            if (frmSelectRoleMgt == null)
            {
                frmSelectRoleMgt = new frmSelectRoleManagement();
            }
            return frmSelectRoleMgt;
        }

        private void GetProjects(bool isSearch)
        {
            int pIndex = 1;
            int psize = 9999;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = new ProjectEntityResponse();
            if (isSearch == false)
            {
                getProject = provide.GetAllProjects(pIndex, psize);
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getProject = provide.GetProjects(searchStr, pIndex, psize);
            }
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取项目信息失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                List<ProjectSource2nd> list = new List<ProjectSource2nd>();
                foreach (ProjectEntityTemp item in getProject.ProjectList)
                {
                    ProjectSource2nd obj = new ProjectSource2nd();
                    obj.ID = item.ID;
                    obj.Number = item.Number;
                    obj.Name = item.Name;
                    obj.DevelopCompany = item.DevelopCompany;
                    obj.IdentityNumber = item.IdentityNumber;
                    obj.ProjectArea = item.ProjectArea;
                    obj.Operate1 = "创建规则";
                    obj.Operate2 = "修改规则";
                    obj.Operate3 = "查看详情";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
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
                frmSelectRoleAdd fm = frmSelectRoleAdd.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate2")
            {
                //可以在此打开新窗口，把参数传递过去
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmSelectRoleEdit fm = frmSelectRoleEdit.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate3")
            {
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmSelectRoleDetails fm = frmSelectRoleDetails.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
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


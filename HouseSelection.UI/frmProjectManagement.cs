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
    public partial class frmProjectManagement : Form
    {
        public AddProjectRequest model = new AddProjectRequest();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmProjectManagement()
        {
            InitializeComponent();

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.code != 0)
            {
                MessageBox.Show("获取项目信息失败, 错误信息： " + getProject.errMsg);
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProjectAdd fm = new frmProjectAdd();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchStr = string.Empty;

            searchStr = textBox1.Text;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetProjects(searchStr);
            if (getProject.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getProject.errMsg);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                model.Number = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.DevelopCompany = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                model.IdentityNumber = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                model.ProjectArea = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frmProjectEdit fm = new frmProjectEdit();
                fm.ShowDialog();
            }
        }
    }
}

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
        public EditProjectRequest model = new EditProjectRequest();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmProjectManagement()
        {
            InitializeComponent();
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
            GetProjectInfo(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Number = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.DevelopCompany = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                model.IdentityNumber = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                model.ProjectArea = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frmProjectEdit fm = new frmProjectEdit();
                fm.ShowDialog();
            }
        }

        private void clearDataView()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
        }

        private void frmProjectManagement_Load(object sender, EventArgs e)
        {
            InitForm();

            GetProjectInfo(false);
        }

        private void InitForm()
        {
            //初始化界面
        }

        public void GetProjectInfo(bool isSearch)
        {
            clearDataView();

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
                    getProject.ProjectList[i].Operate = "修改项目";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getProject.ProjectList;
            }
        }
    }
}

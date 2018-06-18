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
    public partial class frmProjectManagement : MetroFramework.Forms.MetroForm
    {
        public EditProjectRequest model = new EditProjectRequest();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();

        public static frmProjectManagement frmProMgt;
        private frmProjectManagement()
        {
            InitializeComponent();
        }

        public static frmProjectManagement GetInstance()
        {
            if(frmProMgt == null)
            {
                frmProMgt = new frmProjectManagement();
            }
            return frmProMgt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProjectAdd fm = frmProjectAdd.GetInstance();
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
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                model.Number = this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value.ToString();
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                model.DevelopCompany = this.dataGridView1.Rows[e.RowIndex].Cells["DevelopCompany"].Value==null?"":this.dataGridView1.Rows[e.RowIndex].Cells["DevelopCompany"].Value.ToString();
                model.IdentityNumber = this.dataGridView1.Rows[e.RowIndex].Cells["IdentityNumber"].Value==null?"": this.dataGridView1.Rows[e.RowIndex].Cells["IdentityNumber"].Value.ToString();
                model.ProjectArea = this.dataGridView1.Rows[e.RowIndex].Cells["ProjectArea"].Value.ToString();
                frmProjectEdit fm = frmProjectEdit.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        private void clearDataView()
        {
            List<ProjectSource1st> list = new List<ProjectSource1st>();
            dataGridView1.DataSource = list;
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
                List<ProjectSource1st> list = new List<ProjectSource1st>();
                foreach(ProjectEntityTemp item in getProject.ProjectList)
                {
                    ProjectSource1st obj = new ProjectSource1st();
                    obj.ID = item.ID;
                    obj.Number = item.Number;
                    obj.Name = item.Name;
                    obj.DevelopCompany = item.DevelopCompany;
                    obj.IdentityNumber = item.IdentityNumber;
                    obj.ProjectArea = item.ProjectArea;
                    obj.Operate = "修改项目";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
            }
        }
    }
}

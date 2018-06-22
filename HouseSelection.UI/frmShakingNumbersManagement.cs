using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;
using System.Collections.Generic;

namespace HouseSelection.UI
{
    
    public partial class frmShakingNumbersManagement : Form
    {
        public ProjectGroupEntityTemp model = new ProjectGroupEntityTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmShakingNumbersManagement frmShakingNumbersMgt;
        public frmShakingNumbersManagement()
        {
            InitializeComponent();
        }

        public static frmShakingNumbersManagement GetInstance()
        {
            if (frmShakingNumbersMgt == null)
            {
                frmShakingNumbersMgt = new frmShakingNumbersManagement();
            }
            return frmShakingNumbersMgt;
        }

        private void frmShakingNumbersManagement_Load(object sender, EventArgs e)
        {
            GetProjectList();

            GetProjectGroupList(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void GetProjectList()
        {
            int pIndex = 1;
            int psize = 9999;
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetAllProjects(pIndex, psize);
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取项目失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                comboBox1.DataSource = getProject.ProjectList;//绑定数据源
                comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
                comboBox1.ValueMember = "ID";//实际值
            }
        }

        private void GetProjectGroupList(bool isSearch)
        {
            int projectId = 0;

            projectId = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetProjectGroupResponse getProjectGroup = new GetProjectGroupResponse();

            if (isSearch == false)
            {
                getProjectGroup = provide.GetProjectGroup(projectId);
            }
            else
            {
                //查询条件
            }
            if (getProjectGroup.Code != 0 || getProjectGroup.ProjectGroupList.Count==0)
            {
                MessageBox.Show("获取项目分组信息失败, 错误信息： " + getProjectGroup.ErrMsg);
                return;
            }
            else
            {
                List<ProjectGroupSource1st> list = new List<ProjectGroupSource1st>();
                int i = 0;
                foreach (ProjectGroupEntityTemp item in getProjectGroup.ProjectGroupList)
                {
                    i++;
                    ProjectGroupSource1st obj = new ProjectGroupSource1st();
                    obj.No = i;
                    obj.ProjectID = item.ProjectID;
                    obj.ProjectNumber = item.ProjectNumber;
                    obj.ProjectName = item.ProjectName;
                    obj.ProjectGroupID = item.ProjectGroupID;
                    obj.ProjectGroupName = item.ProjectGroupName;
                    obj.Operate = "摇号信息详情";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetProjectGroupList(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                
                model.ProjectNumber = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.ProjectName = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                model.ProjectGroupID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                model.ProjectGroupName = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frmShakingNumbersDetails fm = frmShakingNumbersDetails.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        
    }
}

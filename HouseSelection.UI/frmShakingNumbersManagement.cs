using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    
    public partial class frmShakingNumbersManagement : Form
    {
        public GetProjectGroupResponseTemp model = new GetProjectGroupResponseTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmShakingNumbersManagement()
        {
            InitializeComponent();
        }

        private void frmShakingNumbersManagement_Load(object sender, EventArgs e)
        {
            GetProjectList();

            GetProjectGroupList(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void GetProjectList()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取项目失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                comboBox1.DataSource = getProject;//绑定数据源
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
                for (int i = 1; i < getProjectGroup.ProjectGroupList.Count; i++)
                {
                    getProjectGroup.ProjectGroupList[i].No = i;
                    getProjectGroup.ProjectGroupList[i].Operate = "摇号信息详情";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getProjectGroup.ProjectGroupList;
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
                
                model.ProjectNumber = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                model.ProjectName = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                model.ProjectGroupID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                model.ProjectGroupName = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frmShakingNumbersDetails fm = new frmShakingNumbersDetails();
                fm.ShowDialog();
            }
        }

        
    }
}

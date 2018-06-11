using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodManagement : Form
    {
        public int projectgroupId = 0;
        public string desc = string.Empty;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmSelectTimePeriodManagement()
        {
            InitializeComponent();
        }

        private void frmSelectTimePeriodManagement_Load(object sender, EventArgs e)
        {
            GetProjectList();

            GetProjectGroupList();
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
                MessageBox.Show("获取项目信息失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                comboBox1.DataSource = getProject;//绑定数据源
                comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
                comboBox1.ValueMember = "ID";//实际值
            }
        }

        private void GetProjectGroupList()
        {
            int projectId = 0;
            projectId = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetProjectGroupResponse getProjectGroup = provide.GetProjectGroup(projectId);

            if (getProjectGroup.Code != 0 || getProjectGroup.ProjectGroupList.Count == 0)
            {
                MessageBox.Show("获取项目分组获取失败, 错误信息： " + getProjectGroup.ErrMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getProjectGroup.ProjectGroupList.Count; i++)
                {
                    getProjectGroup.ProjectGroupList[i].Operate1 = "创建时段";
                    getProjectGroup.ProjectGroupList[i].Operate2 = "修改时段";
                    getProjectGroup.ProjectGroupList[i].Operate3 = "查看详情";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getProjectGroup.ProjectGroupList;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProjectGroupList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate1")
            {
                projectgroupId = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                frmSelectTimePeriodAdd fm = new frmSelectTimePeriodAdd();
                fm.ShowDialog();
            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Operate2")
            {
                projectgroupId = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                frmSelectTimePeriodEdit fm = new frmSelectTimePeriodEdit();
                fm.ShowDialog();
            }
            else if(dataGridView1.Columns[e.ColumnIndex].Name == "Operate3")
            {
                projectgroupId = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                desc = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " - " + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frmSelectTimePeriodDetails fm = new frmSelectTimePeriodDetails();
                fm.ShowDialog();
            }
        }
    }
}

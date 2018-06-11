using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;
namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodDetails : Form
    {
        private int projectgroupId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmSelectTimePeriodDetails()
        {
            InitializeComponent();

            InitForm();

            GetSelectTimePeriod();
        }

        private void InitForm()
        {
            frmSelectTimePeriodManagement fm = new frmSelectTimePeriodManagement();
            projectgroupId = fm.projectgroupId;
            label1.Text = fm.desc;
        }

        private void GetSelectTimePeriod()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetSelectTimePeriodResponse getSelectTimePeriod = provide.GetSelectTimePeriod(projectgroupId);
            if (getSelectTimePeriod.Code != 0)
            {
                MessageBox.Show("获取选房时间段失败, 错误信息： " + getSelectTimePeriod.ErrMsg);
                return;
            }
            else
            {
                for (int i = 0; i < getSelectTimePeriod.SelectTimeList.Count; i++)
                {
                    getSelectTimePeriod.SelectTimeList[i].No = i + 1;
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getSelectTimePeriod.SelectTimeList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = new frmSelectTimePeriodManagement();
            fm.Show();
            this.Close();
        }
    }
}

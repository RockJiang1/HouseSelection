using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;
using System.Collections.Generic;

namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodDetails : Form
    {
        private int projectgroupId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSelectTimePeriodDetails frmSelectTimePeriodDtls;
        public frmSelectTimePeriodDetails(int projectgroupId, string desc)
        {
            InitializeComponent();

            InitForm(projectgroupId, desc);

            GetSelectTimePeriod();
        }

        public static frmSelectTimePeriodDetails GetInstance(int projectgroupId , string desc)
        {
            if (frmSelectTimePeriodDtls == null)
            {
                frmSelectTimePeriodDtls = new frmSelectTimePeriodDetails(projectgroupId, desc);
            }
            return frmSelectTimePeriodDtls;
        }

        public void Exec(int projectgroupId, string desc)
        {
            InitForm(projectgroupId, desc);
            GetSelectTimePeriod();
        }

        private void InitForm(int id, string desc)
        {
            projectgroupId = id;
            label1.Text = desc;
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
                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (SelectTimePeriodEntityTemp item in getSelectTimePeriod.SelectTimeList)
                {
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    this.dataGridView1.Rows[i].Cells[1].Value = Convert.ToDateTime(item.StartTime).ToString("yyyy-MM-dd HH:mm");
                    this.dataGridView1.Rows[i].Cells[2].Value = Convert.ToDateTime(item.EndTime).ToString("yyyy-MM-dd HH:mm");
                    this.dataGridView1.Rows[i].Cells[3].Value = item.StartNumber;
                    this.dataGridView1.Rows[i].Cells[4].Value = item.EndNumber;
                    this.dataGridView1.Rows[i].Cells[5].Value = "删除";
                    this.dataGridView1.Columns[5].Visible = false;
                    i++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
            fm.Show();
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;
using HouseSelection.Provider.Client.Response;

namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodAdd : Form
    {
        private int projectgroupId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSelectTimePeriodAdd frmseTimePeriodAdd;
        public frmSelectTimePeriodAdd(int projectgroupId)
        {
            InitializeComponent();

            InitForm(projectgroupId);
        }

        public static frmSelectTimePeriodAdd GetInstance(int projectgroupId)
        {
            if (frmseTimePeriodAdd == null)
            {
                frmseTimePeriodAdd = new frmSelectTimePeriodAdd(projectgroupId);
            }
            return frmseTimePeriodAdd;
        }

        public void Exec(int projectgroupId)
        {
            InitForm(projectgroupId);
        }

        private void InitForm(int id)
        {
            projectgroupId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = index + 1;
            this.dataGridView1.Rows[index].Cells[1].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            this.dataGridView1.Rows[index].Cells[2].Value = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm");
            this.dataGridView1.Rows[index].Cells[3].Value = textBox1.Text;
            this.dataGridView1.Rows[index].Cells[4].Value = textBox2.Text;
            this.dataGridView1.Rows[index].Cells[5].Value = "删除";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SelectTimePeriodEntityTemp> selectTimePeriodlist = GetSelectTimePeriodList();

            AddSelectTimePeriod(selectTimePeriodlist);
        }

        private List<SelectTimePeriodEntityTemp> GetSelectTimePeriodList()
        {
            List<SelectTimePeriodEntityTemp> list = new List<SelectTimePeriodEntityTemp>();
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                var val = dgvr.Cells["No"].Value;
                if (val != null)
                {
                    SelectTimePeriodEntityTemp item = new SelectTimePeriodEntityTemp();
                    item.StartTime = dgvr.Cells[1].Value.ToString();
                    item.EndTime = dgvr.Cells[2].Value.ToString();
                    item.StartNumber = Convert.ToInt32(dgvr.Cells[3].Value);
                    item.EndNumber = Convert.ToInt32(dgvr.Cells[4].Value);
                    list.Add(item);
                }
            }
            return list;
        }

        private void AddSelectTimePeriod(List<SelectTimePeriodEntityTemp> list)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            BaseResultEntity addSelectTimePeriod = provide.AddSelectTimePeriod(list, projectgroupId);
            if (addSelectTimePeriod.Code != 0)
            {
                MessageBox.Show("创建选房时间段失败, 错误信息： " + addSelectTimePeriod.ErrMsg);
                return;
            }
            else
            {
                MessageBox.Show("创建成功！");
                frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
                fm.GetProjectGroupList();
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.Rows.Remove(row);
                int i = 0;
                foreach(DataGridViewRow item in dataGridView1.Rows)
                {
                    i++;
                    var val = item.Cells["No"].Value;
                    if (val !=null)
                    {
                        item.Cells["No"].Value = i;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
            fm.GetProjectGroupList();
            this.Close();
        }

        
    }
}

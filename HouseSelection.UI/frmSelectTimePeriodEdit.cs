using System;
using System.Windows.Forms;
using System.Collections.Generic;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodEdit : Form
    {
        private int projectgroupId = 0;
        //List<SelectTimePeriodSource> list = new List<SelectTimePeriodSource>();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSelectTimePeriodEdit frmseTimePeriodEdit;
        public frmSelectTimePeriodEdit(int projectgroupId)
        {
            InitializeComponent();

            InitForm(projectgroupId);
        }

        public static frmSelectTimePeriodEdit GetInstance(int projectgroupId)
        {
            if (frmseTimePeriodEdit == null)
            {
                frmseTimePeriodEdit = new frmSelectTimePeriodEdit(projectgroupId);
            }
            return frmseTimePeriodEdit;
        }

        public void Exec(int projectgroupId)
        {
            InitForm(projectgroupId);
        }

        private void frmSelectTimePeriodEdit_Load(object sender, EventArgs e)
        {
            GetSelectTimePeriod();
        }

        private void InitForm(int id)
        {
            projectgroupId = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
            fm.Show();
            this.Close();
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
                    i++;
                }
            }
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

        private void EditSelectTimePeriod(List<SelectTimePeriodEntityTemp> list)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            BaseResultEntity editSelectTimePeriod = provide.EditSelectTimePeriod(list, projectgroupId);
            if (editSelectTimePeriod.Code != 0)
            {
                MessageBox.Show("创建选房时间段失败, 错误信息： " + editSelectTimePeriod.ErrMsg);
                return;
            }
            else
            {
                MessageBox.Show("修改成功！");
                frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
                fm.GetProjectGroupList();
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = index + 1;
            this.dataGridView1.Rows[index].Cells[1].Value = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
            this.dataGridView1.Rows[index].Cells[2].Value = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm"); ;
            this.dataGridView1.Rows[index].Cells[3].Value = textBox1.Text;
            this.dataGridView1.Rows[index].Cells[4].Value = textBox2.Text;
            this.dataGridView1.Rows[index].Cells[5].Value = "删除";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.Rows.Remove(row);
                int i = 0;
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    i++;
                    var val = item.Cells["No"].Value;
                    if (val != null)
                    {
                        item.Cells["No"].Value = i;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SelectTimePeriodEntityTemp> selectTimePeriodlist = GetSelectTimePeriodList();

            EditSelectTimePeriod(selectTimePeriodlist);
        }
    }
}

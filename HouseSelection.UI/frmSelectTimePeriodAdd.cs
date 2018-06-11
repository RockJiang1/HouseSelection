using System;
using System.Windows.Forms;
using System.Collections.Generic;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmSelectTimePeriodAdd : Form
    {
        private int projectgroupId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmSelectTimePeriodAdd()
        {
            InitializeComponent();
        }

        private void frmSelectTimePeriodAdd_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void InitForm()
        {
            frmSelectTimePeriodManagement fm = new frmSelectTimePeriodManagement();
            projectgroupId = fm.projectgroupId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = this.dataGridView1.Rows.Count + 1;
            this.dataGridView1.Rows[index].Cells[1].Value = dateTimePicker1.Value;
            this.dataGridView1.Rows[index].Cells[2].Value = dateTimePicker2.Value;
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SelectTimePeriodEntityTemp item = new SelectTimePeriodEntityTemp();
                item.StartTime = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                item.EndTime = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                item.StartNumber = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[3].Value);
                item.EndNumber = Convert.ToInt32(this.dataGridView1.Rows[i].Cells[4].Value);
                list.Add(item);
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
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[e.RowIndex]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = new frmSelectTimePeriodManagement();
            fm.Show();
            this.Close();
        }

        
    }
}

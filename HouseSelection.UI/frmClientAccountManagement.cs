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
    public partial class frmClientAccountManagement : Form
    {
        public FrontEndAccountEntityTemp model = new FrontEndAccountEntityTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmClientAccountManagement()
        {
            InitializeComponent();

            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            GetFrontEndAccountResponse getAllFrontEndAccount = provide.GetAllFrontEndAccount(0);
            if (getAllFrontEndAccount.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getAllFrontEndAccount.errMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getAllFrontEndAccount.AccountList.Count; i++)
                {
                    getAllFrontEndAccount.AccountList[i].No = i;
                    getAllFrontEndAccount.AccountList[i].Operate = "修改项目";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getAllFrontEndAccount.AccountList;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去 
                model.AccountID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                model.ProjectNumber = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                model.ProjectName = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                model.Account = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frmClientAccountAdd fm = new frmClientAccountAdd();
                fm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchStr = string.Empty;

            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;
            searchStr = textBox1.Text;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            GetFrontEndAccountResponse getFrontEndAccount = provide.GetFrontEndAccount(searchStr);
            if (getFrontEndAccount.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getFrontEndAccount.errMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getFrontEndAccount.AccountList.Count; i++)
                {
                    getFrontEndAccount.AccountList[i].No = i;
                    getFrontEndAccount.AccountList[i].Operate = "修改项目";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getFrontEndAccount.AccountList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientAccountAdd fm = new frmClientAccountAdd();
            fm.ShowDialog();
        }

        private void RefreshDataView(string pwd1st, string pwd2nd)
        {

            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;
            clearDataView();

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            GetFrontEndAccountResponse getAllFrontEndAccount = provide.GetAllFrontEndAccount(0);
            if (getAllFrontEndAccount.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getAllFrontEndAccount.errMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getAllFrontEndAccount.AccountList.Count; i++)
                {
                    getAllFrontEndAccount.AccountList[i].No = i;
                    getAllFrontEndAccount.AccountList[i].Operate = "修改项目";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getAllFrontEndAccount.AccountList;
            }
        }

        private void clearDataView()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
            dataGridView1.DataSource = dt;
        }
    }
}

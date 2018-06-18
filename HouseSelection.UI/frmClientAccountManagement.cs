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
        private List<FrontEndAccountEntityTemp> temp = new List<FrontEndAccountEntityTemp>();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmClientAccountManagement frmClientAccountMgt;
        public frmClientAccountManagement()
        {
            InitializeComponent();

            GetFrontEndAccount(false);
        }

        public static frmClientAccountManagement GetInstance()
        {
            if (frmClientAccountMgt == null)
            {
                frmClientAccountMgt = new frmClientAccountManagement();
            }
            return frmClientAccountMgt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int accountid = 0;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去 
                accountid = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                model = temp.Where(x => x.AccountID == accountid).FirstOrDefault();
                frmClientAccountEdit fm = frmClientAccountEdit.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetFrontEndAccount(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientAccountAdd fm = frmClientAccountAdd.GetInstance();
            fm.ShowDialog();
        }

        private void GetFrontEndAccount(bool isSearch)
        {
            //clearDataView();

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetFrontEndAccountResponse getFrontEndAccount = new GetFrontEndAccountResponse();
            if (isSearch == false)
            {
                getFrontEndAccount = provide.GetAllFrontEndAccount();
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getFrontEndAccount = provide.GetFrontEndAccount(searchStr);
            }
            if (getFrontEndAccount.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getFrontEndAccount.ErrMsg);
                return;
            }
            else
            {
                int i = 0;
                List<FrontEndAccountSource> list = new List<FrontEndAccountSource>();
                foreach (FrontEndAccountEntityTemp item in getFrontEndAccount.AccountList)
                {
                    temp.Add(item);
                    i++;
                    FrontEndAccountSource obj = new FrontEndAccountSource();
                    obj.No = i;
                    obj.AccountID = item.AccountID;
                    obj.Account = item.Account;
                    foreach(AccountProjectEntityTemp pjitem in item.ProjectList)
                    {
                        obj.AllName = obj.AllName + "[" +pjitem.ProjectNumber + "-" + pjitem.ProjectName + "]"; 
                    }
                    obj.Operate = "修改密码";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
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

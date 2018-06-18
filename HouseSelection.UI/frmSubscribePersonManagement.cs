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
    public partial class frmSubscribePersonManagement : Form
    {
        public SubscriberEntityTemp model = new SubscriberEntityTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSubscribePersonManagement frmSubscribePersonMgt;
        public frmSubscribePersonManagement()
        {
            InitializeComponent();

            GetSubscribers(false);
        }

        public static frmSubscribePersonManagement GetInstance()
        {
            if (frmSubscribePersonMgt == null)
            {
                frmSubscribePersonMgt = new frmSubscribePersonManagement();
            }
            return frmSubscribePersonMgt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSubscribePersonImport fm = frmSubscribePersonImport.GetInstance();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            GetSubscribers(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                //model.s = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.ID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                model.Name = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.IdentityNumber = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frmSubscriberSelectionHistory fm = frmSubscriberSelectionHistory.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void GetSubscribers(bool isSearch)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            SubscriberEntityResponse getSubscribers = new SubscriberEntityResponse();

            if (isSearch == false) {
                getSubscribers = provide.GetAllSubscribers();
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getSubscribers = provide.GetSubscribers(searchStr);
            }
            if (getSubscribers.Code != 0)
            {
                MessageBox.Show("获取认购人信息失败, 错误信息： " + getSubscribers.ErrMsg);
                return;
            }
            else
            {
                List<SubscriberSource> list = new List<SubscriberSource>();
                int i = 0;
                foreach (SubscriberEntityTemp item in getSubscribers.SubscriberList)
                {
                    i++;
                    SubscriberSource obj = new SubscriberSource();
                    obj.No = i;
                    obj.ID = item.ID;
                    obj.Name = item.Name;
                    obj.IdentityNumber = item.IdentityNumber;
                    obj.Telephone = item.Telephone;
                    obj.Address = item.Address;
                    obj.ZipCode = item.ZipCode;
                    obj.MaritalStatus = item.MaritalStatus;
                    obj.ResidenceArea = item.ResidenceArea;
                    obj.WorkArea = item.WorkArea;
                    obj.Operate = "认购人详情";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;

            }
        }

        
    }
}

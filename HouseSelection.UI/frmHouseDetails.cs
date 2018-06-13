using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmHouseDetails : Form
    {
        private int houseEstateID = 0;
        public HouseEntityTemp model = new HouseEntityTemp();
        public string projectName = string.Empty;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmHouseDetails()
        {
            InitializeComponent();
        }

        private void frmHouseDetails_Load(object sender, EventArgs e)
        {
            InitForm();

            GetHouses(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHousesManagement fm = new frmHousesManagement();
            fm.Show();
            this.Close();
        }

        private void InitForm()
        {
            frmHousesManagement fm = new frmHousesManagement();
            houseEstateID = fm.model.HouseEstateID;
            label1.Text = fm.model.HouseEstateName;
        }

        private void GetHouses(bool isSearch)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetHousesResponse getHouses = new GetHousesResponse();

            if (isSearch == false)
            {
                getHouses = provide.GetAllHouseInfo(houseEstateID);
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getHouses = provide.GetHouses(houseEstateID,searchStr);
            }
            if (getHouses.Code != 0)
            {
                MessageBox.Show("获取房源信息失败, 错误信息： " + getHouses.ErrMsg);
                return;
            }
            else
            {
                for (int i = 1; i < getHouses.HouseList.Count; i++)
                {
                    if (string.IsNullOrEmpty(getHouses.HouseList[i].SubscriberName))
                    {
                        getHouses.HouseList[i].SubscriberStatus = "未认购";
                    }
                    else
                    {
                        getHouses.HouseList[i].SubscriberStatus = "已认购";
                    }
                    getHouses.HouseList[i].Operate = "查看认购信息";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = getHouses.HouseList;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetHouses(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                projectName = label1.Text;
                model.HouseID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Building = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                model.Unit = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                model.RoomNumber = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frmHouseSubscriberInfo fm = new frmHouseSubscriberInfo();
                fm.ShowDialog();
            }
        }

        
    }
}

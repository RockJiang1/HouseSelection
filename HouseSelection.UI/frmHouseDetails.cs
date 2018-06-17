using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;
using System.Collections.Generic;
using System.Drawing;

namespace HouseSelection.UI
{
    public partial class frmHouseDetails : Form
    {
        private int houseEstateID = 0;
        private bool optLock = false;
        public HouseEntityTemp model = new HouseEntityTemp();
        public string projectName = string.Empty;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmHouseDetails frmHouseDtls;
        public frmHouseDetails(HouseEstateEntityTemp model)
        {
            InitializeComponent();

            InitForm(model);
        }

        public void Exec(HouseEstateEntityTemp model)
        {
            InitForm(model);
        }

        public static frmHouseDetails GetInstance(HouseEstateEntityTemp model)
        {
            if (frmHouseDtls == null)
            {
                frmHouseDtls = new frmHouseDetails(model);
            }
            return frmHouseDtls;
        }

        private void frmHouseDetails_Load(object sender, EventArgs e)
        {
            GetHouses(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHousesManagement fm = frmHousesManagement.GetInstance();
            fm.Show();
            this.Close();
        }

        private void InitForm(HouseEstateEntityTemp model)
        {
            houseEstateID = model.HouseEstateID;
            label1.Text = model.HouseEstateName;
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
                List<HouseSource> list = new List<HouseSource>();
                foreach (HouseEntityTemp item in getHouses.HouseList)
                {
                    HouseSource obj = new HouseSource();
                    obj.HouseID = item.HouseID;
                    obj.SerialNumber = item.SerialNumber;
                    obj.Group = item.Group;
                    obj.Block = item.Block;
                    obj.Building = item.Building;
                    obj.Unit = item.Unit;
                    obj.RoomNumber = item.RoomNumber;
                    obj.Toward = item.Toward;
                    obj.RoomType = item.RoomType;
                    obj.EstimateBuiltUpArea = item.EstimateBuiltUpArea;
                    obj.EstimateLivingArea = item.EstimateLivingArea;
                    obj.AreaUnitPrice = item.AreaUnitPrice;
                    obj.TotalPrice = item.TotalPrice;
                    obj.SubscriberID = item.SubscriberID;
                    obj.SubscriberName = item.SubscriberName;
                    if (string.IsNullOrEmpty(item.SubscriberName))
                    {
                        obj.SubscriberStatus = "未认购";
                    }
                    else
                    {
                        obj.SubscriberStatus = "已认购";
                    }
                    obj.Operate = "查看认购信息";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;

                for(int i =0;i< dataGridView1.Rows.Count; i++)
                {
                    if (this.dataGridView1.Rows[i].Cells["SubscriberName"].Value == null)
                    {
                        this.dataGridView1.Rows[i].Cells["Operate"].Style.ForeColor = Color.Gray;
                        optLock = true;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells["Operate"].Style.ForeColor = Color.Blue;
                        optLock = false;
                    }      
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetHouses(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate" && optLock == false)
            {
                //可以在此打开新窗口，把参数传递过去
                projectName = label1.Text;
                model.HouseID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.Building = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                model.Unit = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                model.RoomNumber = this.dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frmHouseSubscriberInfo fm = frmHouseSubscriberInfo.GetInstance(projectName,model);
                fm.ShowDialog();
            }
        }

        
    }
}

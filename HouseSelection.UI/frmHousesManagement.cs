using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;
using System.Collections.Generic;

namespace HouseSelection.UI
{
    public partial class frmHousesManagement : Form
    {
        public HouseEstateEntityTemp model = new HouseEstateEntityTemp();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmHousesManagement frmHouseMgt;
        public frmHousesManagement()
        {
            InitializeComponent();
        }

        public static frmHousesManagement GetInstance()
        {
            if (frmHouseMgt == null)
            {
                frmHouseMgt = new frmHousesManagement();
            }
            return frmHouseMgt;
        }

        private void frmHousesManagement_Load(object sender, EventArgs e)
        {
            InitForm();

            GetHouseEstates(false);
        }

        private void InitForm()
        {
            //初始化界面
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHousesImport fm = frmHousesImport.GetInstance();
            fm.ShowDialog();
        }

        private void GetHouseEstates(bool isSearch)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetHouseEstatesResponse getHouseEstates = new GetHouseEstatesResponse();

            if (isSearch == false)
            {
                getHouseEstates = provide.GetAllHouseEstateInfo();
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = textBox1.Text;
                getHouseEstates = provide.GetHouseEstates(searchStr);
            }
            if (getHouseEstates.Code != 0)
            {
                MessageBox.Show("获取楼盘信息失败, 错误信息： " + getHouseEstates.ErrMsg);
                return;
            }
            else
            {
                List<HouseEstateSource> list = new List<HouseEstateSource>();
                foreach (HouseEstateEntityTemp item in getHouseEstates.HouseEstateList)
                {
                    HouseEstateSource obj = new HouseEstateSource();
                    obj.HouseEstateID = item.HouseEstateID;
                    obj.ProjectNumber = item.ProjectNumber;
                    obj.ProjectName = item.ProjectName;
                    obj.HouseEstateName = item.HouseEstateName;
                    obj.Operate = "楼盘信息详情";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetHouseEstates(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                model.HouseEstateID= Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                model.HouseEstateName = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frmHouseDetails fm = frmHouseDetails.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        
    }
}

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
    public partial class frmHouseSubscriberInfo : Form
    {
        private int houseId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmHouseSubscriberInfo frmHouseSubscriber;
        public frmHouseSubscriberInfo(string projectName,HouseEntityTemp model)
        {
            InitializeComponent();

            InitForm(projectName,model);

            GetSubscriberByHouseID();
        }

        public static frmHouseSubscriberInfo GetInstance(string projectName,HouseEntityTemp model)
        {
            if (frmHouseSubscriber == null)
            {
                frmHouseSubscriber = new frmHouseSubscriberInfo(projectName, model);
            }
            return frmHouseSubscriber;
        }

        private void InitForm(string projectName, HouseEntityTemp model)
        {
            houseId = model.HouseID;
            label1.Text = model.Building + "栋 " + model.Unit + "单元 " + model.RoomNumber + "室";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetSubscriberByHouseID()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetSubscriberByHouseIDResponse getSubscriberByHouseID = provide.GetSubscriberByHouseID(houseId);

            if (getSubscriberByHouseID.Code != 0)
            {
                MessageBox.Show("获取房源认购人信息失败, 错误信息： " + getSubscriberByHouseID.ErrMsg);
                return;
            }
            else
            {
                label2.Text = getSubscriberByHouseID.Name;
                label3.Text = getSubscriberByHouseID.SelectTime.ToString();
            }
        }
    }
}

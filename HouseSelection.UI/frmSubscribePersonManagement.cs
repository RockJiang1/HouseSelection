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
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();

        public frmSubscribePersonManagement()
        {
            InitializeComponent();

            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getProject.ErrMsg);
                return;
            }

            SubscriberEntityResponse subscribers = provide.GetAllSubscribers();
            if (subscribers.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + subscribers.ErrMsg);
                return;
            }
            else
            {
                for(int i=1; i< subscribers.SubscriberList.Count; i++)
                {
                    subscribers.SubscriberList[i].No = i;
                    subscribers.SubscriberList[i].Option ="操作";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = subscribers.SubscriberList;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSubscribePersonImport fm = new frmSubscribePersonImport();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            SubscriberEntityResponse subscribers = provide.GetSubscribers(textBox1.Text);
            if (subscribers.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + subscribers.ErrMsg);
                return;
            }
            else
            {
                for (int i = 1; i < subscribers.SubscriberList.Count; i++)
                {
                    subscribers.SubscriberList[i].No = i;
                    subscribers.SubscriberList[i].Option = "操作";
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = subscribers.SubscriberList;

            }
        }
    }
}

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
    public partial class frmProjectAddOrEdit : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmProjectAddOrEdit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = string.Empty;
            string name = string.Empty;
            string address = string.Empty;
            string area = string.Empty;

            number = textBox1.Text;
            Name = textBox2.Text;
            address = textBox3.Text;
            area = textBox4.Text;
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

            BaseResultEntity getProject = provide.AddProject(number, name, address, area);
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                
            }
        }
    }
}

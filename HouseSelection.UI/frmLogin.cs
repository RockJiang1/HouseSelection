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
    public partial class frmLogin : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sUserAccount = string.Empty;
            string sUserPassword = string.Empty;

            sUserAccount = textBox1.Text;
            sUserPassword = textBox2.Text;

            if (!string.IsNullOrEmpty(sUserAccount) && !string.IsNullOrEmpty(sUserPassword))
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

                BaseResultEntity result = provide.CheckBackEndAccount(sUserAccount, sUserPassword);
                if (result.Code == 0)
                {
                    frmMain main = new frmMain();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录验证失败，请输入正确的用户名，密码！");
                }
            }
        }
    }
}

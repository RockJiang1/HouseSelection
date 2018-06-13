using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
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

                TokenResultEntity getToken = provide.GetToken();
                if (getToken.Code != 0)
                {
                    MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                    return;
                }

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

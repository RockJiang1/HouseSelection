using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Model;
using HouseSelection.Utility;


namespace HouseSelection.UI
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sUserAccount = string.Empty;
            string sUserPassword = string.Empty;

            sUserAccount = txtAccount.Text;
            sUserPassword = MD5Helper.ToMD5(txtPassword.Text);

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
                    frmMain main = frmMain.GetInstance();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录验证失败，请输入正确的用户名，密码！");
                }
            }
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

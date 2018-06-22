using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Model;
using HouseSelection.Utility;
using System.Drawing;

namespace HouseSelection.UI
{
    public partial class frmLogin : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        private int picLoginWidth = 400;
        private int iActulaWidth = Screen.PrimaryScreen.WorkingArea.Width;
        private int iActulaHeight = Screen.PrimaryScreen.WorkingArea.Height;
        public frmLogin()
        {
            InitializeComponent();

            SetControlsSize();

            SetEventHandler();
        }

        private void SetEventHandler()
        {
            this.picLoginSub.Click += new EventHandler(this.picLoginSub_Click);
            this.picLoginMain.MouseMove += new MouseEventHandler(this.picLoginMain_MouseMove);
            //this.picLogin.MouseMove += new MouseEventHandler(this.picLogin_MouseMove);
            //this.txtAccount.MouseMove += new MouseEventHandler(this.txtAccount_MouseMove);
            //this.txtPassword.MouseMove += new MouseEventHandler(this.txtPassword_MouseMove);
        }

        private void SetControlsSize()
        {
            int orgTop_txtaccount = 0;
            int orgTop_txtpassword = 0;
            int orgTop_picLoginSub = 0;
            int orgTop_picLoginMain = 0;
            int orgFormHeight = 0;

            orgTop_txtaccount = txtAccount.Top;
            orgTop_txtpassword = txtPassword.Top;
            orgTop_picLoginSub = picLoginSub.Top;
            orgTop_picLoginMain = picLoginMain.Top;
            orgFormHeight = this.Height;

            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;

            this.Top = 0;
            this.Left = 0;
            this.Width = iActulaWidth;
            this.Height = iActulaHeight;

            picLogo.Location = new System.Drawing.Point(0, 0);
            picLogo.Size = new Size(iActulaWidth - picLoginWidth, iActulaHeight);


            pnlLogin.Location = new System.Drawing.Point(iActulaWidth - picLoginWidth, 0);
            pnlLogin.Size = new Size(picLoginWidth, iActulaHeight);
            picLogin.Location = new System.Drawing.Point(0, 0);
            picLogin.Size = new Size(picLoginWidth, iActulaHeight);

            txtAccount.Top = (orgTop_txtaccount * iActulaHeight / orgFormHeight);
            txtPassword.Top = (orgTop_txtpassword * iActulaHeight / orgFormHeight);
            picLoginSub.Top= (orgTop_picLoginSub * iActulaHeight / orgFormHeight);
            picLoginMain.Top= (orgTop_picLoginMain * iActulaHeight / orgFormHeight);

            picLoginMain.BringToFront();
        }

        private BaseResultEntity UserLogin()
        {
            string sUserAccount = string.Empty;
            string sUserPassword = string.Empty;
            BaseResultEntity rst = new BaseResultEntity();

            sUserAccount = txtAccount.Text;
            sUserPassword = MD5Helper.ToMD5(txtPassword.Text);

            if (!string.IsNullOrEmpty(sUserAccount) && !string.IsNullOrEmpty(sUserPassword))
            {
                TokenResultEntity getToken = provide.GetToken();
                if (getToken.Code != 0)
                {
                    rst.Code = getToken.Code;
                    rst.ErrMsg = "获取Token失败, 错误信息： " + getToken.ErrMsg;
                }

                BaseResultEntity result = provide.CheckBackEndAccount(sUserAccount, sUserPassword);
                if (result.Code == 0)
                {
                    rst.Code = result.Code;
                    rst.ErrMsg = "登录验证成功！";
                }
                else
                {
                    rst.Code = 100;
                    rst.ErrMsg = "登录验证失败，请输入正确的用户名，密码！";
                }
            }
            else
            {
                rst.Code = 100;
                rst.ErrMsg = "登录验证失败，请输入正确的用户名，密码！";
            }

            return rst;
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picLoginMain_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT","LGN");
            Cursor.Current = Cursors.Hand;
            if (picLoginSub.Visible == false)
            {
                picLoginSub.Visible = true;
                picLoginSub.BringToFront();
            }
        }

        private void MxSetForm(string AsType, string AsSel = "")
        {
            if (AsType == "INIT")
            {
                if (AsSel != "LGN")
                {
                    picLoginMain.Visible = true;
                    picLoginSub.Visible = false;
                }
            }
        }

        private void picLoginSub_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            BaseResultEntity result = new BaseResultEntity();
            picLoginSub.Enabled = false;
            result = UserLogin();
            if (result.Code != 0)
            {
                MessageBox.Show(result.ErrMsg);
                picLoginSub.Enabled = true;
                return;
            }
            picLoginSub.Enabled = true;
            this.Hide();
            frmMain main = frmMain.GetInstance();
            main.Show();
        }

        private void picLogin_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void picLogo_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //回车
            {
                if (string.IsNullOrEmpty(txtAccount.Text))
                {
                    MessageBox.Show("请输入帐号！");
                    txtAccount.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("请输入密码！");
                    txtPassword.Focus();
                }
                else
                {
                    Login();
                }
            }
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //回车
            {
                if (string.IsNullOrEmpty(txtAccount.Text))
                {
                    MessageBox.Show("请输入帐号！");
                    txtAccount.Focus();
                }
                else
                {
                    SendKeys.Send("{tab}");  
                }
            }
        }
    }
}

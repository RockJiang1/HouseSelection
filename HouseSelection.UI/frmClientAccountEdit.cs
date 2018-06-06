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
    public partial class frmClientAccountEdit : Form
    {
        private int id  = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmClientAccountEdit()
        {
            InitializeComponent();

            frmClientAccountManagement fm = new frmClientAccountManagement();
            textBox1.Text = fm.model.ProjectNumber + fm.model.ProjectName;
            textBox2.Text = fm.model.Account;
            id = fm.model.AccountID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientAccountManagement fm = new frmClientAccountManagement();
            fm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = string.Empty;
            string passwordold = string.Empty;
            string password1st = string.Empty;
            string password2nd = string.Empty;

            account = textBox2.Text;
            passwordold = textBox3.Text;
            password1st = textBox4.Text;
            password2nd = textBox5.Text;

            if (ValidPassword(password1st, password2nd) == true)
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

                BaseResultEntity editFrontEndAccount = provide.EditFrontEndAccount(id, account, passwordold, password1st);
                if (editFrontEndAccount.Code != 0)
                {
                    MessageBox.Show("前台帐号创建失败, 错误信息： " + editFrontEndAccount.ErrMsg);
                    return;
                }
                else
                {
                    MessageBox.Show("前台帐号创建成功！");
                }

            }
            else
            {
                MessageBox.Show("密码输入不正确！");
            }
        }

        private bool ValidPassword(string pwd1st, string pwd2nd)
        {
            bool result = false;

            if (pwd1st == pwd2nd & !string.IsNullOrEmpty(pwd1st)) { result = true; }

            return result;
        }
    }
}

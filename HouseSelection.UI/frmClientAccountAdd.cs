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
    public partial class frmClientAccountAdd : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmClientAccountAdd()
        {
            InitializeComponent();

            GlobalTokenHelper.gToken = "";
            GlobalTokenHelper.Expiry = 0;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }
            GlobalTokenHelper.gToken = getToken.Access_Token;
            GlobalTokenHelper.Expiry = getToken.Expiry;

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getProject.errMsg);
                return;
            }
            else
            {
                comboBox1.DataSource = getProject;//绑定数据源
                comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
                comboBox1.ValueMember = "ID";//实际值
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientAccountManagement fm = new frmClientAccountManagement();
            fm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int projrctId = 0;
            string account = string.Empty;
            string password1st = string.Empty;
            string password2nd = string.Empty;

            projrctId = Convert.ToInt32(projrctId);
            account = textBox1.Text;
            password1st = textBox2.Text;
            password2nd = textBox3.Text;

            if (ValidPassword(password1st, password2nd) == true)
            {
                GlobalTokenHelper.gToken = "";
                GlobalTokenHelper.Expiry = 0;

                TokenResultEntity getToken = provide.GetToken();
                if (getToken.code != 0)
                {
                    MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                    return;
                }
                GlobalTokenHelper.gToken = getToken.Access_Token;
                GlobalTokenHelper.Expiry = getToken.Expiry;

                BaseResultEntity addFrontEndAccount = provide.AddFrontEndAccount(projrctId, account, password1st);
                if (addFrontEndAccount.code != 0)
                {
                    MessageBox.Show("前台帐号创建失败, 错误信息： " + addFrontEndAccount.errMsg);
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

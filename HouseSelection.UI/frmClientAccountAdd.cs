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
        private Dictionary<int, String> chklist = new Dictionary<int, string>();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmClientAccountAdd frmCAccountAdd;
        public frmClientAccountAdd()
        {
            InitializeComponent();

            InitForm();

            GetProjects();
        }

        public static frmClientAccountAdd GetInstance()
        {
            if (frmCAccountAdd == null)
            {
                frmCAccountAdd = new frmClientAccountAdd();
            }
            return frmCAccountAdd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientAccountManagement fm = frmClientAccountManagement.GetInstance();
            fm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = string.Empty;
            string password1st = string.Empty;
            string password2nd = string.Empty;

            account = textBox1.Text;
            password1st = MD5Helper.ToMD5(textBox2.Text);
            password2nd = MD5Helper.ToMD5(textBox3.Text);

            if (ValidPassword(password1st, password2nd) == true)
            {
                List<int> projrctId = new List<int>();
                CheckedListBox.CheckedItemCollection listChecked = checkedListBox1.CheckedItems;
                for (int i = 0; i < listChecked.Count; i++)
                {
                    //将被选中item的text打印出来
                    textBox4.Text = textBox4.Text + " " + listChecked[i].ToString();
                    int id = chklist.Where(x => x.Value == listChecked[i].ToString()).Select(x => x.Key).FirstOrDefault();
                    if (id > 0)
                    {
                        projrctId.Add(id);
                    }
                }

                TokenResultEntity getToken = provide.GetToken();
                if (getToken.Code != 0)
                {
                    MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                    return;
                }

                BaseResultEntity addFrontEndAccount = provide.AddFrontEndAccount(projrctId, account, password1st);
                if (addFrontEndAccount.Code != 0)
                {
                    MessageBox.Show("前台帐号创建失败, 错误信息： " + addFrontEndAccount.ErrMsg);
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

        private void InitForm()
        {
            checkedListBox1.Visible = false;
        }

        private void GetProjects()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            ProjectEntityResponse getProject = provide.GetAllProjects();
            if (getProject.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                for(int i =0;i< getProject.ProjectList.Count; i++)
                {
                    checkedListBox1.Items.Add(getProject.ProjectList[i].Name);
                    chklist.Add(getProject.ProjectList[i].ID, getProject.ProjectList[i].Name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Visible == false)
            {
                checkedListBox1.Visible = true;
            }
            else
            {
                checkedListBox1.Visible = false;
            }
            
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //textBox4.Text = "";
            //CheckedListBox.CheckedItemCollection listChecked = checkedListBox1.CheckedItems;
            //for (int i = 0; i < listChecked.Count; i++)
            //{
            //    //将被选中item的text打印出来
            //    textBox4.Text = textBox4.Text + " " + listChecked[i].ToString();

            //}
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            CheckedListBox.CheckedItemCollection listChecked = checkedListBox1.CheckedItems;
            for (int i = 0; i < listChecked.Count; i++)
            {
                //将被选中item的text打印出来
                textBox4.Text = textBox4.Text + " " + listChecked[i].ToString();

            }
        }
    }
}

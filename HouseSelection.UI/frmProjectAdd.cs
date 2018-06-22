using System;
using System.Windows.Forms;
using HouseSelection.Utility;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmProjectAdd : MetroFramework.Forms.MetroForm
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmProjectAdd frmProAdd = null;
        private bool formCreate = false;
        public frmProjectAdd()
        {
            InitializeComponent();
            InitForm();
            formCreate = true;
        }

        public static frmProjectAdd GetInstance()
        {
            if (frmProAdd == null)
            {
                frmProAdd = new frmProjectAdd();
            }
            return frmProAdd;
        }

        public void Exec()
        {
            if (formCreate == false) { InitForm(); }
        }

        private void InitForm()
        {
            lblContent.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            txtName.Text = "";
            txtCompany.Text = "";
            txtIdentityNumber.Text = "";
            cbArea.DataSource = null;
            BaseHelper baseHelper = new BaseHelper();
            cbArea.DataSource = baseHelper.GetAreaList();//绑定数据源
            cbArea.DisplayMember = "Name";//主要是设置下拉框显示的值
            cbArea.ValueMember = "ID";//实际值
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmProjectManagement fm = frmProjectManagement.GetInstance();
            frmProAdd = null;
            this.Close();
        }

        private void DisPlayPrompt(int type,string msg)
        {
            if (type == 0)
            {
                frmPromptError fm = frmPromptError.GetInstance(msg);
                fm.Exec(msg);
                fm.ShowDialog();
            }
            else if (type == 1)
            {
                frmPromptSuccess fm = frmPromptSuccess.GetInstance(msg);
                fm.Exec(msg);
                fm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            BaseResultEntity result = IsValidProjectInfo();
            if (result.Code != 0)
            {
                msg = "输入信息有误, 错误信息： " + result.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }

            AddProjectRequest para = new AddProjectRequest()
            {
                Number = lblContent.Text,
                Name = txtName.Text,
                DevelopCompany = txtCompany.Text,
                IdentityNumber = txtIdentityNumber.Text,
                ProjectArea = cbArea.Text
            };
            
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                msg = "获取Token失败, 错误信息： " + getToken.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }

            BaseResultEntity getProject = provide.AddProject(para);
            if (getProject.Code != 0)
            {
                msg = "添加项目失败, 错误信息： " + getProject.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }
            else
            {
                int curPageIndex = 1;
                msg = "添加项目成功！";
                DisPlayPrompt(1, msg);
                frmProjectManagement fm = frmProjectManagement.GetInstance();
                fm.GetProjectInfo(false, curPageIndex);
                frmProAdd = null;
                this.Close();
            }
        }

        private BaseResultEntity IsValidProjectInfo()
        {
            BaseResultEntity result = new BaseResultEntity();
            result.Code = 0;
            result.ErrMsg = "";
            if (string.IsNullOrEmpty(txtName.Text))
            {
                result.Code = 999;
                result.ErrMsg = "项目名称为空！";
                return result;
            }
            if (string.IsNullOrEmpty(txtCompany.Text))
            {
                result.Code = 999;
                result.ErrMsg = "开发企业为空！";
                return result;
            }
            if (string.IsNullOrEmpty(txtIdentityNumber.Text))
            {
                result.Code = 999;
                result.ErrMsg = "预售证号为空！";
                return result;
            }
            
            return result;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
            }
            else
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompany.Text))
            {
                txtCompany.Focus();
            }
            else
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtIdentityNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentityNumber.Text))
            {
                txtIdentityNumber.Focus();
            }
            else
            {
                SendKeys.Send("{tab}");
            }
        }

        private void frmProjectAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProAdd = null;
            this.Close();
        }
    }
}

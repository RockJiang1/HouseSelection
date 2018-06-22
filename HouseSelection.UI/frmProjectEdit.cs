using System;
using System.Windows.Forms;
using HouseSelection.Utility;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmProjectEdit : MetroFramework.Forms.MetroForm
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        private int projectId = 0;
        private bool formCreate = false;
        public static frmProjectEdit frmProEdit = null;

        private frmProjectEdit(EditProjectRequest model)
        {
            InitializeComponent();

            InitForm(model);

            formCreate = true;
        }

        public static frmProjectEdit GetInstance(EditProjectRequest model)
        {
            if(frmProEdit == null)
            {
                frmProEdit = new frmProjectEdit(model);
            }
            return frmProEdit;
        }

        public void Exec(EditProjectRequest model)
        {
            if (formCreate == false) { InitForm(model); }
        }

        private void InitForm(EditProjectRequest model)
        {
            BaseHelper baseHelper = new BaseHelper();
            cbArea.DataSource = baseHelper.GetAreaList();//绑定数据源
            cbArea.DisplayMember = "Name";//主要是设置下拉框显示的值
            cbArea.ValueMember = "ID";//实际值

            projectId = model.ID;
            lblContent.Text = model.Number;
            txtName.Text = model.Name;
            txtCompany.Text = model.DevelopCompany;
            txtIdentityNumber.Text = model.IdentityNumber;
            cbArea.Text = model.ProjectArea;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmProjectManagement fm = frmProjectManagement.GetInstance();
            frmProEdit = null;
            this.Close();
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

            EditProjectRequest para = new EditProjectRequest()
            {
                ID = projectId,
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

            BaseResultEntity getProject = provide.EditProject(para);
            if (getProject.Code != 0)
            {
                msg = "修改项目失败, 错误信息： " + getProject.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }
            else
            {
                int curPageIndex = 1;
                msg = "修改项目成功！";
                DisPlayPrompt(0, msg);
                frmProjectManagement fm = frmProjectManagement.GetInstance();
                fm.GetProjectInfo(false, curPageIndex);
                frmProEdit = null;
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

        private void frmProjectEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProEdit = null;
            this.Close();
            //this.Dispose();
        }

        private void DisPlayPrompt(int type, string msg)
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
    }
}


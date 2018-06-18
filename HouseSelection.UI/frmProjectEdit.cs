using System;
using System.Windows.Forms;
using HouseSelection.Utility;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmProjectEdit : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        private int projectId = 0;

        public static frmProjectEdit frmProEdit;

        private frmProjectEdit(EditProjectRequest model)
        {
            InitializeComponent();

            InitForm(model);
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
            InitForm(model);
        }

        private void InitForm(EditProjectRequest model)
        {
            BaseHelper baseHelper = new BaseHelper();
            comboBox1.DataSource = baseHelper.GetAreaList();//绑定数据源
            comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
            comboBox1.ValueMember = "ID";//实际值

            projectId = model.ID;
            label1.Text = model.Number;
            textBox1.Text = model.Name;
            textBox2.Text = model.DevelopCompany;
            textBox3.Text = model.IdentityNumber;
            comboBox1.Text = model.ProjectArea;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProjectManagement fm = frmProjectManagement.GetInstance();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseResultEntity result = IsValidProjectInfo();
            if (result.Code != 0)
            {
                MessageBox.Show("输入信息有误, 错误信息： " + result.ErrMsg);
            }

            EditProjectRequest para = new EditProjectRequest()
            {
                ID = projectId,
                Number = label1.Text,
                Name = textBox1.Text,
                DevelopCompany = textBox2.Text,
                IdentityNumber = textBox3.Text,
                ProjectArea = comboBox1.Text
            };

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            BaseResultEntity getProject = provide.EditProject(para);
            if (getProject.Code != 0)
            {
                MessageBox.Show("修改项目失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                MessageBox.Show("修改项目成功！");
                frmProjectManagement fm = frmProjectManagement.GetInstance();
                fm.GetProjectInfo(false);
                this.Close();
            }
        }

        private BaseResultEntity IsValidProjectInfo()
        {
            BaseResultEntity result = new BaseResultEntity();
            result.Code = 0;
            result.ErrMsg = "";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                result.Code = 999;
                result.ErrMsg = "项目名称为空！";
                return result;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                result.Code = 999;
                result.ErrMsg = "开发企业为空！";
                return result;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                result.Code = 999;
                result.ErrMsg = "预售证号为空！";
                return result;
            }

            return result;
        }
    }
}


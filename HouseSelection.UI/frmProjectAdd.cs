using System;
using System.Windows.Forms;
using HouseSelection.Utility;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmProjectAdd : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();

        public static frmProjectAdd frmProAdd;
        public frmProjectAdd()
        {
            InitializeComponent();  
        }

        public static frmProjectAdd GetInstance()
        {
            if (frmProAdd == null)
            {
                frmProAdd = new frmProjectAdd();
            }
            return frmProAdd;
        }

        private void frmProjectAdd_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void InitForm()
        {
            label1.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            BaseHelper baseHelper = new BaseHelper();
            comboBox1.DataSource = baseHelper.GetAreaList();//绑定数据源
            comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
            comboBox1.ValueMember = "ID";//实际值
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

            AddProjectRequest para = new AddProjectRequest()
            {
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

            BaseResultEntity getProject = provide.AddProject(para);
            if (getProject.Code != 0)
            {
                MessageBox.Show("添加项目失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                MessageBox.Show("添加项目成功！");
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

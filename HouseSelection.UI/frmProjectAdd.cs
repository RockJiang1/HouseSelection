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
    public partial class frmProjectAdd : Form
    {
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmProjectAdd()
        {
            InitializeComponent();

            label1.Text = DateTime.Now.ToString("yyyyMMddHHmmss");

            BaseHelper baseHelper = new BaseHelper();
            comboBox1.DataSource = baseHelper.GetAreaList();//绑定数据源
            comboBox1.DisplayMember = "Name";//主要是设置下拉框显示的值
            //comboBox1.ValueMember = "ID";//实际值
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseResultEntity result = IsValidProjectInfo();
            if (result.code !=0)
            {
                MessageBox.Show("输入信息有误, 错误信息： " + result.errMsg);
            }

            AddProjectRequest para = new AddProjectRequest();
            para.Number = label1.Text;
            para.Name = textBox1.Text;
            para.DevelopCompany = textBox2.Text;
            para.IdentityNumber= textBox3.Text;
            para.ProjectArea = comboBox1.Text;

            TokenResultEntity getToken = provide.GetToken();
            if (getToken.code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.errMsg);
                return;
            }

            BaseResultEntity getProject = provide.AddProject(para);
            if (getProject.code != 0)
            {
                MessageBox.Show("添加项目失败, 错误信息： " + getProject.errMsg);
                return;
            }
            else
            {
                MessageBox.Show("添加项目成功！");
            }
        }

        private BaseResultEntity IsValidProjectInfo()
        {
            BaseResultEntity result = new BaseResultEntity();
            result.code = 0;
            result.errMsg = "";
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                result.code = 999;
                result.errMsg = "项目名称为空！";
                return result;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                result.code = 999;
                result.errMsg = "开发企业为空！";
                return result;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                result.code = 999;
                result.errMsg = "预售证号为空！";
                return result;
            }
            
            return result;
        }
    }
}

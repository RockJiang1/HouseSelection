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
    public partial class frmSubscribePersonImport : Form
    {

        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();

        public frmSubscribePersonImport()
        {
            InitializeComponent();

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

            //comboBox1.DataSource = getProject.ProjectList;
            //comboBox1.DisplayMember= getProject.ProjectList
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";

            dialog.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            dialog.ValidateNames = true;
            dialog.CheckPathExists = true;
            dialog.CheckFileExists = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file = textBox1.Text;
            string result = "";

            DataTable dt = new DataTable();
            ExcelResultEntity excel = new ExcelResultEntity();
            int iprojectId;
            try
            {
                iprojectId = 2;
               
                TokenResultEntity getToken = provide.GetToken();
                if (getToken.Code != 0)
                {
                    MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                    return;
                }

                using (ExcelHelper excelHelper = new ExcelHelper(file))
                {
                    excel = excelHelper.GetExcelAttribute();
                    if (excel.Code != 0 || excel.SheetNumber == 0)
                    {
                        MessageBox.Show("Excel 异常请核对！");
                        return;
                    }
                    foreach (SheetName item in excel.SheetName)
                    {
                        dt = excelHelper.ExcelToDataTable(item.Name, true, 0);
                        if (dt == null || dt.Rows.Count <= 1)
                        {
                            MessageBox.Show("Excel sheet名称： " + item.Name + "数据为空！");
                            return;
                        }
                        else
                        {
                            
                            result = provide.ImportSubscriber(dt, iprojectId, item.Name);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

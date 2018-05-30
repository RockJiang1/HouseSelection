using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HouseSelection.Utility;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Request;
using HouseSelection.NetworkHelper;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmHousesImport : Form
    {
        private GeneralClient Client = new GeneralClient();
        public frmHousesImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "Excel文件(*.xls,*.xlsx)|*.xls,*.xlsx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file = textBox1.Text;
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(file))
                {
                    DataTable dt = excelHelper.ExcelToDataTable();
                }

                var request = new GetTokenRequest()
                {
                    AppId = "SYY",
                    AppSecret = "0B2223C37F54864403847E762E1F87F3"
                };

                var tokenRequest = this.Client.InvokeAPI<TokenResultEntity>(request);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

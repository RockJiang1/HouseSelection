using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HouseSelection.Utility;

namespace HouseSelection.UI
{
    public partial class frmSubscribePersonImport : Form
    {
        public frmSubscribePersonImport()
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

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}

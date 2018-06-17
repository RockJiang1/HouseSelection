using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseSelection.UI
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        public static frmMain main;
        public frmMain()
        {
            InitializeComponent();
        }

        public static frmMain GetInstance()
        {
            if (main == null)
            {
                main = new frmMain();
            }
            return main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProjectManagement fm = frmProjectManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmShakingNumbersManagement fm = frmShakingNumbersManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHousesManagement fm = frmHousesManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSubscribePersonManagement fm = frmSubscribePersonManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmClientAccountManagement fm = frmClientAccountManagement.GetInstance();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSelectRoleManagement fm = frmSelectRoleManagement.GetInstance();
            fm.Show();
            this.Hide();
        }
    }
}

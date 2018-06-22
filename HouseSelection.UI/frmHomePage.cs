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
    public partial class frmHomePage : Form
    {
        public static frmHomePage frmMainPage;
        public frmHomePage()
        {
            InitializeComponent();

            InitForm();
        }

        public static frmHomePage GetInstance()
        {
            if (frmMainPage == null)
            {
                frmMainPage = new frmHomePage();
            }
            return frmMainPage;
        }

        private void InitForm()
        {
            picHomePage.Location = new System.Drawing.Point(0, 0);
            picHomePage.Size = new Size(this.Width, this.Height);
        }

        private void picHomePage_SizeChanged(object sender, EventArgs e)
        {
            picHomePage.Location = new System.Drawing.Point(0, 0);
            picHomePage.Size = new Size(this.Width, this.Height);
        }

        private void picHomePage_Resize(object sender, EventArgs e)
        {
            picHomePage.Location = new System.Drawing.Point(0, 0);
            picHomePage.Size = new Size(this.Width, this.Height);
        }

    }
}

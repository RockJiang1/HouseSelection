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
        private static int intervaiTop = 5;
        private static int fixHeight = 35;
        public static frmMain main;
        public frmMain()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            SetControlsSize();
        }

        private void SetControlsSize()
        {
            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;

            picLogo.Location = new System.Drawing.Point(0, intervaiTop);
            picToolBar.Location = new System.Drawing.Point(picLogo.Width, intervaiTop);
            picToolBar.Size = new Size(iActulaWidth- picLogo.Width,picLogo.Height);

            gbMenu.Location = new System.Drawing.Point(0 , picLogo.Height + intervaiTop);
            gbMenu.Size = new Size(picLogo.Width, iActulaHeight- gbMenu.Top);

            for(int i = 1; i <= 10; i++)
            {
                string ctlMainName = "picMenuMain" + i.ToString();
                string ctlSubName = "picMenuSub" + i.ToString();

                ((PictureBox)gbMenu.Controls.Find(ctlMainName, true)[0]).Location = new System.Drawing.Point(0, (i - 1) * fixHeight + 1);
                ((PictureBox)gbMenu.Controls.Find(ctlMainName, true)[0]).Size = new Size(picLogo.Width, fixHeight);
                ((PictureBox)gbMenu.Controls.Find(ctlSubName, true)[0]).Location = new System.Drawing.Point(0, (i - 1) * fixHeight + 1);
                ((PictureBox)gbMenu.Controls.Find(ctlSubName, true)[0]).Size = new Size(picLogo.Width, fixHeight);
                ((PictureBox)gbMenu.Controls.Find(ctlMainName, true)[0]).BringToFront();
            }

            pnlChildForm.Location = new System.Drawing.Point(gbMenu.Width, gbMenu.Top);
            pnlChildForm.Size = new Size(picToolBar.Width, gbMenu.Height);
        }

        public static frmMain GetInstance()
        {
            if (main == null)
            {
                main = new frmMain();
            }
            return main;
        }

        private void picMenuMain1_Click(object sender, EventArgs e)
        {
            
        }

        private void picMenuMain2_Click(object sender, EventArgs e)
        {
            frmProjectManagement fm = frmProjectManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain3_Click(object sender, EventArgs e)
        {
            frmHousesManagement fm = frmHousesManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain4_Click(object sender, EventArgs e)
        {
            frmSubscribePersonManagement fm = frmSubscribePersonManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain5_Click(object sender, EventArgs e)
        {
            frmShakingNumbersManagement fm = frmShakingNumbersManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain6_Click(object sender, EventArgs e)
        {
            frmSelectRoleManagement fm = frmSelectRoleManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain7_Click(object sender, EventArgs e)
        {
            frmSelectTimePeriodManagement fm = frmSelectTimePeriodManagement.GetInstance();
            fm.Show();
        }

        private void picMenuMain8_Click(object sender, EventArgs e)
        {
            
        }

        private void picMenuMain9_Click(object sender, EventArgs e)
        {
            frmClientAccountManagement fm = frmClientAccountManagement.GetInstance();
            fm.Show();
        }
    }
}

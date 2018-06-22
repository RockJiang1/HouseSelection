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
    public partial class FrmPromptWarning : Form
    {
        public FrmPromptWarning()
        {
            InitializeComponent();
            picbtnMainCancel.BringToFront();
            picbtnMainYes.BringToFront();
        }

        private void picbtnMainCancel_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "CAL");
            Cursor.Current = Cursors.Hand;
            if (picbtnSubCancel.Visible == false)
            {
                picbtnSubCancel.Visible = true;
                picbtnSubCancel.BringToFront();
            }
        }

        private void picbtnMainYes_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "YES");
            Cursor.Current = Cursors.Hand;
            if (picbtnSubYes.Visible == false)
            {
                picbtnSubYes.Visible = true;
                picbtnSubYes.BringToFront();
            }
        }

        private void picbtnSubCancel_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void picbtnSubYes_Click(object sender, EventArgs e)
        {
            frmMain main = frmMain.GetInstance();
            main.Show();
            this.Close();
        }

        private void MxSetForm(string AsType, string AsSel = "")
        {
            if (AsType == "INIT")
            {
                if (AsSel != "CAL")
                {
                    picbtnMainCancel.Visible = true;
                    picbtnSubCancel.Visible = false;
                }

                if (AsSel != "YES")
                {
                    picbtnMainYes.Visible = true;
                    picbtnSubYes.Visible = false;
                }
            }
        }

        private void picPage_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }
    }
}

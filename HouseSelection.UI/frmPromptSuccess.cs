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
    public partial class frmPromptSuccess : Form
    {
        public static frmPromptSuccess frmSuccess = null;
        private bool formCreate = false;
        public frmPromptSuccess(string msg)
        {
            InitializeComponent();
            InitForm(msg);
            formCreate = true;
        }

        private void InitForm(string msg)
        {
            picbtnMainOK.BringToFront();
            lblPrompt.Text = msg;
        }

        public static frmPromptSuccess GetInstance(string msg)
        {
            if (frmSuccess == null)
            {
                frmSuccess = new frmPromptSuccess(msg);
            }
            return frmSuccess;
        }

        public void Exec(string msg)
        {
            if (formCreate == false) { InitForm(msg); }
        }

        private void picbtnMainOK_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "MAIN");
            Cursor.Current = Cursors.Hand;
            if (picbtnSubOK.Visible == false)
            {
                picbtnSubOK.Visible = true;
                picbtnSubOK.BringToFront();
            }
        }

        private void MxSetForm(string AsType, string AsSel = "")
        {
            if (AsType == "INIT")
            {
                if (AsSel != "MAIN")
                {
                    picbtnMainOK.Visible = true;
                    picbtnSubOK.Visible = false;
                }
            }
        }

        private void picbtnSubOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picPage_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }
    }
}

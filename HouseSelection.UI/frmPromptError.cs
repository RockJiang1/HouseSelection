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
    public partial class frmPromptError : Form
    {
        public static frmPromptError frmError = null;
        private bool formCreate = false;
        public frmPromptError(string msg)
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

        public static frmPromptError GetInstance(string msg)
        {
            if (frmError == null)
            {
                frmError = new frmPromptError(msg);
            }
            return frmError;
        }

        public void Exec(string msg)
        {
            if (formCreate == false) { InitForm(msg);}
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

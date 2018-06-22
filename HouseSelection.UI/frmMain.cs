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
        private static int intervaiTop = 0;
        private static int fixHeight = 35;
        public static frmMain main;
        private int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
        private int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
        public frmMain()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            SetBackColor();

            SetControlsSize();

            SetHomePage();

            SetEventHandler();
        }

        private void SetEventHandler()
        {
            this.picMenuSub1.Click += new EventHandler(this.picMenuSub1_Click);
            this.picMenuSub2.Click += new EventHandler(this.picMenuSub2_Click);
            this.picMenuSub3.Click += new EventHandler(this.picMenuSub3_Click);
            this.picMenuSub4.Click += new EventHandler(this.picMenuSub4_Click);
            this.picMenuSub5.Click += new EventHandler(this.picMenuSub5_Click);
            this.picMenuSub6.Click += new EventHandler(this.picMenuSub6_Click);
            this.picMenuSub7.Click += new EventHandler(this.picMenuSub7_Click);
            this.picMenuSub8.Click += new EventHandler(this.picMenuSub8_Click);
            this.picMenuSub9.Click += new EventHandler(this.picMenuSub9_Click);
            this.picMenuSub10.Click += new EventHandler(this.picMenuSub10_Click);

            this.picMenuMain1.MouseMove += new MouseEventHandler(this.picMenuMain1_MouseMove);
            this.picMenuMain2.MouseMove += new MouseEventHandler(this.picMenuMain2_MouseMove);
            this.picMenuMain3.MouseMove += new MouseEventHandler(this.picMenuMain3_MouseMove);
            this.picMenuMain4.MouseMove += new MouseEventHandler(this.picMenuMain4_MouseMove);
            this.picMenuMain5.MouseMove += new MouseEventHandler(this.picMenuMain5_MouseMove);
            this.picMenuMain6.MouseMove += new MouseEventHandler(this.picMenuMain6_MouseMove);
            this.picMenuMain7.MouseMove += new MouseEventHandler(this.picMenuMain7_MouseMove);
            this.picMenuMain8.MouseMove += new MouseEventHandler(this.picMenuMain8_MouseMove);
            this.picMenuMain9.MouseMove += new MouseEventHandler(this.picMenuMain9_MouseMove);
            this.picMenuMain10.MouseMove += new MouseEventHandler(this.picMenuMain10_MouseMove);

        }

        private void SetBackColor()
        {
            splitContainer.Panel1.BackColor = Color.FromArgb(0, 21, 41);
        }

        private void SetHomePage()
        {
            frmHomePage childForm = frmHomePage.GetInstance();
            childForm.MdiParent = this;
            childForm.Parent = splitContainer.Panel2;

            childForm.WindowState = FormWindowState.Normal;
            childForm.Dock = DockStyle.Fill;
            childForm.Size = new Size(splitContainer.Width - splitContainer.SplitterDistance, splitContainer.Height);
            childForm.BringToFront();
            childForm.Show();
            //ShowChildForm<frmHomePage>();
        }

        private void SetControlsSize()
        {
            //int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            //int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;

            picLogo.Location = new System.Drawing.Point(0, intervaiTop);
            picToolBar.Location = new System.Drawing.Point(picLogo.Width, intervaiTop);
            picToolBar.Size = new Size(iActulaWidth- picLogo.Width,picLogo.Height);

            splitContainer.Location = new System.Drawing.Point(0, picLogo.Height + intervaiTop);
            splitContainer.Size = new Size(iActulaWidth, iActulaHeight - splitContainer.Top);
            splitContainer.SplitterDistance = picLogo.Width;

            //gbMenu.Location = new System.Drawing.Point(0 , picLogo.Height + intervaiTop);
            //gbMenu.Size = new Size(picLogo.Width, iActulaHeight- gbMenu.Top);

            for (int i = 1; i <= 10; i++)
            {
                string ctlMainName = "picMenuMain" + i.ToString();
                string ctlSubName = "picMenuSub" + i.ToString();

                ((PictureBox)splitContainer.Panel1.Controls.Find(ctlMainName, true)[0]).Location = new System.Drawing.Point(0, (i - 1) * fixHeight + 1);
                ((PictureBox)splitContainer.Panel1.Controls.Find(ctlMainName, true)[0]).Size = new Size(picLogo.Width, fixHeight);
                ((PictureBox)splitContainer.Panel1.Controls.Find(ctlSubName, true)[0]).Location = new System.Drawing.Point(0, (i - 1) * fixHeight + 1);
                ((PictureBox)splitContainer.Panel1.Controls.Find(ctlSubName, true)[0]).Size = new Size(picLogo.Width, fixHeight);
                ((PictureBox)splitContainer.Panel1.Controls.Find(ctlMainName, true)[0]).BringToFront();
            }
            
            //pnlChildForm.Location = new System.Drawing.Point(gbMenu.Width, gbMenu.Top);
            //pnlChildForm.Size = new Size(picToolBar.Width, gbMenu.Height);
        }

        public static frmMain GetInstance()
        {
            if (main == null)
            {
                main = new frmMain();
            }
            return main;
        }

        private void ShowChildForm<TForm>() where TForm : Form, new()
        {
            TForm childForm = new TForm();
            childForm.MdiParent = this;
            childForm.Parent = splitContainer.Panel2;

            childForm.WindowState = FormWindowState.Normal;
            childForm.Dock = DockStyle.Fill;
            childForm.Size = new Size(splitContainer.Width- splitContainer.SplitterDistance, splitContainer.Height);
            childForm.BringToFront();
            childForm.Show();
        }

        private void MxSetForm(string AsType, string AsSel = "")
        {
            if (AsType == "INIT")
            {
                if (AsSel != "HOM")
                {
                    picMenuMain1.Visible = true;
                    picMenuSub1.Visible = false;
                }

                if (AsSel != "PJM")
                {
                    picMenuMain2.Visible = true;
                    picMenuSub2.Visible = false;
                }

                if (AsSel != "HSI")
                {
                    picMenuMain3.Visible = true;
                    picMenuSub3.Visible = false;
                }

                if (AsSel != "SBM")
                {
                    picMenuMain4.Visible = true;
                    picMenuSub4.Visible = false;
                }

                if (AsSel != "SKM")
                {
                    picMenuMain5.Visible = true;
                    picMenuSub5.Visible = false;
                }

                if (AsSel != "SHR")
                {
                    picMenuMain6.Visible = true;
                    picMenuSub6.Visible = false;
                }

                if (AsSel != "SHT")
                {
                    picMenuMain7.Visible = true;
                    picMenuSub7.Visible = false;
                }

                if (AsSel != "CLA")
                {
                    picMenuMain8.Visible = true;
                    picMenuSub8.Visible = false;
                }

                if (AsSel != "RAM")
                {
                    picMenuMain9.Visible = true;
                    picMenuSub9.Visible = false;
                }

                if (AsSel != "IIP")
                {
                    picMenuMain10.Visible = true;
                    picMenuSub10.Visible = false;
                }
            }
        }

        private void picMenuMain1_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "HOM");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub1.Visible == false)
            {
                picMenuSub1.Visible = true;
                picMenuSub1.BringToFront();
            }
        }

        private void picMenuSub1_Click(object sender, EventArgs e)
        {
            frmHomePage childForm = frmHomePage.GetInstance();
            childForm.MdiParent = this;
            childForm.Parent = splitContainer.Panel2;

            childForm.WindowState = FormWindowState.Normal;
            childForm.Dock = DockStyle.Fill;
            childForm.Size = new Size(splitContainer.Width - splitContainer.SplitterDistance, splitContainer.Height);
            childForm.BringToFront();
            childForm.Show();
        }

        private void picMenuMain2_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "PJM");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub2.Visible == false)
            {
                picMenuSub2.Visible = true;
                picMenuSub2.BringToFront();
            }
        }



        private void picMenuSub2_Click(object sender, EventArgs e)
        {
            frmProjectManagement childForm = frmProjectManagement.GetInstance();
            childForm.MdiParent = this;
            childForm.Parent = splitContainer.Panel2;

            childForm.WindowState = FormWindowState.Normal;
            childForm.Dock = DockStyle.Fill;
            childForm.Size = new Size(splitContainer.Width - splitContainer.SplitterDistance, splitContainer.Height);
            childForm.BringToFront();
            childForm.Show();

        }

        private void picMenuMain3_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "HSI");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub3.Visible == false)
            {
                picMenuSub3.Visible = true;
                picMenuSub3.BringToFront();
            }
        }



        private void picMenuSub3_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain4_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "SBM");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub4.Visible == false)
            {
                picMenuSub4.Visible = true;
                picMenuSub4.BringToFront();
            }
        }



        private void picMenuSub4_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain5_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "SKM");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub5.Visible == false)
            {
                picMenuSub5.Visible = true;
                picMenuSub5.BringToFront();
            }
        }



        private void picMenuSub5_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain6_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "SHR");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub6.Visible == false)
            {
                picMenuSub6.Visible = true;
                picMenuSub6.BringToFront();
            }
        }



        private void picMenuSub6_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain7_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "SHT");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub7.Visible == false)
            {
                picMenuSub7.Visible = true;
                picMenuSub7.BringToFront();
            }
        }



        private void picMenuSub7_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain8_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "CLA");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub8.Visible == false)
            {
                picMenuSub8.Visible = true;
                picMenuSub8.BringToFront();
            }
        }



        private void picMenuSub8_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain9_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "RAM");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub9.Visible == false)
            {
                picMenuSub9.Visible = true;
                picMenuSub9.BringToFront();
            }
        }



        private void picMenuSub9_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picMenuMain10_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "IIP");
            Cursor.Current = Cursors.Hand;
            if (picMenuSub10.Visible == false)
            {
                picMenuSub10.Visible = true;
                picMenuSub10.BringToFront();
            }
        }



        private void picMenuSub10_Click(object sender, EventArgs e)
        {
            //BaseResultEntity result = new BaseResultEntity();
            //picLoginSub.Enabled = false;
            //result = UserLogin();
            //if (result.Code != 0)
            //{
            //    MessageBox.Show(result.ErrMsg);
            //    picLoginSub.Enabled = true;
            //    return;
            //}
            //picLoginSub.Enabled = true;
            //this.Hide();
            //frmMain main = frmMain.GetInstance();
            //main.Show();

        }

        private void picLogo_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void picToolBar_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void splitContainer_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void splitContainer_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }
    }
}

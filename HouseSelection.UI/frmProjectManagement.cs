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
using System.Drawing;

namespace HouseSelection.UI
{
    public partial class frmProjectManagement : Form
    {
        public EditProjectRequest model = new EditProjectRequest();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        private int recordCount = 0;
        private int pageindexttl = 0;
        public static frmProjectManagement frmProMgt;
        private frmProjectManagement()
        {
            int curpageIndex = 1;

            InitializeComponent();

            InitForm();

            GetProjectInfo(false, curpageIndex);
        }

        public static frmProjectManagement GetInstance()
        {
            if(frmProMgt == null)
            {
                frmProMgt = new frmProjectManagement();
            }
            return frmProMgt;
        }

        private void dgvDataSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataSource.Columns[e.ColumnIndex].Name == "Operate")
            {
                //可以在此打开新窗口，把参数传递过去
                model.ID = Convert.ToInt32(this.dgvDataSource.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                model.Number = this.dgvDataSource.Rows[e.RowIndex].Cells["Number"].Value.ToString();
                model.Name = this.dgvDataSource.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                model.DevelopCompany = this.dgvDataSource.Rows[e.RowIndex].Cells["DevelopCompany"].Value==null?"":this.dgvDataSource.Rows[e.RowIndex].Cells["DevelopCompany"].Value.ToString();
                model.IdentityNumber = this.dgvDataSource.Rows[e.RowIndex].Cells["IdentityNumber"].Value==null?"": this.dgvDataSource.Rows[e.RowIndex].Cells["IdentityNumber"].Value.ToString();
                model.ProjectArea = this.dgvDataSource.Rows[e.RowIndex].Cells["ProjectArea"].Value.ToString();
                frmProjectEdit fm = frmProjectEdit.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
        }

        private void clearDataView()
        {
            List<ProjectSource1st> list = new List<ProjectSource1st>();
            dgvDataSource.DataSource = list;
        }

        private void InitForm()
        {
            BaseHelper baseHelper = new BaseHelper();
            cbPage.DataSource = baseHelper.GetPageList();//绑定数据源
            cbPage.DisplayMember = "Name";//主要是设置下拉框显示的值
            cbPage.ValueMember = "ID";//实际值
            lblCurPage.Text = "1";
            txtSearchPage.Text = "";
            txtSearchPage.Enabled = false;
        }

        private void DisPlayPrompt(int type, string msg)
        {
            if (type == 0)
            {
                frmPromptError fm = frmPromptError.GetInstance(msg);
                fm.Exec(msg);
                fm.ShowDialog();
            }
            else if (type == 1)
            {
                frmPromptSuccess fm = frmPromptSuccess.GetInstance(msg);
                fm.Exec(msg);
                fm.ShowDialog();
            }
        }

        public void GetProjectInfo(bool isSearch, int pIndex)
        {
            string msg = string.Empty;
            int pagesize = 0;
            clearDataView();

            pagesize = Convert.ToInt32(cbPage.SelectedValue.ToString());
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                msg = "获取Token失败, 错误信息： " + getToken.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }

            ProjectEntityResponse getProject = new ProjectEntityResponse();
            
            if (isSearch == false)
            {
                getProject = provide.GetAllProjects(pIndex, pagesize);
            }
            else
            {
                string searchStr = string.Empty;
                searchStr = txtSearch.Text.Trim();
                getProject = provide.GetProjects(searchStr, pIndex, pagesize);
            }
            if (getProject.Code != 0)
            {
                msg = "获取项目信息失败, 错误信息： " + getProject.ErrMsg;
                DisPlayPrompt(0, msg);
                return;
            }
            else
            {
                List<ProjectSource1st> list = new List<ProjectSource1st>();
                foreach(ProjectEntityTemp item in getProject.ProjectList)
                {
                    ProjectSource1st obj = new ProjectSource1st();
                    obj.ID = item.ID;
                    obj.Number = item.Number;
                    obj.Name = item.Name;
                    obj.DevelopCompany = item.DevelopCompany;
                    obj.IdentityNumber = item.IdentityNumber;
                    obj.ProjectArea = item.ProjectArea;
                    obj.Operate = "修改项目";
                    list.Add(obj);
                }
                dgvDataSource.AutoGenerateColumns = true;
                dgvDataSource.DataSource = list;
                dgvDataSource.Height = dgvDataSource.RowTemplate.Height * list.Count + dgvDataSource.ColumnHeadersHeight + 10;
                dgvDataSource.Columns["Operate"].DefaultCellStyle.ForeColor = Color.DodgerBlue;
                dgvDataSource.Columns["Operate"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                pnlPageSize.Top = dgvDataSource.Top + dgvDataSource.Height;
                if (list.Count > 0)
                {
                    txtSearchPage.Text = "";
                    txtSearchPage.Enabled = true;
                    lblSumPage.Text = "共" + getProject.RecordCount + "条";
                    recordCount = getProject.RecordCount;
                    pageindexttl =Convert.ToInt32(Math.Ceiling((double)recordCount / (double)pagesize));
                    lblCurPage.Text = pIndex.ToString();
                    picprePageA.Visible = false;
                    picnextPageA.Visible = false;
                    picprePageB.BringToFront();
                    picnextPageB.BringToFront();
                    if (pIndex == 1)
                    {
                        picprePageA.Visible = true;
                        picprePageA.BringToFront();
                    }
                    if (pIndex == pageindexttl)
                    {
                        picnextPageA.Visible = true;
                        picnextPageA.BringToFront();
                    }
                    //if (pIndex != 1 && pIndex != pageindexttl)
                    //{
                    //    picprePageA.Visible = false;
                    //    picnextPageA.Visible = false;
                    //    picprePageB.BringToFront();
                    //    picnextPageB.BringToFront();
                    //}
                }
            }
        }

        private void btnProjectAdd_Click(object sender, EventArgs e)
        {
            frmProjectAdd fm = frmProjectAdd.GetInstance();
            fm.Exec();
            fm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int curpageIndex = 1;
            GetProjectInfo(true, curpageIndex);
        }

        private void picRefreshC_Click(object sender, EventArgs e)
        {
            int curpageIndex = 0;
            curpageIndex = Convert.ToInt32(txtSearchPage.Text);
            if (curpageIndex<= pageindexttl && curpageIndex > 0 && !string.IsNullOrEmpty(txtSearchPage.Text))
            {
                GetProjectInfo(true, curpageIndex);
            }
            else
            {
                txtSearchPage.Text = "";
                txtSearchPage.Focus();
            }
            
        }

        private void MxSetForm(string AsType, string AsSel = "")
        {
            if (AsType == "INIT")
            {
                if (AsSel != "PIC")
                {
                    picRefreshB.Visible = true;
                    picRefreshC.Visible = false;
                }
                if (AsSel != "PPR")
                {
                    picprePageB.Visible = true;
                    picprePageC.Visible = false;
                }
                if (AsSel != "PPN")
                {
                    picnextPageB.Visible = true;
                    picnextPageC.Visible = false;
                }
            }
        }

        private void picRefreshB_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "PIC");
            Cursor.Current = Cursors.Hand;
            if (picRefreshC.Visible == false)
            {
                picRefreshC.Visible = true;
                picRefreshC.BringToFront();
            }
        }

        private void picprePageB_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "PPR");
            Cursor.Current = Cursors.Hand;
            if (picprePageC.Visible == false)
            {
                picprePageC.Visible = true;
                picprePageC.BringToFront();
            }
        }

        private void picnextPageB_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT", "PPN");
            Cursor.Current = Cursors.Hand;
            if (picnextPageC.Visible == false)
            {
                picnextPageC.Visible = true;
                picnextPageC.BringToFront();
            }
        }

        private void pnlPageSize_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void dgvDataSource_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void frmProjectManagement_MouseMove(object sender, MouseEventArgs e)
        {
            MxSetForm("INIT");
        }

        private void picnextPageC_Click(object sender, EventArgs e)
        {
            int curpageIndex = 0;
            curpageIndex = Convert.ToInt32(lblCurPage.Text) + 1;
            GetProjectInfo(true, curpageIndex);
        }

        private void picprePageC_Click(object sender, EventArgs e)
        {
            int curpageIndex = 0;
            curpageIndex = Convert.ToInt32(lblCurPage.Text) - 1;
            GetProjectInfo(true, curpageIndex);
        }

        private void frmProjectManagement_Load(object sender, EventArgs e)
        {
            SetControlsSize();
            
        }

        private void SetControlsSize()
        {
            pnlPageSize.Top = dgvDataSource.Top + dgvDataSource.Height;
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int curpageIndex = 0;
            if (!string.IsNullOrEmpty(lblCurPage.Text))
            {
                curpageIndex = Convert.ToInt32(lblCurPage.Text);
                GetProjectInfo(true, curpageIndex);
            }
        }

        private void txtSearchPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
    }
}

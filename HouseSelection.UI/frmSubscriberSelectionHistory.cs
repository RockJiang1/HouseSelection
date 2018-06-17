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
    public partial class frmSubscriberSelectionHistory : Form
    {
        public SubscriberSelectionDetailData model = new SubscriberSelectionDetailData();
        private int subscriberId = 0;
        private bool optLock = false;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSubscriberSelectionHistory frmSubscriberSelHist;
        public frmSubscriberSelectionHistory(SubscriberEntityTemp model)
        {
            InitializeComponent();

            InitForm(model);
        }

        public static frmSubscriberSelectionHistory GetInstance(SubscriberEntityTemp model)
        {
            if (frmSubscriberSelHist == null)
            {
                frmSubscriberSelHist = new frmSubscriberSelectionHistory(model);
            }
            return frmSubscriberSelHist;
        }

        public void Exec(SubscriberEntityTemp model)
        {
            InitForm(model);
        }

        private void frmSubscriberSelectionHistory_Load(object sender, EventArgs e)
        {
            GetSubscriberSelectionHistory(subscriberId);
        }

        private void InitForm(SubscriberEntityTemp model)
        {
            label2.Text = model.Name;
            label3.Text = model.IdentityNumber;
            subscriberId= model.ID;
        }

        private void GetSubscriberSelectionHistory(int id)
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetSubscriberSelectionHistoryResponse getSubscriberSelectionHistory = provide.GetSubscriberSelectionHistory(id);

            if (getSubscriberSelectionHistory.Code != 0)
            {
                MessageBox.Show("获取认购人信息失败, 错误信息： " + getSubscriberSelectionHistory.ErrMsg);
                return;
            }
            else
            {
                List<SubscriberSelectionSource> list = new List<SubscriberSelectionSource>();
                foreach (SubscriberSelectionEntityTemp item in getSubscriberSelectionHistory.SelectionList)
                {
                    SubscriberSelectionSource obj = new SubscriberSelectionSource();
                    obj.ProjectID = item.ProjectID;
                    obj.ProjectNumber = item.ProjectNumber;
                    obj.ProjectName = item.ProjectName;
                    obj.NoticeStatus = item.NoticeStatus;
                    obj.AuthStatus = item.AuthStatus;
                    obj.SelectionStatus = item.SelectionStatus;
                    obj.ConfirmStatus = item.ConfirmStatus;
                    obj.AbandonStatus = item.AbandonStatus;
                    obj.ShakingResultID = item.ShakingResultID;
                    obj.SelectionID = item.SelectionID == null ? -1 : item.SelectionID;
                    obj.Operate1 = "通知录音";
                    obj.Operate2 = "选房详情";
                    list.Add(obj);
                }
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = list;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (this.dataGridView1.Rows[i].Cells["SelectionID"].Value.ToString() == "-1")
                    {
                        this.dataGridView1.Rows[i].Cells["Operate2"].Style.ForeColor = Color.Gray;
                        optLock = true;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells["Operate2"].Style.ForeColor = Color.Blue;
                        optLock = false;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate2" && optLock == false)
            {
                model.SelectionID = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells["SelectionID"].Value.ToString());
                model.Name = label2.Text;
                model.IdentityNumber = label3.Text;
                model.ProjectName = this.dataGridView1.Rows[e.RowIndex].Cells["ProjectName"].Value.ToString();
                frmSubscriberSelectionDetail fm = frmSubscriberSelectionDetail.GetInstance(model);
                fm.Exec(model);
                fm.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operate1")
            {

            }
        }
    }
}

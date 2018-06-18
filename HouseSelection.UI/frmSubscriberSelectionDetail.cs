using System;
using System.Windows.Forms;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;

namespace HouseSelection.UI
{
    public partial class frmSubscriberSelectionDetail : Form
    {
        private int selectionID = 0;
        private string projectName = string.Empty;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSubscriberSelectionDetail frmSubscriberSelDtl;
        public frmSubscriberSelectionDetail(SubscriberSelectionDetailData model)
        {
            InitializeComponent();

            InitForm(model);

            GetSelectionDetail();
        }

        public static frmSubscriberSelectionDetail GetInstance(SubscriberSelectionDetailData model)
        {
            if (frmSubscriberSelDtl == null)
            {
                frmSubscriberSelDtl = new frmSubscriberSelectionDetail(model);
            }
            return frmSubscriberSelDtl;
        }

        public void Exec(SubscriberSelectionDetailData model)
        {
            InitForm(model);

            GetSelectionDetail();
        }

        private void InitForm(SubscriberSelectionDetailData model)
        {
            label1.Text = model.Name;
            label2.Text = model.IdentityNumber;
            selectionID = model.SelectionID;
            projectName = model.ProjectName;
        }

        private void GetSelectionDetail()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetSelectionDetailResponse getSelectionDetail = provide.GetSelectionDetail(selectionID);

            if (getSelectionDetail.Code != 0)
            {
                MessageBox.Show("获取认购人信息失败, 错误信息： " + getSelectionDetail.ErrMsg);
                return;
            }
            else
            {
                if (getSelectionDetail.IsAbandon == true)
                {
                    label4.Text = "已弃选";
                }
                else
                {
                    label4.Text = "已确认";
                }
                label3.Text = projectName + getSelectionDetail.House.Building + "栋" + getSelectionDetail.House.Unit + "单元" + getSelectionDetail.House.RoomNumber + "室";
                LoadPicture(getSelectionDetail);
            }
        }

        private void LoadPicture(GetSelectionDetailResponse selectionDtl)
        {
            if (!string.IsNullOrEmpty(selectionDtl.SelectImageUrl1)) { pictureBox1.ImageLocation = selectionDtl.SelectImageUrl1;  }
            if (!string.IsNullOrEmpty(selectionDtl.SelectImageUrl2)) { pictureBox1.ImageLocation = selectionDtl.SelectImageUrl2; }
            if (!string.IsNullOrEmpty(selectionDtl.SelectImageUrl3)) { pictureBox1.ImageLocation = selectionDtl.SelectImageUrl3; }
            if (!string.IsNullOrEmpty(selectionDtl.AbandonImageUrl1)) { pictureBox1.ImageLocation = selectionDtl.AbandonImageUrl1; }
            if (!string.IsNullOrEmpty(selectionDtl.AbandonImageUrl2)) { pictureBox1.ImageLocation = selectionDtl.AbandonImageUrl2; }
            if (!string.IsNullOrEmpty(selectionDtl.AbandonImageUrl3)) { pictureBox1.ImageLocation = selectionDtl.AbandonImageUrl3; }
        }
    }
}

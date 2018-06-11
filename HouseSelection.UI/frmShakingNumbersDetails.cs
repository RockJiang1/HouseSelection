using System;
using System.Windows.Forms;
using System.Collections.Generic;
using HouseSelection.Provider;
using HouseSelection.Provider.Client;
using HouseSelection.Provider.Client.Response;
using HouseSelection.Model;


namespace HouseSelection.UI
{
    public partial class frmShakingNumbersDetails : Form
    {
        private int groupId = 0;
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmShakingNumbersDetails()
        {
            InitializeComponent();
        }

        private void frmShakingNumbersDetails_Load(object sender, EventArgs e)
        {
            InitForm();

            GetShakingNumberDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitForm()
        {
            frmShakingNumbersManagement fm = new frmShakingNumbersManagement();
            groupId = fm.model.ProjectGroupID;
            label1.Text = fm.model.ProjectNumber + " - " + fm.model.ProjectName;
            label1.Text = fm.model.ProjectGroupName;
        }

        private void GetShakingNumberDetails()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetShakingNumbersResponse getShakingNumbers = provide.GetShakingNumbers(groupId);

            if (getShakingNumbers.Code != 0 || getShakingNumbers.ShakingNumberResultList.Count == 0)
            {
                MessageBox.Show("获取摇号详情失败, 错误信息： " + getShakingNumbers.ErrMsg);
                return;
            }
            else
            {
                List<GetShakingNumberDetails> listTemp = new List<GetShakingNumberDetails>();

                foreach(GetShakingNumberResultEntityTemp item in getShakingNumbers.ShakingNumberResultList)
                {
                    GetShakingNumberDetails model = new GetShakingNumberDetails();
                    model.ShakingNumber = item.ShakingNumber;
                    model.ShakingNumberSequance = item.ShakingNumberSequance;
                    model.Name = item.Subscriber.Name;
                    model.IdentityNumber = item.Subscriber.IdentityNumber;
                    model.Telephone = item.Subscriber.Telephone;
                    listTemp.Add(model);
                }

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = listTemp;
            }
        }
    }
}

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
        public static frmShakingNumbersDetails frmShakingNumbersDtls;
        public frmShakingNumbersDetails(ProjectGroupEntityTemp model)
        {
            InitializeComponent();

            InitForm(model);

            GetShakingNumberDetails();
        }
        public static frmShakingNumbersDetails GetInstance(ProjectGroupEntityTemp model)
        {
            if (frmShakingNumbersDtls == null)
            {
                frmShakingNumbersDtls = new frmShakingNumbersDetails(model);
            }
            return frmShakingNumbersDtls;
        }

        public void Exec(ProjectGroupEntityTemp model)
        {
            InitForm(model);

            GetShakingNumberDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitForm(ProjectGroupEntityTemp model)
        {
            groupId = model.ProjectGroupID;
            label1.Text = model.ProjectNumber + " - " + model.ProjectName;
            label1.Text = model.ProjectGroupName;
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

            if (getShakingNumbers.Code != 0)
            {
                MessageBox.Show("获取摇号详情失败, 错误信息： " + getShakingNumbers.ErrMsg);
                return;
            }
            else
            {
                List<GetShakingNumberSource> listTemp = new List<GetShakingNumberSource>();

                foreach(GetShakingNumberResultEntityTemp item in getShakingNumbers.ShakingNumberResultList)
                {
                    GetShakingNumberSource model = new GetShakingNumberSource();
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

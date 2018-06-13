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

namespace HouseSelection.UI
{
    public partial class frmSelectRoleAdd : Form
    {
        private int projectId = 0;
        private Dictionary<int, String> ProjectGroupa1st = new Dictionary<int, string>();
        private Dictionary<int, String> RoomType1st = new Dictionary<int, string>();
        private Dictionary<int, String> FamilyNumber2nd = new Dictionary<int, string>();
        private Dictionary<int, String> RoomType2nd = new Dictionary<int, string>();
        private Dictionary<int, String> ProjectGroupa3rd = new Dictionary<int, string>();
        private Dictionary<int, String> HouseGroup3rd = new Dictionary<int, string>();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public frmSelectRoleAdd()
        {
            InitializeComponent();

            InitForm();

            GetProjectRoleBaseInfo();
        }

        private void InitForm()
        {
            frmSelectRoleManagement fm = new frmSelectRoleManagement();
            projectId = fm.model.ID;
            label1.Text = fm.model.Name;
        }

        private void GetProjectRoleBaseInfo()
        {
            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            GetProjectRoleBaseInfoResponse getProjectRoleBaseInfo = provide.GetProjectRoleBaseInfo(projectId);
            if (getProjectRoleBaseInfo.Code != 0)
            {
                MessageBox.Show("获取获取选房基本规则失败, 错误信息： " + getProjectRoleBaseInfo.ErrMsg);
                return;
            }
            else
            {
                AutoSetControls(getProjectRoleBaseInfo);
            }
        }

        private void AutoSetControls(GetProjectRoleBaseInfoResponse model)
        {
            //Role 1st
            //开始生成分组选房规则start
            int i = 0;
            int top_pg = 50;
            int left_pg = 15;
            foreach(ProjectGroupSingleEntityTemp gp in model.ProjectGroupList)
            {
                i++;
                Label label = new Label();
                label.Name = "lblRole1st" + i;
                label.Text = gp.ProjectGroupName;
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                ProjectGroupa1st.Add(gp.ProjectGroupID, label.Name);
                panel1.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;
                
                foreach (RoomTypeEntityTemp rt in model.RoomTypeList)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    chkbox.Name = "chkRole1st" + i + j;
                    chkbox.Text = rt.RoomTypeName;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    RoomType1st.Add(rt.RoomTypeID, chkbox.Name);
                    panel1.Controls.Add(chkbox);
                }
                top_pg = top_pg + 20;
            }
            //开始生成分组选房规则end

            //Role 2nd
            //开始生成家庭人数选房规则start
            i = 0;
            top_pg = 50;
            left_pg = 15;
            foreach (int num in model.FamilyNumber)
            {
                i++;
                Label label = new Label();
                label.Name = "lblRole2nd" + i;
                label.Text = num + "人家庭";
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                FamilyNumber2nd.Add(num, label.Name);
                panel2.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;
                foreach (RoomTypeEntityTemp rt in model.RoomTypeList)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    chkbox.Name = "chkRole2nd" + i + j;
                    chkbox.Text = rt.RoomTypeName;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    RoomType2nd.Add(rt.RoomTypeID, chkbox.Name);
                    panel2.Controls.Add(chkbox);
                }
                top_pg = top_pg + 20;
            }
            //开始生成家庭人数选房规则end

            //Role 3rd
            //开始生成分组选房规则start
            i = 0;
            top_pg = 50;
            left_pg = 15;
            foreach (ProjectGroupSingleEntityTemp gp in model.ProjectGroupList)
            {
                i++;
                Label label = new Label();
                label.Name = "lblRole3rd" + i;
                label.Text = gp.ProjectGroupName;
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                ProjectGroupa3rd.Add(gp.ProjectGroupID, label.Name);
                panel1.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;
                foreach (HouseGroupEntityTemp hg in model.HouseGroupList)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    chkbox.Name = "chkRole3rd" + i + j;
                    chkbox.Text = hg.HouseGroupName;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    HouseGroup3rd.Add(hg.HouseGroupID, chkbox.Name);
                    panel1.Controls.Add(chkbox);
                }
                top_pg = top_pg + 20;
            }
            //开始生成分组选房规则end
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmSelectRoleEdit : Form
    {
        private int projectId = 0;
        private List<DictionaryTemp> ProjectGroupa1st = new List<DictionaryTemp>();
        private List<DictionaryTemp> RoomType1st = new List<DictionaryTemp>();
        private List<DictionaryTemp> FamilyNumber2nd = new List<DictionaryTemp>();
        private List<DictionaryTemp> RoomType2nd = new List<DictionaryTemp>();
        private List<DictionaryTemp> ProjectGroupa3rd = new List<DictionaryTemp>();
        private List<DictionaryTemp> HouseGroup3rd = new List<DictionaryTemp>();
        private GeneralClient Client = new GeneralClient();
        BaseProvide provide = new BaseProvide();
        public static frmSelectRoleEdit frmSelRoleEdit;
        public frmSelectRoleEdit(ProjectEntityTemp model)
        {
            InitializeComponent();

            InitForm(model);

            GetProjectRoleBaseInfo();
        }

        public static frmSelectRoleEdit GetInstance(ProjectEntityTemp model)
        {
            if (frmSelRoleEdit == null)
            {
                frmSelRoleEdit = new frmSelectRoleEdit(model);
            }
            return frmSelRoleEdit;
        }

        public void Exec(ProjectEntityTemp model)
        {
            InitForm(model);
            GetProjectRoleBaseInfo();
        }

        private void InitForm(ProjectEntityTemp model)
        {
            projectId = model.ID;
            label1.Text = model.Name;
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

            GetSelectRoleByProjectIDResponse getSelectRoleByProjectID = provide.GetSelectRoleByProjectID(projectId);
            if (getProjectRoleBaseInfo.Code != 0)
            {
                MessageBox.Show("获取选房规则失败, 错误信息： " + getProjectRoleBaseInfo.ErrMsg);
                return;
            }

            AutoSetControls(getProjectRoleBaseInfo, getSelectRoleByProjectID);
        }

        private void AutoSetControls(GetProjectRoleBaseInfoResponse model, GetSelectRoleByProjectIDResponse data)
        {
            //Role 1st
            //开始生成分组选房规则start
            int i = 0;
            int top_pg = 50;
            int left_pg = 15;
            List<ProjectGroupSingleEntityTemp> gplist = new List<ProjectGroupSingleEntityTemp>();
            gplist = model.ProjectGroupList.OrderBy(x => x.ProjectGroupID).ToList();
            List<RoomTypeEntityTemp> rtlist = new List<RoomTypeEntityTemp>();
            rtlist = model.RoomTypeList.OrderBy(x => x.RoomTypeID).ToList();
            List<int> fnlist = new List<int>();
            fnlist = model.FamilyNumber.OrderBy(x => x).ToList();
            List<HouseGroupEntityTemp> hglist = new List<HouseGroupEntityTemp>();
            hglist = model.HouseGroupList.OrderBy(x => x.HouseGroupID).ToList();
            foreach (ProjectGroupSingleEntityTemp gp in gplist)
            {
                i++;
                DictionaryTemp labelobj = new DictionaryTemp();
                Label label = new Label();
                label.Name = "lblRole1st" + i;
                label.Text = gp.ProjectGroupName;
                labelobj.ListID = gp.ProjectGroupID;
                labelobj.ControlName = label.Name;
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                ProjectGroupa1st.Add(labelobj);
                panel1.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;

                foreach (RoomTypeEntityTemp rt in rtlist)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    DictionaryTemp chkobj = new DictionaryTemp();
                    chkbox.Name = "chkRole1st" + i + j;
                    chkbox.Text = rt.RoomTypeName;
                    chkobj.ListID = rt.RoomTypeID;
                    chkobj.ControlName = chkbox.Name;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    RoomType1st.Add(chkobj);
                    panel1.Controls.Add(chkbox);
                    int count = data.ProjectGroupAndRoomTypeRoleList.Where(x => x.ProjectGroupID == gp.ProjectGroupID && x.RoomTypeID == rt.RoomTypeID).Count();
                    if (count > 0) { chkbox.Checked = true; }
                    left_rt = left_rt + 200;
                }
                top_pg = top_pg + 30;
            }
            //开始生成分组选房规则end

            //Role 2nd
            //开始生成家庭人数选房规则start
            i = 0;
            top_pg = 50;
            left_pg = 15;
            foreach (int num in fnlist)
            {
                i++;
                DictionaryTemp labelobj = new DictionaryTemp();
                Label label = new Label();
                label.Name = "lblRole2nd" + i;
                label.Text = num + "人家庭";
                labelobj.ListID = num;
                labelobj.ControlName = label.Name;
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                FamilyNumber2nd.Add(labelobj);
                panel2.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;
                foreach (RoomTypeEntityTemp rt in rtlist)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    DictionaryTemp chkobj = new DictionaryTemp();
                    chkbox.Name = "chkRole2nd" + i + j;
                    chkbox.Text = rt.RoomTypeName;
                    chkobj.ListID = rt.RoomTypeID;
                    chkobj.ControlName = chkbox.Name;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    RoomType2nd.Add(chkobj);
                    panel2.Controls.Add(chkbox);
                    int count = data.FamilyNumberAndRoomTypeRoleList.Where(x => x.FamilyNumber == num && x.RoomTypeID == rt.RoomTypeID).Count();
                    if (count > 0) { chkbox.Checked = true; }
                    left_rt = left_rt + 200;
                }
                top_pg = top_pg + 20;
            }
            //开始生成家庭人数选房规则end

            //Role 3rd
            //开始生成分组选房规则start
            i = 0;
            top_pg = 50;
            left_pg = 15;
            foreach (ProjectGroupSingleEntityTemp gp in gplist)
            {
                i++;
                Label label = new Label();
                DictionaryTemp labelobj = new DictionaryTemp();
                label.Name = "lblRole3rd" + i;
                label.Text = gp.ProjectGroupName;
                labelobj.ListID = gp.ProjectGroupID;
                labelobj.ControlName = label.Name;
                label.Location = new System.Drawing.Point(left_pg, top_pg);
                ProjectGroupa3rd.Add(labelobj);
                panel1.Controls.Add(label);
                int j = 0;
                int top_rt = top_pg;
                int left_rt = 150;
                foreach (HouseGroupEntityTemp hg in hglist)
                {
                    j++;
                    CheckBox chkbox = new CheckBox();
                    DictionaryTemp chkobj = new DictionaryTemp();
                    chkbox.Name = "chkRole3rd" + i + j;
                    chkbox.Text = hg.HouseGroupName;
                    chkobj.ListID = hg.HouseGroupID;
                    chkobj.ControlName = chkbox.Name;
                    chkbox.Location = new System.Drawing.Point(left_rt, top_rt);
                    HouseGroup3rd.Add(chkobj);
                    panel3.Controls.Add(chkbox);
                    int count = data.ProjectGroupAndHouseGroupRoleList.Where(x => x.ProjectGroupID == gp.ProjectGroupID && x.HouseGroupID == hg.HouseGroupID).Count();
                    if (count > 0) { chkbox.Checked = true; }
                    left_rt = left_rt + 200;
                }
                top_pg = top_pg + 20;
            }
            //开始生成分组选房规则end
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            List<ProjectGroupAndRoomTypeRoleTemp> list1 = new List<ProjectGroupAndRoomTypeRoleTemp>();
            foreach (DictionaryTemp gpkv in ProjectGroupa1st)
            {
                i++;
                foreach (DictionaryTemp rtkv in RoomType1st)
                {
                    string value = rtkv.ControlName;
                    if (Convert.ToInt32(value.Substring(10, 1)) == i)
                    {
                        if (((CheckBox)panel1.Controls.Find(value, true)[0]).Checked == true)
                        {
                            ProjectGroupAndRoomTypeRoleTemp item = new ProjectGroupAndRoomTypeRoleTemp();
                            item.ProjectGroupID = gpkv.ListID;
                            item.RoomTypeID = rtkv.ListID;
                            list1.Add(item);
                        }
                    }
                }
            }

            i = 0;
            List<FamilyNumberAndRoomTypeRoleTemp> list2 = new List<FamilyNumberAndRoomTypeRoleTemp>();
            foreach (DictionaryTemp gpkv in FamilyNumber2nd)
            {
                i++;
                foreach (DictionaryTemp rtkv in RoomType2nd)
                {
                    string value = rtkv.ControlName;
                    if (Convert.ToInt32(value.Substring(10, 1)) == i)
                    {
                        if (((CheckBox)panel2.Controls.Find(value, true)[0]).Checked == true)
                        {
                            FamilyNumberAndRoomTypeRoleTemp item = new FamilyNumberAndRoomTypeRoleTemp();
                            item.FamilyNumber = gpkv.ListID;
                            item.RoomTypeID = rtkv.ListID;
                            list2.Add(item);
                        }
                    }
                }
            }

            i = 0;
            List<ProjectGroupAndHouseGroupRoleTemp> list3 = new List<ProjectGroupAndHouseGroupRoleTemp>();
            foreach (DictionaryTemp gpkv in ProjectGroupa3rd)
            {
                i++;
                foreach (DictionaryTemp rtkv in HouseGroup3rd)
                {
                    string value = rtkv.ControlName;
                    if (Convert.ToInt32(value.Substring(10, 1)) == i)
                    {
                        if (((CheckBox)panel3.Controls.Find(value, true)[0]).Checked == true)
                        {
                            ProjectGroupAndHouseGroupRoleTemp item = new ProjectGroupAndHouseGroupRoleTemp();
                            item.ProjectGroupID = gpkv.ListID;
                            item.HouseGroupID = rtkv.ListID;
                            list3.Add(item);
                        }
                    }
                }
            }


            TokenResultEntity getToken = provide.GetToken();
            if (getToken.Code != 0)
            {
                MessageBox.Show("获取Token失败, 错误信息： " + getToken.ErrMsg);
                return;
            }

            BaseResultEntity getProject = provide.EditSelectRole(projectId, list1, list2, list3);
            if (getProject.Code != 0)
            {
                MessageBox.Show("编辑项目规则失败, 错误信息： " + getProject.ErrMsg);
                return;
            }
            else
            {
                int curPageIndex = 1;
                MessageBox.Show("编辑项目规则成功！");
                frmProjectManagement fm = frmProjectManagement.GetInstance();
                fm.GetProjectInfo(false, curPageIndex);
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 按项目ID获取选房规则
    /// </summary>
    public class GetSelectRoleByProjectIDController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private RoleProjectGroupAndRoomTypeBLL _role1BLL = new RoleProjectGroupAndRoomTypeBLL();
        private RoleFamilyNumberAndRoomTypeBLL _role2BLL = new RoleFamilyNumberAndRoomTypeBLL();
        private RoleProjectGroupAndHouseGroupBLL _role3BLL = new RoleProjectGroupAndHouseGroupBLL();

        [ApiAuthorize]
        public GetSelectRoleResultEntity Post(GetSelectRoleRequestModel req)
        {
            Logger.LogDebug("GetSelectRoleByProjectID Request:" + JsonHelper.SerializeObject(req), "GetSelectRoleByProjectIDController", "Post");
            var ret = new GetSelectRoleResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var role1 = _role1BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).ToList();
                var role2 = _role2BLL.GetModels(x => x.ProjectID == req.ProjectID).ToList();
                var role3 = _role3BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).ToList();
                if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.Code = 201;
                    ret.ErrMsg = "项目ID不存在！";
                }
                else if (role1.FirstOrDefault() == null || role2.FirstOrDefault() == null || role3.FirstOrDefault() == null)
                {
                    ret.Code = 805;
                    ret.ErrMsg = "该项目还未创建选房规则！";
                }
                else
                {
                    var role1List = new List<ProjectGroupAndRoomTypeRole>();
                    foreach(var _role1 in role1)
                    {
                        var r1 = new ProjectGroupAndRoomTypeRole()
                        {
                            ProjectGroupID = _role1.ProjectGroupID,
                            RoomTypeID = _role1.RoomTypeID
                        };
                        role1List.Add(r1);
                    }
                    ret.ProjectGroupAndRoomTypeRoleList = role1List;

                    var role2List = new List<FamilyNumberAndRoomTypeRole>();
                    foreach (var _role2 in role2)
                    {
                        var r2 = new FamilyNumberAndRoomTypeRole()
                        {
                            FamilyNumber = _role2.FamilyNumber,
                            RoomTypeID = _role2.RoomTypeID
                        };
                        role2List.Add(r2);
                    }
                    ret.FamilyNumberAndRoomTypeRoleList = role2List;

                    var role3List = new List<ProjectGroupAndHouseGroupRole>();
                    foreach (var _role3 in role3)
                    {
                        var r3 = new ProjectGroupAndHouseGroupRole()
                        {
                            ProjectGroupID = _role3.ProjectGroupID,
                            HouseGroupID = _role3.HouseGroupID
                        };
                        role3List.Add(r3);
                    }
                    ret.ProjectGroupAndHouseGroupRoleList = role3List;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("获取选房规则时发生异常！", "GetSelectRoleByProjectIDController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

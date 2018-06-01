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
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers.SelectRole
{
    public class AddSelectRoleController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private RoleProjectGroupAndRoomTypeBLL _role1BLL = new RoleProjectGroupAndRoomTypeBLL();
        private RoleFamilyNumberAndRoomTypeBLL _role2BLL = new RoleFamilyNumberAndRoomTypeBLL();
        private RoleProjectGroupAndHouseGroupBLL _role3BLL = new RoleProjectGroupAndHouseGroupBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddSelectRoleRequestEntity req)
        {
            Logger.LogDebug("AddSelectRole Request:" + JsonHelper.SerializeObject(req), "AddSelectRoleController", "Post");
            var ret = new BaseResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.code = 201;
                    ret.errMsg = "项目ID不存在！";
                }
                else if(req.ProjectGroupAndRoomTypeRoleList == null || req.ProjectGroupAndRoomTypeRoleList.Count() == 0)
                {
                    ret.code = 801;
                    ret.errMsg = "项目分组与户型规则不能为空！";
                }
                else if (req.FamilyNumberAndRoomTypeRoleList == null || req.FamilyNumberAndRoomTypeRoleList.Count() == 0)
                {
                    ret.code = 802;
                    ret.errMsg = "家庭人数与户型规则不能为空！";
                }
                else if (req.ProjectGroupAndHouseGroupRoleList == null || req.ProjectGroupAndHouseGroupRoleList.Count() == 0)
                {
                    ret.code = 803;
                    ret.errMsg = "项目分组与房源分组规则不能为空！";
                }
                else if(_role1BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).FirstOrDefault() != null || _role2BLL.GetModels(x => x.ProjectID == req.ProjectID).FirstOrDefault() != null || _role3BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).FirstOrDefault() != null)
                {
                    ret.code = 804;
                    ret.errMsg = "该项目已经创建选房规则，请使用修改接口修改！";
                }
                else
                {
                    var dbRole1List = new List<RoleProjectGroupAndRoomType>();
                    foreach(var _role1 in req.ProjectGroupAndRoomTypeRoleList)
                    {
                        var dbRole1 = new RoleProjectGroupAndRoomType()
                        {
                            ProjectGroupID = _role1.ProjectGroupID,
                            RoomTypeID = _role1.RoomTypeID,
                            CreateTime = DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        dbRole1List.Add(dbRole1);
                    }

                    var dbRole2List = new List<RoleFamilyNumberAndRoomType>();
                    foreach (var _role2 in req.FamilyNumberAndRoomTypeRoleList)
                    {
                        var dbRole2 = new RoleFamilyNumberAndRoomType()
                        {
                            FamilyNumber = _role2.FamilyNumber,
                            RoomTypeID = _role2.RoomTypeID,
                            CreateTime = DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        dbRole2List.Add(dbRole2);
                    }

                    var dbRole3List = new List<RoleProjectGroupAndHouseGroup>();
                    foreach (var _role3 in req.ProjectGroupAndHouseGroupRoleList)
                    {
                        var dbRole3 = new RoleProjectGroupAndHouseGroup()
                        {
                            ProjectGroupID = _role3.ProjectGroupID,
                            HouseGroupID = _role3.HouseGroupID,
                            CreateTime = DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        dbRole3List.Add(dbRole3);
                    }

                    _role1BLL.AddRange(dbRole1List);
                    _role2BLL.AddRange(dbRole2List);
                    _role3BLL.AddRange(dbRole3List);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("创建选房规则时发生异常！", "AddSelectRoleController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

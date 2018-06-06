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

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 修改选房规则
    /// </summary>
    public class EditSelectRoleController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private RoleProjectGroupAndRoomTypeBLL _role1BLL = new RoleProjectGroupAndRoomTypeBLL();
        private RoleFamilyNumberAndRoomTypeBLL _role2BLL = new RoleFamilyNumberAndRoomTypeBLL();
        private RoleProjectGroupAndHouseGroupBLL _role3BLL = new RoleProjectGroupAndHouseGroupBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddSelectRoleRequestEntity req)
        {
            Logger.LogDebug("EditSelectRole Request:" + JsonHelper.SerializeObject(req), "EditSelectRoleController", "Post");
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            List<RoleProjectGroupAndRoomType> role1 = new List<RoleProjectGroupAndRoomType>();
            List<RoleFamilyNumberAndRoomType> role2 = new List<RoleFamilyNumberAndRoomType>();
            List<RoleProjectGroupAndHouseGroup> role3 = new List<RoleProjectGroupAndHouseGroup>();
            try
            {
                role1 = _role1BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).ToList();
                role2 = _role2BLL.GetModels(x => x.ProjectID == req.ProjectID).ToList();
                role3 = _role3BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).ToList();
                if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.Code = 201;
                    ret.ErrMsg = "项目ID不存在！";
                }
                else if (req.ProjectGroupAndRoomTypeRoleList == null || req.ProjectGroupAndRoomTypeRoleList.Count() == 0)
                {
                    ret.Code = 801;
                    ret.ErrMsg = "项目分组与户型规则不能为空！";
                }
                else if (req.FamilyNumberAndRoomTypeRoleList == null || req.FamilyNumberAndRoomTypeRoleList.Count() == 0)
                {
                    ret.Code = 802;
                    ret.ErrMsg = "家庭人数与户型规则不能为空！";
                }
                else if (req.ProjectGroupAndHouseGroupRoleList == null || req.ProjectGroupAndHouseGroupRoleList.Count() == 0)
                {
                    ret.Code = 803;
                    ret.ErrMsg = "项目分组与房源分组规则不能为空！";
                }
                else if (role1.FirstOrDefault() == null || role2.FirstOrDefault() == null || role3.FirstOrDefault() == null)
                {
                    ret.Code = 805;
                    ret.ErrMsg = "该项目还未创建选房规则，请使用创建接口！";
                }
                else
                {
                    //先删
                    _role1BLL.DeleteRange(role1);
                    _role2BLL.DeleteRange(role2);
                    _role3BLL.DeleteRange(role3);

                    //后插
                    var dbRole1List = new List<RoleProjectGroupAndRoomType>();
                    foreach (var _role1 in req.ProjectGroupAndRoomTypeRoleList)
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
            catch (Exception ex)
            {
                //回滚
                if(_role1BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).FirstOrDefault() == null && role1 != null && role1.Count() > 1)
                {
                    _role1BLL.AddRange(role1);
                }
                if (_role2BLL.GetModels(x => x.ProjectID == req.ProjectID).FirstOrDefault() == null && role2 != null && role2.Count() > 1)
                {
                    _role2BLL.AddRange(role2);
                }
                if (_role3BLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID).FirstOrDefault() == null && role3 != null && role3.Count() > 1)
                {
                    _role3BLL.AddRange(role3);
                }

                Logger.LogException("修改选房规则时发生异常！", "EditSelectRoleController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

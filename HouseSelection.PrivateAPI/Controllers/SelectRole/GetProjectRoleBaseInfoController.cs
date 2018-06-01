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

namespace HouseSelection.PrivateAPI.Controllers.SelectRole
{
    public class GetProjectRoleBaseInfoController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        private HouseGroupBLL _houseGroupBLL = new HouseGroupBLL();
        private HouseBLL _houseBLL = new HouseBLL();
        private SubscriberProjectMappingBLL _subscriberMapping = new SubscriberProjectMappingBLL();

        [ApiAuthorize]
        public GetProjectRoleBaseInfoResultEntity Post(GetProjectRoleBaseInfoRequestModel req)
        {
            Logger.LogDebug("GetProjectRoleBaseInfo Request:" + JsonHelper.SerializeObject(req), "GetProjectRoleBaseInfoController", "Post");
            var ret = new GetProjectRoleBaseInfoResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                if(_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.code = 201;
                    ret.errMsg = "项目ID不存在！";
                }
                else
                {
                    var _dbprojectGroupList = _projectGroupBLL.GetModels(x => x.ProjectID == req.ProjectID).ToList();
                    var _projectGroupList = new List<ProjectGroupSingleEntity>();
                    foreach(var proGrp in _dbprojectGroupList)
                    {
                        var _proGrp = new ProjectGroupSingleEntity()
                        {
                            ProjectGroupID = proGrp.ID,
                            ProjectGroupName = proGrp.ProjectGroupName
                        };
                        _projectGroupList.Add(_proGrp);
                    }
                    ret.ProjectGroupList = _projectGroupList;

                    var _dbroomTypeList = _houseBLL.GetModels(x => x.ProjectID == req.ProjectID).Select(x => x.RoomType).Distinct().OrderBy(x => x.ID).ToList();
                    var _roomTypeList = new List<RoomTypeEntity>();
                    foreach(var room in _dbroomTypeList)
                    {
                        var _room = new RoomTypeEntity()
                        {
                            RoomTypeID = room.ID,
                            RoomTypeName = room.Name
                        };
                        _roomTypeList.Add(_room);
                    }
                    ret.RoomTypeList = _roomTypeList;

                    var _dbhouseGroupList = _houseGroupBLL.GetModels(x => x.ProjectID == req.ProjectID).ToList();
                    var _houseGroupList = new List<HouseGroupEntity>();
                    foreach(var houseGroup in _dbhouseGroupList)
                    {
                        var _houseGroup = new HouseGroupEntity()
                        {
                            HouseGroupID = houseGroup.ID,
                            HouseGroupName = houseGroup.Name
                        };
                        _houseGroupList.Add(_houseGroup);
                    }
                    ret.HouseGroupList = _houseGroupList;

                    var _dbfamilyNumberList = _subscriberMapping.GetModels(x => x.ProjectID == req.ProjectID).Select(x => x.Subscriber.FamilyMemberNumber + 1).Distinct().ToList();
                    ret.FamilyNumber = _dbfamilyNumberList;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("", "", "", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

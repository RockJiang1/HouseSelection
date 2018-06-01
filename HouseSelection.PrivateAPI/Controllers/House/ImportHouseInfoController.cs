using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class ImportHouseInfoController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private HouseBLL _houseBLL = new HouseBLL();
        private HouseGroupBLL _houseGroupBLL = new HouseGroupBLL();
        private RoomTypeBLL _roomTypeBLL = new RoomTypeBLL();
        private HouseEstateBLL _houseEstateBLL = new HouseEstateBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(ImportHouseInfoRequestEntity ImportHouse)
        {
            Logger.LogDebug("ImportHouseInfo Request:" + JsonHelper.SerializeObject(ImportHouse), "ImportHouseInfoController", "Post");
            var ret = new BaseResultEntity();
            try
            {
                if(ImportHouse != null && ImportHouse.HouseList != null)
                {
                    if(_projectBLL.GetModels(x => x.ID == ImportHouse.ProjectID) != null)
                    {
                        #region 创建楼盘
                        var _houseEstate = _houseEstateBLL.GetModels(x => x.Name == ImportHouse.HouseEstate);
                        if (_houseEstate == null || _houseEstate.Count() == 0)
                        {
                            _houseEstateBLL.Add(new HouseEstate() { ProjectID = ImportHouse.ProjectID, Name = ImportHouse.HouseEstate,CreateTime = DateTime.Now, LastUpdate = DateTime.Now });
                        }
                        #endregion

                        #region 创建房源分组
                        var groupList = ImportHouse.HouseList.GroupBy(x => x.Group).ToList();
                        var _existGroup = _houseGroupBLL.GetModels(x => x.ProjectID == ImportHouse.ProjectID);
                        List<string> addGroupList = new List<string>();
                        foreach (var group in groupList)
                        {
                            if(!_existGroup.Any(x => x.Name == group.Key))
                            {
                                if(!addGroupList.Any(x => x == group.Key))
                                {
                                    addGroupList.Add(group.Key);
                                }
                            }
                        }
                        var _hsList = new List<HouseGroup>();
                        foreach(string a in addGroupList)
                        {
                            HouseGroup _hs = new HouseGroup()
                            {
                                ProjectID = ImportHouse.ProjectID,
                                Name = a,
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now
                            };
                            _hsList.Add(_hs);
                        }
                        _houseGroupBLL.AddRange(_hsList);
                        #endregion

                        #region 创建户型
                        var roomTypeGroupList = ImportHouse.HouseList.GroupBy(x => x.RoomType).ToList();
                        var _existRoomType = _roomTypeBLL.GetModels(x => 1 == 1).ToList();
                        List<string> addRoomTypeList = new List<string>();
                        foreach(var group in roomTypeGroupList)
                        {
                            if (!_existRoomType.Any(x => x.Name == group.Key))
                            {
                                if (!addRoomTypeList.Any(x => x == group.Key))
                                {
                                    addRoomTypeList.Add(group.Key);
                                }
                            }
                        }
                        var _rtList = new List<RoomType>();
                        foreach (string a in addRoomTypeList)
                        {
                            RoomType _rt = new RoomType()
                            {
                                Name = a,
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now
                            };
                            _rtList.Add(_rt);
                        }
                        _roomTypeBLL.AddRange(_rtList);
                        #endregion

                        #region 创建房源
                        var _houseGroup = _houseGroupBLL.GetModels(x => x.ProjectID == ImportHouse.ProjectID);
                        var _roomTypeGroup = _roomTypeBLL.GetModels(x => 1 == 1);
                        var _existhouse = _houseBLL.GetModels(x => x.ProjectID == ImportHouse.ProjectID);
                        int _houseEstateID = _houseEstateBLL.GetModels(x => x.ProjectID == ImportHouse.ProjectID).FirstOrDefault().ID;

                        List<House> addHouseList = new List<House>();
                        foreach(var house in ImportHouse.HouseList)
                        {
                            if(_existhouse.Any(x => x.SerialNumber == house.SerialNumber))  //去重
                            {
                                continue;
                            }
                            else
                            {
                                int _groupID = _houseGroup.FirstOrDefault(x => x.Name == house.Group).ID;
                                int _roomTypeID = _roomTypeGroup.FirstOrDefault(x => x.Name == house.RoomType).ID;

                                House _house = new House()
                                {
                                    ProjectID = ImportHouse.ProjectID,
                                    SerialNumber = house.SerialNumber,
                                    GroupID = _groupID,
                                    Block = house.Block == null ? "" : house.Block,
                                    Building = house.Building,
                                    Unit = house.Unit,
                                    RoomNumber = house.RoomNumber == null ? "" : house.RoomNumber,
                                    RoomTypeID = _roomTypeID,
                                    Toward = house.Toward == null ? "" : house.Toward,
                                    RoomTypeCode = house.RoomType,
                                    EstimateBuiltUpArea = house.EstimateBuiltUpArea,
                                    EstimateLivingArea = house.EstimateLivingArea,
                                    AreaUnitPrice = house.AreaUnitPrice,
                                    TotalPrice = house.TotalPrice,
                                    CreateTime = DateTime.Now,
                                    LastUpdate = DateTime.Now,
                                    HouseEstateID = _houseEstateID
                                };
                                addHouseList.Add(_house);
                            }
                        }
                        _houseBLL.AddRange(addHouseList);
                        #endregion
                    }
                    else
                    {
                        ret.code = 302;
                        ret.errMsg = "导入的房源信息所属项目不存在！";
                    }
                }
                else
                {
                    ret.code = 301;
                    ret.errMsg = "导入的房源信息不允许为空！";
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("导入房源信息时发生异常！", "ImportHouseInfoController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

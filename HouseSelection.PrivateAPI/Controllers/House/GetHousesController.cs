using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 按分组、地块、楼号搜索房源信息_
    /// </summary>
    public class GetHousesController : ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        [ApiAuthorize]
        public GetHouseResultEntity Post(GetHousesRequestModel req)
        {
            Logger.LogDebug("GetHouses Request:" + JsonHelper.SerializeObject(req), "GetHousesController", "Post");
            GetHouseResultEntity ret = new GetHouseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };
            try
            {
                var _houseList = _houseBLL.GetModels(x => x.HouseEstateID == req.HouseEstateID).OrderBy(x => x.ID).ToList();
                var _tmpGroup = _houseList.Where(x => x.HouseGroup.Name.Contains(req.SearchStr));
                var _tmpBlock = _houseList.Where(x => x.Block.Contains(req.SearchStr));
                var _tmpBuilding = _houseList.Where(x => x.Building.ToString().Contains(req.SearchStr));

                var _tmpHouseList = _tmpGroup.Union(_tmpBlock).Union(_tmpBuilding);
                var _endHouseList = _tmpHouseList.Skip((req.PageIndex - 1) * req.PageSize).Take(req.PageSize);
                var _retHouseList = new List<HouseEntity>();
                foreach (var _hs in _endHouseList)
                {
                    var _retHouse = new HouseEntity()
                    {
                        HouseID = _hs.ID,
                        SerialNumber = _hs.SerialNumber,
                        Group = _hs.HouseGroup.Name,
                        Block = _hs.Block,
                        Building = _hs.Building,
                        Unit = _hs.Unit,
                        RoomNumber = _hs.RoomNumber,
                        Toward = _hs.Toward,
                        RoomType = _hs.RoomType.Name,
                        EstimateBuiltUpArea = _hs.EstimateBuiltUpArea,
                        EstimateLivingArea = _hs.EstimateLivingArea,
                        AreaUnitPrice = _hs.AreaUnitPrice,
                        TotalPrice = _hs.TotalPrice,
                        SubscriberID = _hs.SubscriberID,
                        SubscriberName = _hs.SubscriberID == null ? "" : _hs.Subscriber.Name
                    };
                    _retHouseList.Add(_retHouse);
                }
                ret.HouseList = _retHouseList;
                ret.RecordCount = _tmpHouseList.Count();
            }
            catch (Exception ex)
            {
                Logger.LogException("搜索房源信息时发生异常！", "GetHousesController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

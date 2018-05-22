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

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 按楼盘ID获取所有房源信息
    /// </summary>
    public class GetAllHouseInfoController : ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        [ApiAuthorize]
        public GetHouseResultEntity Post(GetAllHouseInfoRequestModel req)
        {
            GetHouseResultEntity ret = new GetHouseResultEntity()
            {
                code = 0,
                errMsg = ""
            };
            try
            {
                var _houseList = _houseBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.HouseEstateID == req.HouseEstateID);
                var _retHouseList = new List<HouseEntity>();
                foreach(var _hs in _houseList)
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
                ret.recordCount = _houseBLL.GetModels(x => x.HouseEstateID == req.HouseEstateID).Count();
            }
            catch(Exception ex)
            {
                Logger.LogException("按楼盘ID获取房源信息时发生异常！", "GetAllHouseInfoController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

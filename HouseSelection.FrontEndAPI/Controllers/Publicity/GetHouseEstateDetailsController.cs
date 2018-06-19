using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PublicityRequest;
using HouseSelection.FrontEndAPI.Models.PublicityResult;
using HouseSelection.LoggerHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.Publicity
{
    public class GetHouseEstateDetailsController:ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();
        SubscriberBLL _subscriberBLL = new SubscriberBLL();
        HouseGroupBLL _houseGroupBLL = new HouseGroupBLL();
        RoomTypeBLL _roomTypeBLL = new RoomTypeBLL();

        public GetHouseEstateDetailsResultEntity Post(GetHouseEstateDetailsRequestModel req)
        {
            var ret = new GetHouseEstateDetailsResultEntity()
            {
                Code = 0,
                ErrMsg = "",
                Houses = new List<HouseInfo>()
            };

            try
            {
                if (req.HouseEstateId <= 0 || req.ProjectId <= 0)
                {
                    ret.Code = 401;
                    ret.ErrMsg = "入参无效。";
                }
                else
                {
                    var houses = _houseBLL.GetModels(h => h.ProjectID == req.ProjectId && h.HouseEstateID == req.HouseEstateId && h.Building == req.BuildingId).ToList();

                    houses.ForEach(h => 
                    {
                        var houseInfo = new HouseInfo();
                        houseInfo.Building = h.Building;
                        houseInfo.Unit = h.Unit;

                        var subscriberInfo = _subscriberBLL.GetModels(i => i.ID == h.SubscriberID).FirstOrDefault();
                        string subscriberName = string.Empty;
                        if (subscriberInfo != null)
                        {
                            subscriberName = subscriberInfo.Name;
                        }

                        var groupInfo = _houseGroupBLL.GetModels(g => g.ID == h.GroupID).FirstOrDefault();
                        string groupName = string.Empty;
                        if (groupInfo != null)
                        {
                            groupName = groupInfo.Name;
                        }

                        var roomTypeInfo = _roomTypeBLL.GetModels(r => r.ID == h.RoomTypeID).FirstOrDefault();
                        string roomType = string.Empty;
                        if (roomTypeInfo != null)
                        {
                            roomType = roomTypeInfo.Name;
                        }
                        bool isSelected = ((h.SubscriberID != null) && h.SubscriberID > 0);
                        houseInfo.HouseDetail = new Model.HouseEntity()
                        {
                            AreaUnitPrice = h.AreaUnitPrice,
                            Block = h.Block,
                            Building = h.Building,
                            EstimateBuiltUpArea = h.EstimateBuiltUpArea,
                            EstimateLivingArea = h.EstimateLivingArea,
                            Group = groupName,
                            HouseID = h.ID,
                            RoomNumber = h.RoomNumber,
                            RoomType = roomType,
                            SerialNumber = h.SerialNumber,
                            TotalPrice = h.TotalPrice,
                            Toward = h.Toward,
                            Unit = h.Unit,
                            IsSelected = isSelected ? 1 : 0
                        };
                        ret.Houses.Add(houseInfo);
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取楼盘明细信息时发生异常！", "GetHouseEstateDetailsController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}
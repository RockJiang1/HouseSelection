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
    /// 获取选房信息明细
    /// </summary>
    public class GetSelectionDetailController : ApiController
    {
        private HouseBLL _houseBLL = new HouseBLL();
        private HouseSelectionRecordBLL _selectionBLL = new HouseSelectionRecordBLL();

        [ApiAuthorize]
        public GetSelectionDetailResultEntity Post(GetSelectionDetailRequestModel req)
        {
            Logger.LogDebug("GetSelectionDetail Request:" + JsonHelper.SerializeObject(req), "GetSelectionDetailController", "Post");

            var ret = new GetSelectionDetailResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbSelection = _selectionBLL.GetModels(x => x.ID == req.SelectionID).FirstOrDefault();
                if(_dbSelection == null)
                {
                    ret.Code = 901;
                    ret.ErrMsg = "选房记录ID不存在！";
                }
                else
                {
                    var _dbHouse = _houseBLL.GetModels(x => x.ID == _dbSelection.HouseID).FirstOrDefault();
                    if(_dbHouse == null)
                    {
                        ret.Code = 901;
                        ret.ErrMsg = "选房记录对应的房源ID不存在！";
                    }
                    else
                    {
                        var _house = new HouseEntity()
                        {
                            HouseID = _dbHouse.ID,
                            SerialNumber = _dbHouse.SerialNumber,
                            Group = _dbHouse.HouseGroup.Name,
                            Block = _dbHouse.Block,
                            Building = _dbHouse.Building,
                            Unit = _dbHouse.Unit,
                            RoomNumber = _dbHouse.RoomNumber,
                            Toward = _dbHouse.Toward,
                            RoomType = _dbHouse.RoomType.Name,
                            EstimateBuiltUpArea = _dbHouse.EstimateBuiltUpArea,
                            EstimateLivingArea = _dbHouse.EstimateLivingArea,
                            AreaUnitPrice = _dbHouse.AreaUnitPrice,
                            TotalPrice = _dbHouse.TotalPrice,
                            SubscriberID = _dbHouse.SubscriberID,
                            SubscriberName = _dbHouse.Subscriber.Name
                        };
                        ret.House = _house;
                        ret.SelectTime = _dbSelection.SelectTime;
                        ret.SelectImageUrl1 = _dbSelection.SelectImageUrl1;
                        ret.SelectImageUrl2 = _dbSelection.SelectImageUrl2;
                        ret.SelectImageUrl3 = _dbSelection.SelectImageUrl3;
                        ret.IsAbandon = _dbSelection.IsAbandon;
                        ret.AbandonTime = _dbSelection.AbandonTime;
                        ret.AbandonImageUrl1 = _dbSelection.AbandonImageUrl1;
                        ret.AbandonImageUrl2 = _dbSelection.AbandonImageUrl2;
                        ret.AbandonImageUrl3 = _dbSelection.AbandonImageUrl3;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("获取认购人认购详情时发生异常！", "GetSelectionDetailController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

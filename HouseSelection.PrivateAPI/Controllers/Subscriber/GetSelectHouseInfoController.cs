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
    /// 获取选房详情
    /// </summary>
    public class GetSelectHouseInfoController : ApiController
    {
        public ProjectBLL _projectBLL = new ProjectBLL();
        public SubscriberBLL _subscriberBLL = new SubscriberBLL();
        public HouseSelectionRecordBLL _selectionBLL = new HouseSelectionRecordBLL();
        public HouseBLL _houseBLL = new HouseBLL();

        [ApiAuthorize]
        public GetSelectHouseInfoResult Post(GetSelectHouseInfoRequestModel req)
        {
            Logger.LogDebug("GetSelectHouseInfo Request:" + JsonHelper.SerializeObject(req), "GetSelectHouseInfoController", "Post");
            var ret = new GetSelectHouseInfoResult()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.Code = 201;
                    ret.ErrMsg = "项目ID不存在！";
                }
                if (_subscriberBLL.GetModels(x => x.ID == req.SubscriberID).FirstOrDefault() == null)
                {
                    ret.Code = 202;
                    ret.ErrMsg = "认购人ID不存在！";
                }
                else
                {
                    var selectResult = _selectionBLL.GetModels(x => x.ProjectID == req.ProjectID && x.SubscriberID == req.SubscriberID).FirstOrDefault();
                    if(selectResult != null)
                    {
                        var _hs = _houseBLL.GetModels(x => x.ID == selectResult.HouseID).FirstOrDefault();
                        var houseInfo = new HouseAndEstateEntity()
                        {
                            HouseEstateName = _hs.HouseEstate.Name,
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
                            TotalPrice = _hs.TotalPrice
                        };
                        ret.HouseInfo = houseInfo;
                    }
                    else
                    {
                        ret.Code = 203;
                        ret.ErrMsg = "该认购人未在该项目中选房！";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取选房详情发生", "GetSelectHouseInfoController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;

        }
    }
}

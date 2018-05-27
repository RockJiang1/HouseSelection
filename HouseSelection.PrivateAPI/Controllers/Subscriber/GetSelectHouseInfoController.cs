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
        public GetSelectHouseInfoResult Post(GetSelectHouseInfoRequest req)
        {
            var ret = new GetSelectHouseInfoResult()
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
                if (_subscriberBLL.GetModels(x => x.ID == req.SubscriberID).FirstOrDefault() == null)
                {
                    ret.code = 202;
                    ret.errMsg = "认购人ID不存在！";
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
                        ret.code = 203;
                        ret.errMsg = "该认购人未在该项目中选房！";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取选房详情发生", "GetSelectHouseInfoController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;

        }
    }
}

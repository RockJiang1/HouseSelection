using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.FrontEndAPI.Models.SelectHouseRequest;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;

namespace HouseSelection.FrontEndAPI.Controllers.SelectHouse
{
    public class ConfirmSelectHouseController : ApiController
    {
        private ShakingNumberResultBLL _shakingResultBLL = new ShakingNumberResultBLL();
        private HouseBLL _houseBLL = new HouseBLL();
        private HouseSelectionRecordBLL _selectRecordBLL = new HouseSelectionRecordBLL();
        private SelectingHouseStatusBLL _statusBLL = new SelectingHouseStatusBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(ConfirmSelectHouseRequestModel req)
        {
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _shakingResult = _shakingResultBLL.GetModels(x => x.ID == req.ShakingNumberResultId).FirstOrDefault();
                var _house = _houseBLL.GetModels(x => x.ID == req.HouseId).FirstOrDefault();
                var _status = _statusBLL.GetModels(x => x.ShakingNumberResultID == req.ShakingNumberResultId && x.SelectStatus == 1).FirstOrDefault();

                if (_shakingResult == null)
                {
                    ret.Code = 401;
                    ret.ErrMsg = "摇号结果ID不存在！";
                }
                else if(_house == null)
                {
                    ret.Code = 402;
                    ret.ErrMsg = "房源ID不存在！";
                }
                else if(_selectRecordBLL.GetModels(x => x.SubscriberID == _shakingResult.SubscriberProjectMapping.SubscriberID).FirstOrDefault() != null)
                {
                    ret.Code = 403;
                    ret.ErrMsg = "认购人已经在该项目中选择房源！";
                }
                else if(_selectRecordBLL.GetModels(x => x.HouseID == req.HouseId).FirstOrDefault() != null || _house.SubscriberID != null)
                {
                    ret.Code = 404;
                    ret.ErrMsg = "该房源已经被选择！";
                }
                else if (!_houseBLL.ValidHouseSelection(req.ShakingNumberResultId,req.HouseId)) //校验房源规则可选
                {
                    ret.Code = 405;
                    ret.ErrMsg = "该认购人不满足该房源选择条件！";
                }
                else if(_status == null)
                {
                    ret.Code = 406;
                    ret.ErrMsg = "选房状态不正确！";
                }
                else
                {
                    var _record = new HouseSelectionRecord()
                    {
                        ProjectID = _shakingResult.ProjectGroup.ProjectID,
                        HouseID = req.HouseId,
                        SubscriberID = _shakingResult.SubscriberProjectMapping.SubscriberID,
                        SelectTime = DateTime.Now,
                        SelectImageUrl1 = null,
                        SelectImageUrl2 = null,
                        SelectImageUrl3 = null,
                        IsConfirm = true,
                        IsAbandon = false,
                        AbandonTime = null,
                        AbandonImageUrl1 = null,
                        AbandonImageUrl2 = null,
                        AbandonImageUrl3 = null,
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _selectRecordBLL.Add(_record);

                    _house.SubscriberID = _shakingResult.SubscriberProjectMapping.SubscriberID;
                    _house.LastUpdate = DateTime.Now;
                    _houseBLL.Update(_house);

                    _status.SelectStatus = 2;
                    _status.LastUpdate = DateTime.Now;
                    _statusBLL.Update(_status);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("确认选房时发生异常！", "ConfirmSelectHouseController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

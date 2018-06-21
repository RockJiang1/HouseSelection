using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Authorize;
using HouseSelection.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    public class MarkPhoneCallStatusController:ApiController
    {
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(MarkPhoneCallStatusRequestModel req)
        {
            Logger.LogInfo("MarkPhoneCallStatus Request:" + JsonHelper.SerializeObject(req), "MarkPhoneCallStatusController", "Post");
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty
            };

            try
            {
                var snr = _shakingNumberResultBLL.GetModels(i => i.ID == req.ShakeNumberResultId).First();
                if (snr != null)
                {
                    if (req.IsCallBack)
                    {
                        snr.IsCallBack = true;
                    }
                    if (req.IsSendMessage)
                    {
                        snr.IsMessageSend = true;
                    }
                    _shakingNumberResultBLL.Update(snr);
                }
                else
                {
                    ret.Code = 99;
                    ret.ErrMsg = "没有id为" + req.ShakeNumberResultId + "的摇号记录。";
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("更新摇号通知状态时发生异常！", "MarkPhoneCallStatusController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}
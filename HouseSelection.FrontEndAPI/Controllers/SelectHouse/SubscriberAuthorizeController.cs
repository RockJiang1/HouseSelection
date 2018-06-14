using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.FrontEndAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;

namespace HouseSelection.FrontEndAPI.Controllers
{
    public class SubscriberAuthorizeController : ApiController
    {
        private ShakingNumberResultBLL _shakingBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public SubscriberAuthorizeResultEntity Post(SubscriberAuthorizeRequestModel req)
        {
            Logger.LogDebug("SubscriberAuthorize Request:" + JsonHelper.SerializeObject(req), "SubscriberAuthorizeController", "Post");

            var ret = new SubscriberAuthorizeResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbShaking = _shakingBLL.GetModels(x => x.ID == req.ShakingNumberResultID).FirstOrDefault();
                if(_dbShaking == null)
                {
                    ret.Code = 301;
                    ret.ErrMsg = "摇号结果不存在！";
                }
                else
                {
                    _dbShaking.IsAuthorized = true;
                    _dbShaking.IsAgent = req.IsAgent == 0 ? false : true;
                    _shakingBLL.Update(_dbShaking);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("按身份证获取认购人信息发生异常！", "GetSubscriberByIdentityController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

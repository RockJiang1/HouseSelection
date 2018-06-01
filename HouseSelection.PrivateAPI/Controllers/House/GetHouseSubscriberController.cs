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
    /// 按房源查询认购人信息
    /// </summary>
    public class GetHouseSubscriberController : ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        [ApiAuthorize]
        public GetHouseSubscriberResultEntity Post(GetHouseSubscriberRequestModel req)
        {
            Logger.LogDebug("GetHouseSubscriber Request:" + JsonHelper.SerializeObject(req), "GetHouseSubscriberController", "Post");
            GetHouseSubscriberResultEntity ret = new GetHouseSubscriberResultEntity()
            {
                code = 0,
                errMsg = ""
            };
            try
            {
                var _hs = _houseBLL.GetModels(x => x.ID == req.HouseID).FirstOrDefault();
                if(_hs != null && _hs.SubscriberID != null)
                {
                    SubscriberEntity sub = new SubscriberEntity()
                    {
                        ID = _hs.Subscriber.ID,
                        Name = _hs.Subscriber.Name,
                        IdentityNumber = _hs.Subscriber.IdentityNumber,
                        Telephone = _hs.Subscriber.Telephone,
                        Address = _hs.Subscriber.Address,
                        ZipCode = _hs.Subscriber.ZipCode,
                        MaritalStatus = _hs.Subscriber.MaritalStatus,
                        ResidenceArea = _hs.Subscriber.ResidenceArea,
                        WorkArea = _hs.Subscriber.WorkArea
                    };
                    ret.Subscriber = sub;
                }
                else
                {
                    ret.code = 205;
                    ret.errMsg = "查询房源的认购人不存在！";
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("获取房源认购人时发生异常！", "GetHouseSubscriberController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

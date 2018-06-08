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
    public class GetSubscriberByHouseIDController : ApiController
    {
        private HouseBLL _houseBLL = new HouseBLL();
        private HouseSelectionRecordBLL _houseSelectRecordBLL = new HouseSelectionRecordBLL();

        [ApiAuthorize]
        public GetSubscriberByHouseIDResultEntity Post(GetSubscriberByHouseIDRequestModel req)
        {
            Logger.LogDebug("GetSubscriberByHouseID Request:" + JsonHelper.SerializeObject(req), "GetSubscriberByHouseIDController", "Post");
            var ret = new GetSubscriberByHouseIDResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbHouse = _houseBLL.GetModels(x => x.ID == req.HouseID).FirstOrDefault();
                var _dbSelect = _houseSelectRecordBLL.GetModels(x => x.HouseID == req.HouseID && x.IsAbandon == false).FirstOrDefault();
                if (_dbHouse == null)
                {
                    ret.Code = 401;
                    ret.ErrMsg = "房源不存在！";
                }
                else if(_dbHouse.SubscriberID == null || _dbSelect == null)
                {
                    ret.Code = 402;
                    ret.ErrMsg = "该房源的认购人不存在！";
                }
                else
                {
                    ret.ID = _dbHouse.Subscriber.ID;
                    ret.Name = _dbHouse.Subscriber.Name;
                    ret.IdentityNumber = _dbHouse.Subscriber.IdentityNumber;
                    ret.Telephone = _dbHouse.Subscriber.Telephone;
                    ret.Address = _dbHouse.Subscriber.Address;
                    ret.ZipCode = _dbHouse.Subscriber.ZipCode;
                    ret.MaritalStatus = _dbHouse.Subscriber.MaritalStatus;
                    ret.ResidenceArea = _dbHouse.Subscriber.ResidenceArea;
                    ret.WorkArea = _dbHouse.Subscriber.WorkArea;
                    ret.SelectTime = _dbSelect.SelectTime;
                }
                
            }
            catch(Exception ex)
            {
                Logger.LogException("按房源ID获取认购人时发生异常！", "GetSubscriberByHouseIDController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

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
    public class GetRoomQuantityInfoController : ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        public GetRoomQuantityInfoResultEntity Post(GetRoomQuantityInfoRequestModel req)
        {
            var ret = new GetRoomQuantityInfoResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty
            };

            try
            {
                int total = 0;
                int used = 0;
                var houses = _houseBLL.GetModels(i => i.ProjectID == req.ProjectId && i.HouseEstateID == req.HouseEstateId).ToList();
                total = houses.Count;
                used = houses.Where(i => i.SubscriberID != null && i.SubscriberID > 0).Count();

                ret.Total = total;
                ret.Used = used;

            }
            catch (Exception ex)
            {
                Logger.LogException("获取楼盘房间数量信息时出现异常！", "GetAreaListController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}
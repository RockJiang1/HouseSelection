using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.SelectHouseRequest;
using HouseSelection.FrontEndAPI.Models.SelectHouseResult;
using HouseSelection.LoggerHelper;

namespace HouseSelection.FrontEndAPI.Controllers.SelectHouse
{
    public class GetValidBuildingsController : ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        public GetValidBuildingsResultEntity Post(GetValidBuildingsRequestModel req)
        {
            var ret = new GetValidBuildingsResultEntity()
            {
                Code = 0,
                ErrMsg = "",
                Buildings = new List<int>()
            };

            try
            {
                var houses = _houseBLL.GetModels(h => h.ProjectID == req.ProjectId && h.HouseEstateID == req.HouseEstateId).ToList();

                ret.Buildings = houses.Select(i => i.Building).Distinct().ToList();
            }
            catch (Exception ex)
            {
                Logger.LogException("获取栋数列表时发生异常！", "GetValidBuildingsController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}

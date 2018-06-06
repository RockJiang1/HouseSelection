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
    public class GetHouseBuildingsController:ApiController
    {
        HouseBLL _houseBLL = new HouseBLL();

        public GetHouseBuildingsResultEntity Post(GetHouseBuildingsRequestModel req)
        {
            var ret = new GetHouseBuildingsResultEntity()
            {
                code = 0,
                errMsg = "",
                Buildings = new List<int>()
            };

            try
            {
                var houses = _houseBLL.GetModels(h => h.ProjectID == req.ProjectId && h.HouseEstateID == req.HouseEstateId).ToList();

                ret.Buildings = houses.Select(i => i.Building).Distinct().ToList();
            }
            catch (Exception ex)
            {
                Logger.LogException("获取区域列表时发生异常！", "GetAreaListController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }

            return ret;
        }
    }
}
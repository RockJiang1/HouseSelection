using HouseSelection.Authorize;
using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PublicityRequest;
using HouseSelection.FrontEndAPI.Models.PublicityResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.Publicity
{
    public class GetAreaListController:ApiController
    {
        AreaBLL _areaBLL = new AreaBLL();

        [ApiAuthorize]
        public GetAreaListResultEntity Post(GetAreaListRequestModel req)
        {
            Logger.LogDebug("GetAreaList Request:" + JsonHelper.SerializeObject(req), "GetAreaListController", "Post");
            GetAreaListResultEntity ret = new GetAreaListResultEntity()
            {
                code = 0,
                errMsg = "",
                AreaList = new List<AreaEntity>()
            };
            try
            {
                bool cityNameIsEmtpy = string.IsNullOrEmpty(req.CityName);
                var _hs = new List<Area>();

                if (cityNameIsEmtpy)
                {
                    _hs = _areaBLL.GetModels(a => a.ID > 0).ToList();
                }
                else
                {
                    _hs = _areaBLL.GetModels(a => a.CityName == req.CityName).ToList();
                }
                
                if(_hs!=null && _hs.Count>0)
                {
                    _hs.ForEach(a =>
                    {
                        var areaInfo = new AreaEntity();
                        areaInfo.ID = a.ID;
                        areaInfo.Name = a.Name;
                        areaInfo.CityName = a.CityName;
                        ret.AreaList.Add(areaInfo);
                    });
                }
                
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
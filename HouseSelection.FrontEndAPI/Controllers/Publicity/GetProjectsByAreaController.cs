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
    public class GetProjectsByAreaController:ApiController
    {
        ProjectBLL _projectBLL = new ProjectBLL();
        AreaBLL _areaBLL = new AreaBLL();
        
        public GetProjectsByAreaResultEntity Post(GetProjectsByAreaRequestModel req)
        {
            Logger.LogDebug("GetProjectsByArea Request:" + JsonHelper.SerializeObject(req), "GetProjectsByAreaController", "Post");
            GetProjectsByAreaResultEntity ret = new GetProjectsByAreaResultEntity
            {
                code = 0,
                errMsg = "",
                Projects = new List<ProjectEntity>()
            };

            try
            {
                var _projects = new List<Project>();

                if (req.AreaId > 0)
                {
                    _projects = _projectBLL.GetModels(p => p.AreaID == req.AreaId).ToList();
                }
                else
                {
                    _projects = _projectBLL.GetModels(p => p.ID > 0).ToList();
                }

                if (_projects == null || _projects.Count == 0)
                {
                    ret.code = 405;
                    ret.errMsg = "没有查询到对应的项目信息。";
                }
                else
                {
                    var areaIds = _projects.Select(p => p.AreaID).Distinct().ToList();
                    var areaDic = new Dictionary<int, string>();
                    areaIds.ForEach(i =>
                    {
                        var areaInfo = _areaBLL.GetModels(a => a.ID == i).FirstOrDefault();
                        if (areaInfo == null)
                        {
                            Logger.LogWarning(string.Format("无法查询到ID为{0}的地区区域信息！请确认数据是否正确！", i), "FetProjectsByAreaController", "Post");
                        }
                        else
                        {
                            areaDic.Add(i, areaInfo.Name);
                        }
                    });

                    _projects.ForEach(p =>
                    {
                        var areaName = string.Empty;
                        areaDic.TryGetValue(p.AreaID, out areaName);

                        var project = new ProjectEntity
                        {
                            ID = p.ID,
                            Address = p.Address,
                            Name = p.Name,
                            Number = p.Number,
                            ProjectArea = areaName
                        };

                        ret.Projects.Add(project);
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取项目列表时发生异常！", "GetProjectsByAreaController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}
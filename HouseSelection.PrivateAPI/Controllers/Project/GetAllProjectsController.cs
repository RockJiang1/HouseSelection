using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetAllProjectsController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();

        [ApiAuthorize]
        public ProjectListResultEntity Post(BaseRequestModel baseRequest)
        {
            Logger.LogDebug("GetAllProjects Request:" + JsonHelper.SerializeObject(baseRequest), "GetAllProjectsController", "Post");
            ProjectListResultEntity ret = new ProjectListResultEntity();
            try
            {
                var lstProject = _projectBLL.GetModelsByPage(baseRequest.PageSize, baseRequest.PageIndex, true, p => p.ID, x => 1 == 1).ToList();
                ret.ProjectList = new List<ProjectEntity>();
                foreach (var p in lstProject)
                {
                    ProjectEntity retP = new ProjectEntity()
                    {
                        ID = p.ID,
                        Number = p.Number,
                        Name = p.Name,
                        Address = p.Address,
                        ProjectArea = p.Area.Name,
                        DevelopCompany = p.DevelopCompany,
                        IdentityNumber = p.IdentityNumber,
                        IsEnd = p.IsEnd,
                        EndReason = p.EndReason
                    };
                    ret.ProjectList.Add(retP);
                }
                ret.Code = 0;
                ret.ErrMsg = "";
                ret.RecordCount = _projectBLL.GetModels(x => 1 == 1).Count();
            }
            catch (Exception ex)
            {
                Logger.LogException("获取项目列表发生异常！", "", "", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
                ret.ProjectList = null;
            }
            return ret;
        }
    }
}

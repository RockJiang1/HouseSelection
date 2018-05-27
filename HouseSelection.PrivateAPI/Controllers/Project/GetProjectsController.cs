using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.LoggerHelper;
using HouseSelection.PrivateAPI.Models;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetProjectsController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        public ProjectListResultEntity Post(SearchRequestModel Search)
        {
            ProjectListResultEntity ret = new ProjectListResultEntity();
            try
            {
                var lstProject = _projectBLL.GetModelsByPage(Search.PageSize, Search.PageIndex, true, x => x.ID, x => x.Number.Contains(Search.SearchStr) || x.Name.Contains(Search.SearchStr)).ToList();
                //List<Project> tmp1 = new List<Project>();
                //List<Project> tmp2 = new List<Project>();
                //if (!string.IsNullOrWhiteSpace(Search.SearchStr))
                //{
                //    tmp1 = lstProject.Where(x => x.Number.Contains(Search.SearchStr)).ToList();
                //    tmp2 = lstProject.Where(x => x.Name.Contains(Search.SearchStr)).ToList();
                //}
                ret.ProjectList = new List<ProjectEntity>();
                foreach (var p in lstProject)
                {
                    ProjectEntity retP = new ProjectEntity()
                    {
                        ID = p.ID,
                        Number = p.Number,
                        Name = p.Name,
                        Address = p.Address,
                        ProjectArea = p.Area.Name
                    };
                    ret.ProjectList.Add(retP);
                }
                ret.code = 0;
                ret.errMsg = "";
                ret.recordCount = _projectBLL.GetModels(x => x.Number.Contains(Search.SearchStr) || x.Name.Contains(Search.SearchStr)).Count();
            }
            catch (Exception ex)
            {
                Logger.LogException("获取项目列表发生异常！", "", "", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
                ret.ProjectList = null;
            }
            return ret;
        }
    }
}

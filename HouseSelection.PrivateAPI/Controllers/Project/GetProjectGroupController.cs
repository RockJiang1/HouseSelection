﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetProjectGroupController : ApiController
    {
        ProjectBLL _projectBLL = new ProjectBLL();
        ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();

        [ApiAuthorize]
        public GetProjectGroupResultEntity Post(GetProjectGroupRequestModel req)
        {
            Logger.LogDebug("GetProjectGroup Request:" + JsonHelper.SerializeObject(req), "GetProjectGroupController", "Post");
            GetProjectGroupResultEntity ret = new GetProjectGroupResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbProGrpList = new List<ProjectGroup>();
                if (req.ProjectID == 0)//获取所有
                {
                    _dbProGrpList = _projectGroupBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => 1 == 1).ToList();
                    ret.RecordCount = _projectGroupBLL.GetModels(x => 1 == 1).Count();
                }
                else
                {
                    if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                    {
                        ret.Code = 201;
                        ret.ErrMsg = "项目ID不存在！";
                    }
                    else
                    {
                        _dbProGrpList = _projectGroupBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID).ToList();
                        ret.RecordCount = _projectGroupBLL.GetModels(x => x.ProjectID == req.ProjectID).Count();
                    }
                }
                var _proGrpList = new List<ProjectGroupEntity>();
                foreach (var proGrp in _dbProGrpList)
                {
                    var grp = new ProjectGroupEntity()
                    {
                        ProjectID = proGrp.Project.ID,
                        ProjectNumber = proGrp.Project.Number,
                        ProjectName = proGrp.Project.Name,
                        ProjectGroupID = proGrp.ID,
                        ProjectGroupName = proGrp.ProjectGroupName
                    };
                    _proGrpList.Add(grp);
                }
                ret.ProjectGroupList = _proGrpList;
            }
            catch(Exception ex)
            {
                Logger.LogException("获取项目分组时发生异常！", "GetProjectGroupController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

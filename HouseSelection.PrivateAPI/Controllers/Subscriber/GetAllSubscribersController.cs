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
    public class GetAllSubscribersController : ApiController
    {
        //ProjectBLL _projectBLL = new ProjectBLL();
        HouseSelectionRecordBLL _selectionBLL = new HouseSelectionRecordBLL();
        //SubscriberProjectMappingBLL _subscriberBLL = new SubscriberProjectMappingBLL();
        SubscriberBLL _subscriberBLL = new SubscriberBLL();

        [ApiAuthorize]
        public GetSubscriberResultEntity Post(GetSubscriberRequestModel req)
        {
            Logger.LogDebug("GetAllSubscribers Request:" + JsonHelper.SerializeObject(req), "GetAllSubscribersController", "Post");
            var ret = new GetSubscriberResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };
            try
            {
                //if(_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                //{
                //    ret.code = 201;
                //    ret.ErrMsg = "项目ID不存在！";
                //}
                //else
                //{
                //var _dbSubList = _subscriberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID).ToList();
                var _dbSubList = _subscriberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => 1 == 1).ToList();
                var _subList = new List<SubscriberEntity>();
                    foreach(var _dbSub in _dbSubList)
                    {
                        var _sub = new SubscriberEntity()
                        {
                            ID = _dbSub.ID,
                            Name = _dbSub.Name,
                            IdentityNumber = _dbSub.IdentityNumber,
                            Telephone = _dbSub.Telephone,
                            Address = _dbSub.Address,
                            ZipCode = _dbSub.ZipCode,
                            MaritalStatus = _dbSub.MaritalStatus,
                            ResidenceArea = _dbSub.ResidenceArea,
                            WorkArea = _dbSub.WorkArea,
                        };
                        _subList.Add(_sub);
                    }
                    ret.SubscriberList = _subList;
                    ret.RecordCount = _subscriberBLL.GetModels(x => 1 == 1).Count();
                //}
                
            }
            catch(Exception ex)
            {
                Logger.LogException("获取认购人时发生异常", "GetSubscribersController", "Post", ex);
            }
            return ret;
        }
    }
}

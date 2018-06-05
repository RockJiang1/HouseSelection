using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 导入认购人和摇号信息
    /// </summary>
    public class ImportSubscriberController : ApiController
    {
        ProjectBLL _projectBLL = new ProjectBLL();
        ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        SubscriberBLL _subscriberBLL = new SubscriberBLL();
        SubscriberFamilyMemberBLL _subscriberFamilyBLL = new SubscriberFamilyMemberBLL();
        SubscriberProjectMappingBLL _subscriberProjectMapBLL = new SubscriberProjectMappingBLL();
        ShakingNumberResultBLL _shakingNumberBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(ImportSubscriberRequestEntity req)
        {
            Logger.LogDebug("ImportSubscriber Request:" + JsonHelper.SerializeObject(req), "ImportSubscriberController", "Post");
            BaseResultEntity ret = new BaseResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                #region 请求数据校验
                var _pro = _projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault();
                if (_pro == null)
                {
                    ret.code = 401;
                    ret.errMsg = "项目ID不存在！";
                    return ret;
                }
                else if(req.ProjectGroup == null)
                {
                    ret.code = 402;
                    ret.errMsg = "项目分组不能为空！";
                    return ret;
                }
                foreach(var shake in req.ShakingNumberList)
                {
                    if (shake.ShakingNumber == null)
                    {
                        ret.code = 403;
                        ret.errMsg = "摇号编号不能为空！";
                        return ret;
                    }
                    if (shake.Subscriber == null)
                    {
                        ret.code = 404;
                        ret.errMsg = "摇号编号为" + shake.ShakingNumber + "的认购人信息不能为空！";
                        return ret;
                    }
                    if (shake.ShakingNumberSequance <= 0)
                    {
                        ret.code = 405;
                        ret.errMsg = "摇号编号为" + shake.ShakingNumber + "摇号序号不能为空或小于1！";
                        return ret;
                    }
                    if (shake.SelectHouseSequance <= 0)
                    {
                        ret.code = 405;
                        ret.errMsg = "摇号编号为" + shake.ShakingNumber + "选房序号不能为空或小于1！";
                        return ret;
                    }
                    if (shake.Subscriber.Name == null || shake.Subscriber.IdentityNumber == null || shake.Subscriber.Telephone == null || shake.Subscriber.Address == null || shake.Subscriber.MaritalStatus == null || shake.Subscriber.ZipCode == null || shake.Subscriber.ResidenceArea == null || shake.Subscriber.WorkArea == null)
                    {
                        ret.code = 406;
                        ret.errMsg = "摇号编号为" + shake.ShakingNumber + "认购人信息不完整！";
                        return ret;
                    }
                }
                #endregion

                #region 创建项目分组
                int _projectGroupID = 0;
                try
                {
                        
                    if (_projectGroupBLL.GetModels(x => x.ProjectID == req.ProjectID && x.ProjectGroupName == req.ProjectGroup).FirstOrDefault() == null) //项目分组不存在
                    {
                        var _progrp = new ProjectGroup()
                        {
                            ProjectID = req.ProjectID,
                            ProjectGroupName = req.ProjectGroup,
                            CreateTime = DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        _projectGroupBLL.Add(_progrp);
                    }
                    _projectGroupID = _projectGroupBLL.GetModels(x => x.ProjectID == req.ProjectID && x.ProjectGroupName == req.ProjectGroup).FirstOrDefault().ID;
                }
                catch(Exception ex)
                {
                    Logger.LogException("创建项目分组时发生异常！", "ImportSubscriberController", "Post", ex);
                    ret.code = 999;
                    ret.errMsg = ex.Message;
                    return ret;
                }
                #endregion

                var _subList = new List<Subscriber>();
                var _existSubList = new List<Subscriber>();
                var _familyList = new List<SubscriberFamilyMemberEntity>();
                var _shakeList = new List<ShakingNumberResult>();
                #region 创建认购人
                foreach (var shake in req.ShakingNumberList)
                {
                    try
                    {
                        var _sub = _subscriberBLL.GetModels(x => x.IdentityNumber == shake.Subscriber.IdentityNumber).FirstOrDefault();
                        if (_sub == null)  //认购人不存在
                        {
                            var _subscriber = new Subscriber()
                            {
                                Name = shake.Subscriber.Name,
                                IdentityNumber = shake.Subscriber.IdentityNumber,
                                Telephone = shake.Subscriber.Telephone,
                                Address = shake.Subscriber.Address,
                                ZipCode = shake.Subscriber.ZipCode,
                                MaritalStatus = shake.Subscriber.MaritalStatus,
                                ResidenceArea = shake.Subscriber.ResidenceArea,
                                WorkArea = shake.Subscriber.WorkArea,
                                FamilyMemberNumber = shake.FamilyMemberList == null ? 0 : shake.FamilyMemberList.Count(),
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now
                            };
                            _subList.Add(_subscriber);

                            if (shake.FamilyMemberList != null && shake.FamilyMemberList.Count() > 0)
                            {
                                _familyList.AddRange(shake.FamilyMemberList);
                            }
                        }
                        else
                        {
                            _existSubList.Add(_sub);
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.LogException("创建摇号编号为" + shake.ShakingNumber + "的认购人时发生异常！", "ImportSubscriberController", "Post", ex);
                        ret.code = 999;
                        ret.errMsg = ex.Message;
                        return ret;
                    }
                }
                _subscriberBLL.AddRange(_subList);
                #endregion

                #region 创建认购人家庭成员
                var _ttlSubList = _subscriberBLL.GetModels(x => 1 == 1).ToList();
                var _dbFamilyList = new List<SubscriberFamilyMember>();
                foreach (var family in _familyList)
                {
                    try
                    {
                        var _sub = _ttlSubList.FirstOrDefault(x => x.IdentityNumber == family.SubscriberIdentityNumber);
                        if (_sub != null)
                        {
                            var _fam = new SubscriberFamilyMember()
                            {
                                SubscriberID = _sub.ID,
                                Name = family.Name,
                                IdentityNumber = family.IdentityNumber,
                                Relationship = family.Relationship,
                                Area = family.Area,
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now
                            };
                            _dbFamilyList.Add(_fam);
                        }
                    }
                    catch(Exception ex)
                    {
                        _subscriberBLL.DeleteRange(_subList);  //回滚新建认购人
                        Logger.LogException("创建身份证为" + family.IdentityNumber + "的认购人家庭成员时发生异常！", "ImportSubscriberController", "Post", ex);
                        ret.code = 999;
                        ret.errMsg = ex.Message;
                        return ret;
                    }
                }
                _subscriberFamilyBLL.AddRange(_dbFamilyList);
                #endregion

                #region 创建认购人项目关联关系
                var _subProMapList = new List<SubscriberProjectMapping>();
                foreach( var sub in _subList)//添加新认购人Mapping
                {
                    var _subProMap = new SubscriberProjectMapping()
                    {
                        SubscriberID = sub.ID,
                        ProjectID = req.ProjectID,
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _subProMapList.Add(_subProMap);
                }
                foreach(var sub in _existSubList)//添加已存在认购人Mapping
                {
                    var _subProMap = new SubscriberProjectMapping()
                    {
                        SubscriberID = sub.ID,
                        ProjectID = req.ProjectID,
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _subProMapList.Add(_subProMap);
                }
                _subProMapList.OrderBy(x => x.SubscriberID);
                _subscriberProjectMapBLL.AddRange(_subProMapList);
                #endregion

                #region 创建摇号结果
                var _dbSubProMap = _subscriberProjectMapBLL.GetModels(x => 1 == 1).ToList();
                var _dbshakingNumberList = new List<ShakingNumberResult>();
                foreach (var shake in req.ShakingNumberList)
                {
                    try
                    {
                        var _subProMap = _dbSubProMap.FirstOrDefault(x => x.ProjectID == req.ProjectID && x.Subscriber.IdentityNumber == shake.Subscriber.IdentityNumber);
                        if (_subProMap != null && _projectGroupID != 0)
                        {
                            var _shake = new ShakingNumberResult()
                            {
                                ProjectGroupID = _projectGroupID,
                                SubscriberProjectMappingID = _subProMap.ID,
                                ShakingNumberSequance = shake.ShakingNumberSequance,
                                SelectHouseSequance = shake.SelectHouseSequance,
                                ShakingNumber = shake.ShakingNumber,
                                NoticeTime = 0,
                                IsError = false,
                                IsContacted = false,
                                IsCallBack = false,
                                IsMessageSend = false,
                                CreateTime = DateTime.Now,
                                LastUpdate = DateTime.Now
                            };
                            _dbshakingNumberList.Add(_shake);
                        }
                    }
                    catch(Exception ex)
                    {
                        _subscriberProjectMapBLL.DeleteRange(_subProMapList);  //回滚新建认购人项目关联
                        Logger.LogException("创建摇号编号为" + shake.ShakingNumber + "的摇号结果时发生异常！", "ImportSubscriberController", "Post", ex);
                        ret.code = 999;
                        ret.errMsg = ex.Message;
                        return ret;
                    }
                }
                _shakingNumberBLL.AddRange(_dbshakingNumberList);
                #endregion
            }
            catch(Exception ex)
            {
                Logger.LogException("导入认购人和摇号信息时发生异常！", "ImportSubscriberController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}

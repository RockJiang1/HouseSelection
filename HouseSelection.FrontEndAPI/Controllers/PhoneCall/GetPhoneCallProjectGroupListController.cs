using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.FrontEndAPI.Models.PhoneCallResult;
using HouseSelection.LoggerHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    public class GetPhoneCallProjectGroupListController:ApiController//todo finished
    {

        ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();

        public GetPhoneCallProjectGroupListResultEntity Post(GetPhoneCallProjectGroupListRequestModel req)
        {
            bool isWarn = false;
            var ret = new GetPhoneCallProjectGroupListResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty,
                ProjectGroupList = new List<PhoneCallProjectGroupInfo>()
            };

            try
            {
                var groups = _projectGroupBLL.GetModels(i => i.ProjectID == req.ProjectId).ToList();
                groups.ForEach(i =>
                {
                    var shakingNumberResult = _shakingNumberResultBLL.GetModels(s => s.ProjectGroupID == i.ID).OrderBy(s => s.ShakingNumberSequance).ToList();
                    if (shakingNumberResult == null || shakingNumberResult.Count == 0)
                    {
                        Logger.LogWarning(string.Format("项目{0}中，组{1}没有摇号结果，跳过处理",req.ProjectId,i.ID), "GetPhoneCallProjectGroupListController", "in loop");
                        isWarn = true;
                    }
                    else
                    {
                        int endNumber = shakingNumberResult.Max(s => s.ShakingNumberSequance);
                        int beginNumber = shakingNumberResult.Min(s => s.ShakingNumberSequance);
                        
                        PhoneCallProjectGroupInfo groupInfo = new PhoneCallProjectGroupInfo()
                        {
                            GroupId = i.ID,
                            GroupName = i.ProjectGroupName,
                            BeginNumber = beginNumber,
                            EndNumber = endNumber
                        };

                        ret.ProjectGroupList.Add(groupInfo);
                    }
                });
            }
            catch (Exception ex)
            {
                Logger.LogException("电话app获取项目组列表时发生异常！", "GetPhoneCallProjectGroupListController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            if (isWarn)
            {
                ret.ErrMsg = "警告：处理中，有项目不存在shakeresult！";
            }
            return ret;
        }

    }
}
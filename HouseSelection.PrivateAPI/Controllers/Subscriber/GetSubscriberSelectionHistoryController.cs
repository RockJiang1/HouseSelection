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
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 获取认购人认购历史
    /// </summary>
    public class GetSubscriberSelectionHistoryController : ApiController
    {
        public SubscriberBLL _subscriberBLL = new SubscriberBLL();
        public SubscriberProjectMappingBLL _subscriberProjectMapBLL = new SubscriberProjectMappingBLL();
        public ShakingNumberResultBLL _shakingNumberBLL = new ShakingNumberResultBLL();
        public HouseSelectionRecordBLL _selectionBLL = new HouseSelectionRecordBLL();
        public TelephoneNoticeRecordBLL _noticeBLL = new TelephoneNoticeRecordBLL();

        [ApiAuthorize]
        public GetSubscriberSelectionHistoryResultEntity Post(GetSubscriberSelectionHistoryRequestModel req)
        {
            Logger.LogDebug("GetSubscriberSelectionHistory Request:" + JsonHelper.SerializeObject(req), "GetSubscriberSelectionHistoryController", "Post");
            var ret = new GetSubscriberSelectionHistoryResultEntity()
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
                if(_subscriberBLL.GetModels(x => x.ID == req.SubscriberID).FirstOrDefault() == null)
                {
                    ret.Code = 202;
                    ret.ErrMsg = "认购人ID不存在！";
                }
                else
                {
                    var _proList = _subscriberProjectMapBLL.GetModels(x => x.SubscriberID == req.SubscriberID).ToList();
                    var _selectionList = _selectionBLL.GetModels(x => x.SubscriberID == req.SubscriberID).ToList();
                    var _noticeList = _noticeBLL.GetModels(x => x.ShakingNumberResult.SubscriberProjectMapping.SubscriberID == req.SubscriberID).ToList();

                    var _historyList = new List<SubscriberSelectionEntity>();
                    foreach(var pro in _proList)
                    {
                        var _shakingNumber = _shakingNumberBLL.GetModels(x => x.SubscriberProjectMappingID == pro.ID).FirstOrDefault();
                        var _notice = _noticeList.FirstOrDefault(x => x.ShakingNumberResult.SubscriberProjectMappingID == pro.ID);
                        var _selection = _selectionList.FirstOrDefault(x => x.SubscriberID == pro.SubscriberID && x.ProjectID == pro.ProjectID);

                        var _history = new SubscriberSelectionEntity()
                        {
                            ProjectID = pro.ProjectID,
                            ProjectNumber = pro.Project.Number,
                            ProjectName = pro.Project.Name,
                            NoticeStatus = _notice != null ? _notice.ResultType : 0,
                            AuthStatus = _shakingNumber == null ? 0 : (_shakingNumber.IsAuthorized ? 1 : 0),
                            SelectionStatus = _selection != null ? 1 : 0,
                            ConfirmStatus = _selection != null ? (_selection.IsConfirm ? 1 : 0) : 0,
                            ShakingResultID = _shakingNumber == null ? 0 : _shakingNumber.ID
                        };
                        _historyList.Add(_history);
                    }
                    ret.SelectionList = _historyList;
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("获取认购人认购历史时发生异常！", "GetSubscriberSelectionHistoryController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}

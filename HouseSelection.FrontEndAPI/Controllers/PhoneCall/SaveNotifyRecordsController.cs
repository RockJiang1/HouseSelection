using HouseSelection.BLL;
using HouseSelection.Enum;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.FrontEndAPI.Models.PhoneCallResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    
    public class SaveNotifyRecordsController:ApiController
    {
        TelephoneNoticeRecordBLL _telephoneNoticeRecordBLL = new TelephoneNoticeRecordBLL();
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();
        HouseSelectPeriodBLL _selectPeriodBLL = new HouseSelectPeriodBLL();

        [Authorize]
        public SaveNotifyRecordsResultEntity Post(SaveNotifyRecordsRequestModel req)
        {
            var ret = new SaveNotifyRecordsResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty
            };

            try
            {
                // 1.新增通话记录
                var record = new TelephoneNoticeRecord()
                {
                    ShakingNumberResultID = req.ShakeNumberResultId,
                    CreateTime = DateTime.Now,
                    FrontEndAccountID = req.FrontAccountId,
                    NoticeTelephone = req.NoticePhone,
                    NoticeTime = DateTime.Now,
                    ResultType = req.ResultType,
                    LastUpdate = DateTime.Now
                };
                _telephoneNoticeRecordBLL.Add(record);
                // 2.更新shakingNumberResult记录
                var snr = _shakingNumberResultBLL.GetModels(i => i.ID == req.ShakeNumberResultId).First();
                if (req.ResultType == (int)PhoneCallReasonType.Valid)
                {
                    snr.IsContacted = true;
                }
                if (req.ResultType == (int)PhoneCallReasonType.NotOneself)
                {
                    snr.IsError = true;
                }
                snr.LastUpdate = DateTime.Now;
                snr.NoticeTime = snr.NoticeTime + 1;
                _shakingNumberResultBLL.Update(snr);

                snr = _shakingNumberResultBLL.GetModels(i => i.ID == req.ShakeNumberResultId).First();
                var _period = _selectPeriodBLL.GetModels(x => x.ShakingNumberResultID == req.ShakeNumberResultId).FirstOrDefault();
                DateTime? dt = null;

                ret.DialedInfo = new DialedInfo()
                {
                    ShakingNumberResultId = snr.ID,
                    ShakingNumberSequance = snr.ShakingNumberSequance,
                    SelectHouseSequence = snr.SelectHouseSequance,
                    Name = snr.SubscriberProjectMapping.Subscriber.Name,
                    IdentityID = snr.SubscriberProjectMapping.Subscriber.IdentityNumber,
                    BeginTime = _period == null ? null : _period.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    EndTime = _period == null ? null : _period.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    CallTimes = snr.NoticeTime,
                    IsContacted = snr.IsContacted,
                    IsCallBack = snr.IsCallBack,
                    IsMessageSend = snr.IsMessageSend,
                    ResultType = (snr.TelephoneNoticeRecord.FirstOrDefault()) == null ? 0 : snr.TelephoneNoticeRecord.OrderByDescending(x => x.ID).FirstOrDefault().ResultType,
                    LastCallTime = snr.NoticeTime == 0 ? null : snr.LastUpdate == null ? null : ((DateTime)snr.LastUpdate).ToString("yyyy-MM-dd HH:mm:ss"),
                    Phone = snr.SubscriberProjectMapping.Subscriber.Telephone
                };
            }
            catch (Exception ex)
            {

                Logger.LogException("保存通知记录时发生异常！", "SaveNotifyRecordsController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }
    }
}
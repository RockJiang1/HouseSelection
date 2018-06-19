using HouseSelection.BLL;
using HouseSelection.Enum;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
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

        //[Authorize]
        public BaseResultEntity Post(SaveNotifyRecordsRequestModel req)
        {
            var ret = new BaseResultEntity()
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
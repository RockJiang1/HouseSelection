﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.DAL
{
    public class ShakingNumberResultDAL : BaseDAL<ShakingNumberResult>
    {
        public List<DialedInfo> GetSubscriberDialingStatus(int GroupID, int StartSeq, int EndSeq)
        {
            using(HouseSelectionDBEntities DB = new HouseSelectionDBEntities())
            {
                DateTime? dt = null;
                return (from Temp in ((from SN in DB.ShakingNumberResult
                           join M in DB.SubscriberProjectMapping on SN.SubscriberProjectMappingID equals M.ID
                           join S in DB.Subscriber on M.SubscriberID equals S.ID
                           join Htmp in DB.HouseSelectPeriod on SN.ID equals Htmp.ShakingNumberResultID into temp
                           from H in temp.DefaultIfEmpty()
                           where SN.ProjectGroupID == GroupID
                           && SN.SelectHouseSequance >= StartSeq
                           && SN.SelectHouseSequance <= EndSeq
                           select new
                           {
                               ShakingNumberResultId = SN.ID,
                               ShakingNumberSequance = SN.ShakingNumberSequance,
                               SelectHouseSequence = SN.SelectHouseSequance,
                               Name = S.Name,
                               IdentityID = S.IdentityNumber,
                               //BeginTime = H == null ? null : H.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                               BeginTime = H == null ? dt : H.StartTime,
                               //EndTime = H == null ? null : H.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                               EndTime = H == null ? dt : H.EndTime,
                               CallTimes = SN.NoticeTime,
                               IsContacted = SN.IsContacted,
                               IsCallBack = SN.IsCallBack,
                               IsMessageSend = SN.IsMessageSend,
                               ResultType = (SN.TelephoneNoticeRecord.FirstOrDefault()) == null ? 0 : SN.TelephoneNoticeRecord.OrderByDescending(x => x.ID).FirstOrDefault().ResultType,
                               //LastCallTime = (SN.LastUpdate ?? SN.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                               LastCallTime = SN.NoticeTime == 0 ? null : SN.LastUpdate,
                               Phone = S.Telephone
                           }).ToList())
                           select new DialedInfo
                           {
                               ShakingNumberResultId = Temp.ShakingNumberResultId,
                               ShakingNumberSequance = Temp.ShakingNumberSequance,
                               SelectHouseSequence = Temp.SelectHouseSequence,
                               Name = Temp.Name,
                               IdentityID = Temp.IdentityID,
                               BeginTime = Temp.BeginTime == null ? null : ((DateTime)Temp.BeginTime).ToString("yyyy-MM-dd HH:mm:ss"),
                               EndTime = Temp.EndTime == null ? null : ((DateTime)Temp.EndTime).ToString("yyyy-MM-dd HH:mm:ss"),
                               CallTimes = Temp.CallTimes,
                               IsContacted = Temp.IsContacted,
                               IsCallBack = Temp.IsCallBack,
                               IsMessageSend = Temp.IsMessageSend,
                               ResultType = Temp.ResultType,
                               LastCallTime = Temp.LastCallTime == null ? null : ((DateTime)Temp.LastCallTime).ToString("yyyy-MM-dd HH:mm:ss"),
                               Phone = Temp.Phone
                           }).ToList();

            }
        }
    }
}

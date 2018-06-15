using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.DAL
{
    public class HouseSelectionRecordDAL : BaseDAL<HouseSelectionRecord>
    {
        public List<SubscriberSelectionEntity> GetSubscriberSelectionRecord(int SubscriberID)
        {
            using (var DB = new HouseSelectionDBEntities())
            {
                return (from S in DB.ShakingNumberResult
                            join m in DB.SubscriberProjectMapping on S.SubscriberProjectMappingID equals m.ID
                            join h in DB.HouseSelectionRecord on m.SubscriberID equals h.SubscriberID into temp from t in temp.DefaultIfEmpty()
                            where S.SubscriberProjectMapping.SubscriberID == SubscriberID
                            select new SubscriberSelectionEntity
                            {
                                ProjectID = S.ProjectGroup.Project.ID,
                                ProjectNumber = S.ProjectGroup.Project.Number,
                                ProjectName = S.ProjectGroup.Project.Name,
                                NoticeStatus = S.IsContacted ? 1 : (S.TelephoneNoticeRecord.OrderBy(x => x.ID).FirstOrDefault(x => x.ShakingNumberResultID == S.ID) == null ? 0 : S.TelephoneNoticeRecord.OrderBy(x => x.ID).FirstOrDefault(x => x.ShakingNumberResultID == S.ID).ResultType),
                                AuthStatus = S.IsAuthorized ? 1 : 0,
                                SelectionStatus = t == null ? 0 : 1,
                                ConfirmStatus = t == null ? 0 : (t.IsConfirm ? 1 : 0),
                                AbandonStatus = t == null ? 0 : (t.IsAbandon ? 1 : 0),
                                ShakingResultID = S.ID,
                                //HouseSelectionID = t.ID
                            }).ToList();
            }
        }
    }
}

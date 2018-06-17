using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetSelectionDetailResponse : BaseResultEntity
    {
        public GetSelectionDetailResponse()
        {
            this.House = new HouseEntityTemp();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public HouseEntityTemp House { get; set; }
        public DateTime SelectTime { get; set; }
        public string SelectImageUrl1 { get; set; }
        public string SelectImageUrl2 { get; set; }
        public string SelectImageUrl3 { get; set; }
        public bool IsAbandon { get; set; }
        public DateTime? AbandonTime { get; set; }
        public string AbandonImageUrl1 { get; set; }
        public string AbandonImageUrl2 { get; set; }
        public string AbandonImageUrl3 { get; set; }
        //public int RecordCount { get; set; }
    }

}





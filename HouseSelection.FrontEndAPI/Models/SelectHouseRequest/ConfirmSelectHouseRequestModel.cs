using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseRequest
{
    public class ConfirmSelectHouseRequestModel
    {
        public int ShakingNumberResultId { get; set; }
        public int HouseId { get; set; }
    }
}
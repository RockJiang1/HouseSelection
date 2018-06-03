using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetProjectsByAreaResultEntity:BaseResultEntity
    {
        public List<ProjectEntity> Projects { get; set; }
        
    }
}
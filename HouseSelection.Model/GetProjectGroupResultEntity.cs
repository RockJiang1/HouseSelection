using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetProjectGroupResultEntity : BaseResultEntity
    {
        public List<ProjectGroupEntity> ProjectGroupList { get; set; }
    }
}

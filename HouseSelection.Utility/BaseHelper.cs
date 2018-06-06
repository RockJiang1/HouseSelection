using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Utility
{
    public class BaseHelper
    {
        public List<AreaEntity> GetAreaList()
        {
            List<AreaEntity> result = new List<AreaEntity>();
            result.Add(new AreaEntity() { ID = 1, Name = "东城区", CityName=""});
            result.Add(new AreaEntity() { ID = 2, Name = "西城区", CityName = "" });
            result.Add(new AreaEntity() { ID = 3, Name = "朝阳区", CityName = "" });
            result.Add(new AreaEntity() { ID = 4, Name = "海淀区", CityName = "" });
            result.Add(new AreaEntity() { ID = 5, Name = "丰台区", CityName = "" });
            result.Add(new AreaEntity() { ID = 6, Name = "石景山区", CityName = "" });
            result.Add(new AreaEntity() { ID = 7, Name = "顺义区", CityName = "" });
            result.Add(new AreaEntity() { ID = 8, Name = "通州区", CityName = "" });
            result.Add(new AreaEntity() { ID = 9, Name = "大兴区", CityName = "" });
            result.Add(new AreaEntity() { ID = 10, Name = "房山区", CityName = "" });
            result.Add(new AreaEntity() { ID = 11, Name = "门头沟区", CityName = "" });
            result.Add(new AreaEntity() { ID = 12, Name = "昌平区", CityName = "" });
            result.Add(new AreaEntity() { ID = 13, Name = "平谷区", CityName = "" });
            result.Add(new AreaEntity() { ID = 14, Name = "密云区", CityName = "" });
            result.Add(new AreaEntity() { ID = 15, Name = "怀柔区", CityName = "" });
            result.Add(new AreaEntity() { ID = 16, Name = "延庆区", CityName = "" });

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Utility
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            FieldInfo item = type.GetField(value.ToString(), BindingFlags.Public | BindingFlags.Static);
            if (item == null) return null;
            var attribute = Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute != null && !string.IsNullOrEmpty(attribute.Description)) return attribute.Description;
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace HouseSelection.Utility
{
    public static class XMLHelper
    {
        public static string SerializeObject(object o)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(o.GetType());
                xz.Serialize(sw, o);
                return sw.ToString();
            }
        }

        public static T DeserializeXMLToObject<T>(string XML) where T : class
        {
            using (StringReader sr = new StringReader(XML))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                return (T)xz.Deserialize(sr);
            }
        }
    }
}

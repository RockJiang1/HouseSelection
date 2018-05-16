using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace HouseSelection.Utility
{
    public static class TableAndObjectConvertHelper<T> where T : new()
    {
        /// <summary>
        /// 数据库行转为实体
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>实体</returns>
        public static T ToEntity(DataRow dr)
        {
            T entity = new T();
            Type info = typeof(T);
            var members = info.GetMembers();
            foreach (var mi in members)
            {
                if (mi.MemberType == MemberTypes.Property)
                {

                    object[] attributes = mi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    foreach (var attr in attributes)
                    {
                        var dataFieldAttr = attr as DataFieldAttribute;
                        if (dataFieldAttr != null)
                        {
                            var propInfo = info.GetProperty(mi.Name);
                            if (dr.Table.Columns.Contains(dataFieldAttr.ColumnName))
                            {
                                if (dr[dataFieldAttr.ColumnName] != DBNull.Value)
                                {
                                    //propInfo.SetValue(entity, Convert.ChangeType(dr[dataFieldAttr.ColumnName], propInfo.PropertyType), null);
                                    propInfo.SetValue(entity, ConvertHelper.ChanageType(dr[dataFieldAttr.ColumnName], propInfo.PropertyType), null);
                                }
                            }

                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 数据库表转为List
        /// </summary>
        /// <param name="dt">数据库表</param>
        /// <returns>List</returns>
        public static List<T> ToList(DataTable dt)
        {
            List<T> list = new List<T>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToEntity(dr));
            }
            return list;
        }

        /// <summary>
        /// List转换为数据库表
        /// </summary>
        /// <param name="list">List</param>
        /// <returns>数据库表</returns>
        public static DataTable ToTable(List<T> list)
        {
            DataTable result = new DataTable();

            PropertyInfo[] propertys = (new T()).GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                /*modify by shinwa */
                /*  result.Columns.Add(pi.Name, pi.PropertyType);*/

                Type colType = pi.PropertyType;
                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                {
                    colType = colType.GetGenericArguments()[0];
                }

                result.Columns.Add(pi.Name, colType);
            }

            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo pi in propertys)
                {
                    object obj = pi.GetValue(list[i], null);
                    tempList.Add(obj);
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }

            return result;
        }

        /// <summary>
        /// 带特性的List转数据表
        /// </summary>
        /// <param name="list">List</param>
        /// <returns>数据表</returns>
        public static DataTable ToTableWithAttribute(List<T> list)
        {
            DataTable result = new DataTable();
            PropertyInfo[] propertys = (new T()).GetType().GetProperties();

            foreach (PropertyInfo pi in propertys)
            {
                object[] attributes = pi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                if (attributes.Count() > 0 && (attributes[0] as DataFieldAttribute) != null)
                {
                    //result.Columns.Add((attributes[0] as DataFieldAttribute).ColumnName, pi.PropertyType);
                    var colType = pi.PropertyType;
                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }
                    result.Columns.Add((attributes[0] as DataFieldAttribute).ColumnName, colType);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                ArrayList tempList = new ArrayList();
                foreach (PropertyInfo pi in propertys)
                {
                    object[] attributes = pi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    if (attributes.Count() > 0 && (attributes[0] as DataFieldAttribute) != null)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                }
                object[] array = tempList.ToArray();
                result.LoadDataRow(array, true);
            }

            return result;
        }
    }

    public static class ConvertHelper
    {
        public static object ChanageType(this object value, Type convertsionType)
        {
            //判断convertsionType类型是否为泛型，因为nullable是泛型类,
            if (convertsionType.IsGenericType &&
                //判断convertsionType是否为nullable泛型类
                convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }

                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(convertsionType);
                //将convertsionType转换为nullable对的基础基元类型
                convertsionType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, convertsionType);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataFieldAttribute : Attribute
    {
        public string ColumnName { set; get; }

        public DataFieldAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}

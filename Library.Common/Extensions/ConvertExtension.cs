using System;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Library.Common.Extensions
{
    public static class ConvertExtentions
    {
        public static string ToStr(this object obj, string defaultValue = "")
        {
            return obj != null && obj != DBNull.Value ? obj.ToString() : defaultValue;
        }

        public static int ToInt32(this object obj, int defaultValue = default(int))
        {
            int result;
            return int.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static int? ToInt32(this object obj, int? defaultValue)
        {
            int result;
            return int.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static long ToInt64(this object obj, long defaultValue = default(long))
        {
            long result;
            return long.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static long? ToInt64(this object obj, long? defaultValue)
        {
            long result;
            return long.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static double ToDouble(this object obj, double defaultValue = default(double))
        {
            double result;
            return double.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static double? ToDouble(this object obj, double? defaultValue)
        {
            double result;
            return double.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static decimal ToDecimal(this object obj, decimal defaultValue = default(decimal))
        {
            decimal result;
            return decimal.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static decimal? ToDecimal(this object obj, decimal? defaultValue)
        {
            decimal result;
            return decimal.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static bool ToBoolean(this object obj, bool defaultValue = default(bool))
        {
            bool result;
            return bool.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static bool? ToBoolean(this object obj, bool? defaultValue)
        {
            bool result;
            return bool.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static Guid ToGuid(this object obj, Guid defaultValue = default(Guid))
        {
            Guid result;
            return Guid.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static Guid? ToGuid(this object obj, Guid? defaultValue)
        {
            Guid result;
            return Guid.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static DateTime ToDateTime(this object obj, DateTime defaultValue = default(DateTime))
        {
            DateTime result;
            return DateTime.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static DateTime? ToDateTime(this object obj, DateTime? defaultValue)
        {
            DateTime result;
            return DateTime.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static T ToEnum<T>(this object obj, T defaultValue = default(T))
            where T : struct
        {
            T result;
            return Enum.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static T? ToEnum<T>(this object obj, T? defaultValue)
            where T : struct
        {
            T result;
            return Enum.TryParse(obj.ToStr(), out result) ? result : defaultValue;
        }

        public static string ToXmlString(this object obj)
        {
            return ToXml(obj).ToString();
        }

        public static XDocument ToXml(this object obj)
        {
            var result = new XDocument();

            using (var writer = result.CreateWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
            }
            return result;
        }

        public static string ToJson(this object obj)
        {
            var result = new StringBuilder();
            try
            {
                new JavaScriptSerializer().Serialize(obj, result);
            }
            catch (Exception exp)
            {
                result.Insert(result.Length, exp.GetType().Name);
            }
            return result.ToString();
        }
    }
}

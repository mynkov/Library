using System;
using System.Linq;

namespace Library.Common.Extensions
{
    public static class TypeExtension
    {
        public static T GetCustomAttribute<T>(this Type type)
        {
            return (T)type.GetCustomAttributes(typeof (T), true).FirstOrDefault();
        }

        public static bool IsEnum(this Type type)
        {
            return type.IsEnum || IsNullableEnum(type);
        }

        public static bool IsNullableEnum(this Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return underlyingType != null && underlyingType.IsEnum;
        }
    }
}

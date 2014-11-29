using System;
using System.Reflection;
using Library.BusinessLayer.Attributes;
using Library.Common.Extensions;

namespace Library.BusinessLayer.Extensions
{
    public static class EnumExtensions
    {
        public static string GetFriendlyName(this Enum obj)
        {
            var enumName = obj.ToString();
            var type = obj.GetType();
            var enumResourceAttribute = type.GetCustomAttribute<ResourceAttribute>();

            if (enumResourceAttribute != null)
            {
                var property = enumResourceAttribute.ResourceType.GetProperty(enumName,
                                                                              BindingFlags.Static |
                                                                              BindingFlags.NonPublic);
                if (property != null)
                    return property.GetValue(enumResourceAttribute.ResourceType, null).ToString();
            }
            return enumName;
        }
    }
}

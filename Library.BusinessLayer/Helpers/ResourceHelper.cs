using System;
using System.Resources;
using Library.BusinessLayer.Attributes;
using Library.Common.Extensions;

namespace Library.BusinessLayer.Helpers
{
    public class ResourceHelper
    {
        public static string GetDisplayName(Type type, string propertyName)
        {
            var resource = type.GetCustomAttribute<ResourceAttribute>();
            return resource != null
                       ? new ResourceManager(resource.ResourceType).GetString(propertyName)
                       : null;
        }
    }
}

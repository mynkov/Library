using System;

namespace Library.BusinessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class ResourceAttribute : Attribute
    {
        public Type ResourceType { get; private set; }

        public ResourceAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }
    }
}

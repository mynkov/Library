using System;
using System.Web.Mvc;
using Library.BusinessLayer.Helpers;
using Library.Common.Extensions;

namespace Library.Web
{
    public class ModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            var metadata = base.GetMetadataForProperty(modelAccessor, containerType, propertyName);

            if (metadata.TemplateHint == null)
                metadata.TemplateHint = GetTemplateHint(metadata);

            if (metadata.DisplayName == null)
                metadata.DisplayName = GetDisplayName(metadata);

            return metadata;
        }

        private static string GetDisplayName(ModelMetadata metadata)
        {
            return ResourceHelper.GetDisplayName(metadata.ContainerType, metadata.PropertyName);
        }

        private static string GetTemplateHint(ModelMetadata metadata)
        {
            return metadata.ModelType.IsEnum()
                       ? typeof (Enum).Name
                       : null;
        }
    }
}
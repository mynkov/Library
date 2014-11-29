using System.ComponentModel.DataAnnotations;

namespace Library.BusinessLayer.Helpers
{
    public class ValidationHelper
    {
        public static ValidationContext GetValidationContext(ValidationContext validationContext)
        {
            var displayName = ResourceHelper.GetDisplayName(validationContext.ObjectType, validationContext.DisplayName);
            if (displayName != null)
                validationContext.DisplayName = displayName;

            return validationContext;
        }
    }
}

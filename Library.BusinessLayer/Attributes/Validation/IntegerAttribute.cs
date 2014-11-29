using System.ComponentModel.DataAnnotations;
using Library.BusinessLayer.Helpers;

namespace Library.BusinessLayer.Attributes.Validation
{
    public class IntegerAttribute : DataAnnotationsExtensions.IntegerAttribute
    {
        public IntegerAttribute()
        {
            ErrorMessageResourceType = typeof(Properties.Resources.Validation);
            ErrorMessageResourceName = typeof(IntegerAttribute).Name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, ValidationHelper.GetValidationContext(validationContext));
        }
    }
}

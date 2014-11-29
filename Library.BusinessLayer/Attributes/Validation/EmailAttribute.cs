using System.ComponentModel.DataAnnotations;
using Library.BusinessLayer.Helpers;

namespace Library.BusinessLayer.Attributes.Validation
{
    public class EmailAttribute : DataAnnotationsExtensions.EmailAttribute
    {
        public EmailAttribute()
        {
            ErrorMessageResourceType = typeof(Properties.Resources.Validation);
            ErrorMessageResourceName = typeof(EmailAttribute).Name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, ValidationHelper.GetValidationContext(validationContext));
        }
    }
}

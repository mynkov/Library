using System.ComponentModel.DataAnnotations;
using Library.BusinessLayer.Helpers;

namespace Library.BusinessLayer.Attributes.Validation
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessageResourceType = typeof(Properties.Resources.Validation);
            ErrorMessageResourceName = typeof (RequiredAttribute).Name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, ValidationHelper.GetValidationContext(validationContext));
        }
    }
}

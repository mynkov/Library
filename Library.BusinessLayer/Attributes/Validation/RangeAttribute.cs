using System.ComponentModel.DataAnnotations;
using Library.BusinessLayer.Helpers;

namespace Library.BusinessLayer.Attributes.Validation
{
    public class RangeAttribute : System.ComponentModel.DataAnnotations.RangeAttribute
    {
        public RangeAttribute(int minimum, int maximum)
            :base(minimum, maximum)
        {
            ErrorMessageResourceType = typeof(Properties.Resources.Validation);
            ErrorMessageResourceName = typeof(RangeAttribute).Name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, ValidationHelper.GetValidationContext(validationContext));
        }
    }
}

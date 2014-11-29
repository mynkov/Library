using System.ComponentModel.DataAnnotations;
using Library.BusinessLayer.Helpers;

namespace Library.BusinessLayer.Attributes.Validation
{
    public class CompareAttribute : System.Web.Mvc.CompareAttribute
    {    
        public CompareAttribute(string otherProperty)
            : base(otherProperty)
        {
            ErrorMessageResourceType = typeof(Properties.Resources.Validation);
            ErrorMessageResourceName = typeof(CompareAttribute).Name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, ValidationHelper.GetValidationContext(validationContext));
        }
    }
}

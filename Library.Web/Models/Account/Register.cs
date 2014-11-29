using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Attributes.Validation;
using DataTypeAttribute = System.ComponentModel.DataAnnotations.DataTypeAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Library.Web.Models.Account
{
    [Resource(typeof(Properties.Resources.Models.Register))]
    public class Register
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Email]
        public string Email { get; set; }

        [Required]
        [StringLength(6, 100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
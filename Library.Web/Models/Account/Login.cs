using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Attributes.Validation;
using DataTypeAttribute = System.ComponentModel.DataAnnotations.DataTypeAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Library.Web.Models.Account
{
    [Resource(typeof(Properties.Resources.Models.Login))]
    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
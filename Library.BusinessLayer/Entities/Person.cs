using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Attributes.Validation;
using Library.BusinessLayer.Enums;
using DataTypeAttribute = System.ComponentModel.DataAnnotations.DataTypeAttribute;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Library.BusinessLayer.Entities
{
    [Resource(typeof(Properties.Resources.Entities.Person))]
    public class Person : Entity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Integer]
        [Required]     
        [Range(1, 100)]
        public int Age { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public Gender Gender { get; set; }

        public Education? Education { get; set; }

        public string Address { get; set; }

        [Email]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Annotation { get; set; }

        [XmlIgnore]
        public IList<Book> Books { get; set; }
    }
}

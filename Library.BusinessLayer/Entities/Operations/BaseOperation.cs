using System;
using Library.BusinessLayer.Attributes.Validation;
using Library.BusinessLayer.Enums;

namespace Library.BusinessLayer.Entities.Operations
{
    public abstract class BaseOperation
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        public DateTime CreationDate { get; set; }

        public OperationType OperationType { get; set; }

        public string Object { get; set; }
    }
}

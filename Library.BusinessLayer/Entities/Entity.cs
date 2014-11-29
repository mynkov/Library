using System;

namespace Library.BusinessLayer.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Deleted { get; set; }
    }
}

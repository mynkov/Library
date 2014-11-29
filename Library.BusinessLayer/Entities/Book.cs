using System.Collections.Generic;

namespace Library.BusinessLayer.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public IList<Person> Persons { get; set; }
    }
}

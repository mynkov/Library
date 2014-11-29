using System;
using System.Linq;
using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Repositories;
using Library.BusinessLayer.Entities;

namespace Library.DataAccessLayer.Repositories
{
    public class PeopleRepository : EntitiesRepository<Person>, IPeopleRepository
    {
        public PeopleRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }

        [DataAccessLayerException]
        public void AddBook(Person person)
        {
            Execute(db =>
                        {
                            var tmp = person.Books.ToList();
                            person.Books.Clear();
                             db.People.Attach(person);
                      
                             person.Books.Clear();
                            
                            //foreach (var book in tmp)
                            //{
                            //    db.Books.Attach(book);
                            //    person.Books.Add(book);
                            //}
                       
                            db.SaveChanges();
                        });
        }
    }
}

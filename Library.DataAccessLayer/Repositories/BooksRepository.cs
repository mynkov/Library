using System;
using System.Linq;
using Library.BusinessLayer.Repositories;
using Library.BusinessLayer.Entities;
using System.Data.Entity;


namespace Library.DataAccessLayer.Repositories
{
    public class BooksRepository : EntitiesRepository<Book>, IBooksRepository
    {
        public BooksRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }

        public override Book Get(int id)
        {
            return Execute(db => db.Books.Include(x => x.Persons).Single(x => x.Id == id));
        }
    }
}

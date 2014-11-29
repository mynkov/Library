using System;
using System.Data.Entity;
using System.Linq;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;

namespace Library.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(Action<string> queryLogger)
            :this()
        {
            Database.Log = queryLogger;
        }

        public IQueryable<T> FilterSet<T>()
            where T : Entity
        {
            return Set<T>().Where(x => !x.Deleted);
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Person> People { get; set; }      

        public DbSet<Book> Books { get; set; }


        public DbSet<UsersOperation> UsersOperations { get; set; }

        public DbSet<PeopleOperation> PeopleOperations { get; set; }

        public DbSet<BooksOperation> BooksOperations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new ModelBuilder().ModelCreating(modelBuilder);
        }
    }
}

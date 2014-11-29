using Library.BusinessLayer.Entities;

namespace Library.BusinessLayer.Repositories
{
    public interface IPeopleRepository : IRepository<Person>
    {
        void AddBook(Person personId);
    }
}

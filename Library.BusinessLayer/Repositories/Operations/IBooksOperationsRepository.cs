using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;

namespace Library.BusinessLayer.Repositories.Operations
{
    public interface IBooksOperationsRepository : IOperationsRepository<BooksOperation, Book>
    {
    }
}

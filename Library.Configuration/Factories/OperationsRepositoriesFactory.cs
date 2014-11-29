using System;
using Library.BusinessLayer.Repositories.Operations;
using Library.DataAccessLayer.Repositories.Operations;

namespace Library.Configuration.Factories
{
    public class OperationsRepositoriesFactory : RepositoriesFactory
    {
        public OperationsRepositoriesFactory(Action<string> queryLogger)
            : base(queryLogger)
        {
        }

        public IUsersOperationsRepository CreateUsersOperationsRepository()
        {
            return new UsersOperationsRepository(GetUser(), QueryLogger);
        }

        public IPeopleOperationsRepository CreatePeopleOperationsRepository()
        {
            return new PeopleOperationsRepository(GetUser(), QueryLogger);
        }

        public IBooksOperationsRepository CreateBooksOperationsRepository()
        {
            return new BooksOperationsRepository(GetUser(), QueryLogger);
        }
    }
}

using System;
using Library.BusinessLayer.Entities;
using Library.DataAccessLayer.Repositories;

namespace Library.Configuration.Factories
{
    public abstract class RepositoriesFactory
    {
        protected readonly Action<string> QueryLogger;

        protected RepositoriesFactory(Action<string> queryLogger)
        {
            QueryLogger = queryLogger;
        }

        protected User GetUser()
        {
            return new UsersRepository(null, QueryLogger, "Guest").Get();
        }
    }
}

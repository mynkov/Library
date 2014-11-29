using System;
using Library.BusinessLayer.Entities;

namespace Library.DataAccessLayer.Repositories
{
    public abstract class Repository
    {
        private readonly Action<string> _queryLogger;

        protected readonly User User;

        protected Repository(User user, Action<string> queryLogger)
        {
            User = user;
            _queryLogger = queryLogger;
        }

        public void Execute(Action<DatabaseContext> function)
        {
            using (var db = new DatabaseContext(_queryLogger))
                function(db);
        }

        public T Execute<T>(Func<DatabaseContext, T> function)
        {
            using (var db = new DatabaseContext(_queryLogger))
                return function(db);
        }
    }
}

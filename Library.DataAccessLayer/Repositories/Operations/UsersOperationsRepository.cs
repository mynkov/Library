using System;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Repositories.Operations;

namespace Library.DataAccessLayer.Repositories.Operations
{
    public class UsersOperationsRepository : OperationsRepository<UsersOperation, User>, IUsersOperationsRepository
    {
        public UsersOperationsRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }
    }
}

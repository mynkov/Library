using System;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Repositories.Operations;

namespace Library.DataAccessLayer.Repositories.Operations
{
    public class PeopleOperationsRepository : OperationsRepository<PeopleOperation, Person>, IPeopleOperationsRepository
    {
        public PeopleOperationsRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }
    }
}

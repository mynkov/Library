using System;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Notifications;
using Library.BusinessLayer.Observers;
using Library.BusinessLayer.Repositories;
using Library.DataAccessLayer.Repositories;
using Library.DataAccessLayer.Repositories.Operations;

namespace Library.Configuration.Factories
{
    public class EntityRepositoriesFactory : RepositoriesFactory
    {
        public EntityRepositoriesFactory(Action<string> queryLogger)
            : base(queryLogger)
        {
        }

        public IUsersRepository CreateUsersRepository()
        {
            var user = GetUser();

            var repository = new UsersRepository(user, QueryLogger);
            var notificatorRepository = new UsersNotificator(user, repository);
            var operationsRepository = new UsersOperationsRepository(user, QueryLogger);
            var operationsWriter = new OperationsWriter<User, UsersOperation>(notificatorRepository, operationsRepository);

            operationsWriter.Subscribe();
            return notificatorRepository;
        }

        public IPeopleRepository CreatePeopleRepository()
        {
            var user = GetUser();

            var repository = new PeopleRepository(user, QueryLogger);
            var notificatorRepository = new PeopleNotificator(user, repository);
            var operationsRepository = new PeopleOperationsRepository(user, QueryLogger);
            var operationsWriter = new OperationsWriter<Person, PeopleOperation>(notificatorRepository, operationsRepository);

            operationsWriter.Subscribe();
            return notificatorRepository;
        }

        public IBooksRepository CreateBooksRepository()
        {
            var user = GetUser();

            var repository = new BooksRepository(user, QueryLogger);
            var notificatorRepository = new BooksNotificator(user, repository);
            var operationsRepository = new BooksOperationsRepository(user, QueryLogger);
            var operationsWriter = new OperationsWriter<Book, BooksOperation>(notificatorRepository, operationsRepository);

            operationsWriter.Subscribe();
            return notificatorRepository;
        }
    }
}

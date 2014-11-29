using System.Data.Entity;
using Autofac;
using Library.BusinessLayer.Repositories;
using Library.BusinessLayer.Repositories.Operations;
using Library.Configuration.Factories;
using Library.DataAccessLayer;

namespace Library.Configuration
{
    public class Configuration
    {
        public ContainerBuilder GetContainerBuilder()
        {
            var builder = new ContainerBuilder();
            Register(builder);
            return builder;
        }

        public void ConfigureDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, DataAccessLayer.Migrations.Configuration>());
        }

        protected virtual void Register(ContainerBuilder builder)
        {
            var commonFactory = new CommonFactory();
            var queryLogger = commonFactory.CreateQueryLogger();
            var entityRepositoriesFactory = new EntityRepositoriesFactory(queryLogger);
            var operationsRepositoriesFactory = new OperationsRepositoriesFactory(queryLogger);

            builder.Register(x => entityRepositoriesFactory.CreateUsersRepository()).As<IUsersRepository>().InstancePerLifetimeScope();
            builder.Register(x => entityRepositoriesFactory.CreatePeopleRepository()).As<IPeopleRepository>().InstancePerLifetimeScope();
            builder.Register(x => entityRepositoriesFactory.CreateBooksRepository()).As<IBooksRepository>().InstancePerLifetimeScope();

            builder.Register(x => operationsRepositoriesFactory.CreateUsersOperationsRepository()).As<IUsersOperationsRepository>().InstancePerLifetimeScope();
            builder.Register(x => operationsRepositoriesFactory.CreatePeopleOperationsRepository()).As<IPeopleOperationsRepository>().InstancePerLifetimeScope();
            builder.Register(x => operationsRepositoriesFactory.CreateBooksOperationsRepository()).As<IBooksOperationsRepository>().InstancePerLifetimeScope();
        }
    }
}
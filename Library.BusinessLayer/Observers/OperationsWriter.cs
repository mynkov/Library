using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Enums;
using Library.BusinessLayer.Notifications;
using Library.BusinessLayer.Notifications.EventArgs;
using Library.BusinessLayer.Repositories.Operations;
using Library.Common.Extensions;

namespace Library.BusinessLayer.Observers
{
    public class OperationsWriter<TEntity, TOperation>
        where TEntity : Entity, new()
        where TOperation : Operation<TEntity>, new()
    {
        private readonly Notificator<TEntity> _notificator;

        private readonly IOperationsRepository<TOperation, TEntity> _operationsRepository;

        public OperationsWriter(Notificator<TEntity> notificator, IOperationsRepository<TOperation, TEntity> operationsRepository)
        {
            _notificator = notificator;
            _operationsRepository = operationsRepository;
        }

        public void Subscribe()
        {
            _notificator.Inserted += Inserted;
            _notificator.Updated += Updated;
            _notificator.Geted += Geted;
            _notificator.Deleted += Deleted;
        }

        protected virtual void Inserted(object sender, NotificatorEntityArgs<TEntity> e)
        {
            _operationsRepository.Insert(new TOperation
                                          {
                                              User = e.User,
                                              Entity = e.Entity,
                                              Object = e.Entity.ToXmlString(),
                                              OperationType = OperationType.Insert
                                          });
        }

        protected virtual void Updated(object sender, NotificatorEntityArgs<TEntity> e)
        {
            _operationsRepository.Insert(new TOperation
                                          {
                                              User = e.User,
                                              Entity = e.Entity,
                                              Object = e.Entity.ToXmlString(),
                                              OperationType = OperationType.Update
                                          });
        }

        protected virtual void Geted(object sender, NotificatorArgs e)
        {
            _operationsRepository.Insert(new TOperation
                                          {
                                              User = e.User,
                                              Entity = new TEntity { Id = e.Id, },
                                              OperationType = OperationType.Get
                                          });
        }

        protected virtual void Deleted(object sender, NotificatorArgs e)
        {
            _operationsRepository.Insert(new TOperation
                                          {
                                              User = e.User,
                                              Entity = new TEntity { Id = e.Id, },
                                              OperationType = OperationType.Delete
                                          });
        }
    }
}

using System.Collections.Generic;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Models;
using Library.BusinessLayer.Repositories;

namespace Library.BusinessLayer.Notifications
{
    public abstract class EntityNotificator<TRepository, TEntity> : Notificator<TEntity>, IRepository<TEntity>
        where TEntity : Entity
        where TRepository : IRepository<TEntity>
    {
        protected readonly User User;

        protected readonly TRepository Repository;

        protected EntityNotificator(User user, TRepository repository)
        {
            User = user;
            Repository = repository;
        }

        public virtual void Insert(TEntity entity)
        {
            Repository.Insert(entity);
            OnInserted(User, entity);
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
            OnUpdated(User, entity);
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);
            OnDeleted(User, id);
        }

        public virtual TEntity Get(int id)
        {
            var entity = Repository.Get(id);
            OnGeted(User, id);
            return entity;
        }

        public virtual IList<TEntity> GetList()
        {
            return Repository.GetList();
        }

        public virtual IList<TEntity> GetList(Paging paging)
        {
            return Repository.GetList(paging);
        }

        public int GetCount()
        {
            return Repository.GetCount();
        }
    }
}

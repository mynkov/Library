using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Extensions;
using Library.BusinessLayer.Models;
using Library.BusinessLayer.Repositories;

namespace Library.DataAccessLayer.Repositories
{
    public abstract class EntitiesRepository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        protected EntitiesRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }

        [DataAccessLayerException]
        public virtual void Insert(TEntity entity)
        {
            Execute(db =>
                        {
                            entity.CreationDate = DateTime.Now;
                            db.Set<TEntity>().Add(entity);
                            db.SaveChanges();
                        });
        }

        [DataAccessLayerException]
        public virtual void Update(TEntity entity)
        {
            Execute(db =>
                        {
                            db.Set<TEntity>().Attach(entity);
                            db.Entry(entity).State = EntityState.Modified;
                            db.SaveChanges();
                        });
        }

        [DataAccessLayerException]
        public virtual void Delete(int id)
        {
            Execute(db =>
                        {
                            var entity = db.FilterSet<TEntity>().Single(x => x.Id == id);
                            entity.Deleted = true;
                            db.SaveChanges();
                        });
        }

        [DataAccessLayerException]
        public virtual TEntity Get(int id)
        {
            return Execute(db => db.FilterSet<TEntity>().Single(x => x.Id == id));
        }

        [DataAccessLayerException]
        public virtual IList<TEntity> GetList()
        {
            return Execute(db => db.FilterSet<TEntity>().ToList());
        }

        [DataAccessLayerException]
        public virtual IList<TEntity> GetList(Paging paging)
        {
            return Execute(db => db.FilterSet<TEntity>().
                                     OrderByDescending(x => x.Id).
                                     Paging(paging).ToList());
        }

        [DataAccessLayerException]
        public int GetCount()
        {
            return Execute(db => db.FilterSet<TEntity>().Count());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Extensions;
using Library.BusinessLayer.Models;
using Library.BusinessLayer.Repositories.Operations;
using System.Data.Entity;

namespace Library.DataAccessLayer.Repositories.Operations
{
    public abstract class OperationsRepository<TOperation, TEntity> : Repository, IOperationsRepository<TOperation, TEntity>
        where TOperation : Operation<TEntity>
        where TEntity : Entity
    {
        protected OperationsRepository(User user, Action<string> queryLogger)
            : base(user, queryLogger)
        {
        }

        [DataAccessLayerException]
        public virtual void Insert(TOperation entity)
        {
            Execute(db =>
                        {
                            entity.CreationDate = DateTime.Now;
                            db.Set<TOperation>().Attach(entity);
                            db.Set<TOperation>().Add(entity);
                            db.SaveChanges();
                        });
        }

        [DataAccessLayerException]
        public virtual TOperation Get(int id)
        {
            return Execute(db => db.Set<TOperation>().Single(x => x.Id == id));
        }

        [DataAccessLayerException]
        public int GetCount()
        {
            return Execute(db => db.Set<TOperation>().Count());
        }

        [DataAccessLayerException]
        public int GetCount(int entityId)
        {
            return Execute(db => db.Set<TOperation>().Count(x => x.Entity.Id == entityId));
        }

        [DataAccessLayerException]
        public virtual IList<TOperation> GetList(Paging paging)
        {
            return Execute(db => db.Set<TOperation>().
                                     Include(x => x.User).
                                     OrderByDescending(x => x.Id).
                                     Paging(paging).ToList().Select(x =>
                                     {
                                         x.User.MembershipUser = Membership.GetUser(x.User.UserId);
                                         return x;
                                     }).ToList());
        }

        [DataAccessLayerException]
        public IList<TOperation> GetList(int entityId, Paging paging)
        {
            return Execute(db => db.Set<TOperation>().
                                     Include(x => x.User).
                                     Where(x => x.Entity.Id == entityId).
                                     OrderByDescending(x => x.Id).
                                     Paging(paging).ToList().Select(x =>
                                                                        {
                                                                            x.User.MembershipUser = Membership.GetUser(x.User.UserId);
                                                                            return x;
                                                                        }).ToList());
        }
    }
}

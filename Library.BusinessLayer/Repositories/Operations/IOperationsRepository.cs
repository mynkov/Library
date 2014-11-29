using System.Collections.Generic;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Entities.Operations;
using Library.BusinessLayer.Models;

namespace Library.BusinessLayer.Repositories.Operations
{
    public interface IOperationsRepository<TOperation, T>
        where TOperation : Operation<T>
        where T : Entity
    {
        void Insert(TOperation entity);

        TOperation Get(int id);

        int GetCount();

        int GetCount(int entityId);

        IList<TOperation> GetList(Paging paging);

        IList<TOperation> GetList(int entityId, Paging paging);
    }
}

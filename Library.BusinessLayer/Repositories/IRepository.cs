using System.Collections.Generic;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Models;

namespace Library.BusinessLayer.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        T Get(int id);

        IList<T> GetList();

        IList<T> GetList(Paging paging);

        int GetCount();
    }
}

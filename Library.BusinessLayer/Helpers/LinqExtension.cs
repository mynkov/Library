using System.Linq;
using Library.BusinessLayer.Models;

namespace Library.BusinessLayer.Extensions
{
    public static class LinqExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> source, Paging paging)
        {
            return source.Skip((paging.Page - 1)*paging.PageSize).Take(paging.PageSize);
        }
    }
}

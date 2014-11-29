using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Repositories;

namespace Library.BusinessLayer.Notifications
{
    public class BooksNotificator : EntityNotificator<IBooksRepository, Book>, IBooksRepository
    {
        public BooksNotificator(User user, IBooksRepository repository)
            : base(user, repository)
        {
        }
    }
}

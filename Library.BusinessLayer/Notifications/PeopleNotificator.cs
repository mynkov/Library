using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Repositories;

namespace Library.BusinessLayer.Notifications
{
    public class PeopleNotificator : EntityNotificator<IPeopleRepository, Person>, IPeopleRepository
    {
        public PeopleNotificator(User user, IPeopleRepository repository)
            : base(user, repository)
        {
        }

        public void AddBook(Person personId)
        {
            Repository.AddBook(personId);
        }
    }
}

using System.Web.Security;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Repositories;

namespace Library.BusinessLayer.Notifications
{
    public class UsersNotificator : EntityNotificator<IUsersRepository, User>, IUsersRepository
    {
        public UsersNotificator(User user, IUsersRepository repository)
            : base(user, repository)
        {
        }

        public User Get()
        {
            return Repository.Get();
        }

        public User Get(string userName)
        {
            return Repository.Get(userName);
        }

        public bool ValidateUser(string userName, string password)
        {
            return Repository.ValidateUser(userName, password);
        }

        public User Create(string userName, string password, string email, out MembershipCreateStatus status)
        {
            var createdUser = Repository.Create(userName, password, email, out status);
            if(createdUser != null)
                OnInserted(User, createdUser);
            return createdUser;
        }
    }
}

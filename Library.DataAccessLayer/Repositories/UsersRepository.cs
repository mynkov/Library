using System;
using System.Linq;
using System.Web.Security;
using Library.BusinessLayer.Attributes;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Extensions;
using Library.BusinessLayer.Repositories;

namespace Library.DataAccessLayer.Repositories
{
    public class UsersRepository : EntitiesRepository<User>, IUsersRepository
    {
        private readonly string _defaultUser;

        public UsersRepository(User user, Action<string> queryLogger, string defaultUser = null)
            : base(user, queryLogger)
        {
            _defaultUser = defaultUser;
        }

        [DataAccessLayerException]
        public User Get()
        {
            return Get(Membership.GetUser() ?? Membership.GetUser(_defaultUser));
        }

        [DataAccessLayerException]
        public User Get(string userName)
        {
            return Get(Membership.GetUser(userName));
        }

        [DataAccessLayerException]
        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(userName, password);
        }

        [DataAccessLayerException]
        public User Create(string userName, string password, string email, out MembershipCreateStatus status)
        {
            var membershipUser = Membership.CreateUser(userName, password, email, null, null, true, null, out status);

            if (status == MembershipCreateStatus.Success)
            {
                var user = new User {UserId = membershipUser.GetUserId(), MembershipUser = membershipUser};
                Insert(user);
                return user;
            }
            return null;
        }

        private User Get(MembershipUser membershipUser)
        {
            var userId = membershipUser.GetUserId();
            var user = Execute(db => db.Users.Single(x => x.UserId == userId));
            user.MembershipUser = membershipUser;
            return user;
        }
    }
}

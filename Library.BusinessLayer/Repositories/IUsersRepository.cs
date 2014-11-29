using System.Web.Security;
using Library.BusinessLayer.Entities;

namespace Library.BusinessLayer.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        User Get();

        User Get(string userName);

        bool ValidateUser(string userName, string password);

        User Create(string userName, string password, string email, out MembershipCreateStatus status);
    }
}

using System;
using System.Web.Security;

namespace Library.BusinessLayer.Extensions
{
    public static class MembershipExtension
    {
        public static Guid GetUserId(this MembershipUser user)
        {
            return (Guid)user.ProviderUserKey;
        }
    }
}

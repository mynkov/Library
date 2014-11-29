using System;
using System.Web.Security;

namespace Library.BusinessLayer.Entities
{
    public class User : Entity
    {
        public Guid UserId { get; set; }

        public MembershipUser MembershipUser { get; set; }
    }
}
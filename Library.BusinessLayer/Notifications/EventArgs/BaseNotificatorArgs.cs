using Library.BusinessLayer.Entities;

namespace Library.BusinessLayer.Notifications.EventArgs
{
    public class BaseNotificatorArgs : System.EventArgs
    {
        public User User { get; protected set; }

        public BaseNotificatorArgs(User user)
        {
            User = user;
        }
    }
}

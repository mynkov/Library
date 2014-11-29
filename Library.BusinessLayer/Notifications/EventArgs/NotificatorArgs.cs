using Library.BusinessLayer.Entities;

namespace Library.BusinessLayer.Notifications.EventArgs
{
    public class NotificatorArgs : BaseNotificatorArgs
    {
        public int Id { get; protected set; }

        public NotificatorArgs(User user, int id)
            :base(user)
        {
            Id = id;
        }
    }
}

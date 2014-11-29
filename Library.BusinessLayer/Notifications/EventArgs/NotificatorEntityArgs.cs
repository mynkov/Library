using System;
using Library.BusinessLayer.Entities;

namespace Library.BusinessLayer.Notifications.EventArgs
{
    public class NotificatorEntityArgs<T> : BaseNotificatorArgs
        where T : Entity
    {
        public T Entity { get; protected set; }

        public NotificatorEntityArgs(User user, T entity)
            : base(user)
        {
            Entity = entity;
        }
    }
}

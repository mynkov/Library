using System;
using Library.BusinessLayer.Entities;
using Library.BusinessLayer.Notifications.EventArgs;

namespace Library.BusinessLayer.Notifications
{
    public abstract class Notificator<TEntity>
        where TEntity : Entity
    {
        public event EventHandler<NotificatorEntityArgs<TEntity>> Inserted;

        public event EventHandler<NotificatorEntityArgs<TEntity>> Updated;

        public event EventHandler<NotificatorArgs> Deleted;

        public event EventHandler<NotificatorArgs> Geted;

        protected void OnInserted(User user, TEntity entity)
        {
            if (Inserted != null)
                Inserted(this, new NotificatorEntityArgs<TEntity>(user, entity));
        }

        protected void OnUpdated(User user, TEntity entity)
        {
            if (Updated != null)
                Updated(this, new NotificatorEntityArgs<TEntity>(user, entity));
        }

        protected void OnGeted(User user, int id)
        {
            if (Geted != null)
                Geted(this, new NotificatorArgs(user, id));
        }

        protected void OnDeleted(User user, int id)
        {
            if (Deleted != null)
                Deleted(this, new NotificatorArgs(user, id));
        }
    }
}

using System;
using System.Collections.Generic;

namespace Server.NotificationLogic
{
    public sealed class NotificationsList
    {
        public event Action<Notification> OnNotificationAdded;

        private List<Notification> _notifications;

        public NotificationsList()
        {
            _notifications = new();
        }

        public List<Notification> Notifications => _notifications;

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);

            OnNotificationAdded?.Invoke(notification);
        }
    }
}
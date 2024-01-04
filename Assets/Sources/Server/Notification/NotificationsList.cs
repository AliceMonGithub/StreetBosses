using Server.QuestsLogic;
using Server.TradeLogic;
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

        public void SubscribeToQuestCompliting(QuestsList questsList)
        {
            questsList.OnQuestCompleted += AddNotificationAboutQuestCompliting;
        }

        public void SubscribeToTradeCreating(TradesList tradesList)
        {
            tradesList.OnTradeAdded += AddNotificationAboutTradeCreating;
        }

        private void AddNotificationAboutQuestCompliting(Quest quest)
        {
            AddNotification(new(NotificationsPreload.QuestWasCompleted));
        }

        private void AddNotificationAboutTradeCreating(Trade trade)
        {
            AddNotification(new(NotificationsPreload.FormatNotificationAboutNewTrade(trade.From.Nickname, trade.Money)));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);

            OnNotificationAdded?.Invoke(notification);
        }
    }
}
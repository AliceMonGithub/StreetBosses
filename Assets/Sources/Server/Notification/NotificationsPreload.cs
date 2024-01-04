namespace Server.NotificationLogic
{
    public static class NotificationsPreload
    {
        public static string QuestWasCompleted = "Quest was completed";

        public static string FormatNotificationAboutNewTrade(string nickname, int money)
        {
            return $"{nickname} want to buy your business {money}$";
        }
    }
}
using Server.NotificationLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;
using Server.QuestsLogic;
using Server.BusinessLogic;

namespace Server.PlayerLogic
{
    public class Player
    {
        public readonly Money Money;

        public readonly BusinessesList BusinessesList;
        public readonly CharactersList CharactersList;
        public readonly QuestsList QuestsList;
        public readonly NotificationsList NotificationList;

        public Player()
        {
            Money = new(5000);

            BusinessesList = new();
            CharactersList = new();
            QuestsList = new();
            NotificationList = new();
        }
    }
}
using Server.NotificationLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;
using Server.QuestsLogic;
using Server.BusinessLogic;
using Server.PlayerLogicTest;

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
            Money = new(4000);

            BusinessesList = new();
            CharactersList = new();
            QuestsList = new();
            NotificationList = new();
        }

        public bool TryBuyBusiness(Business business)
        {
            if (Money.Value < business.Cost) return false;
            if (business.Owner == this) return false; 

            Money.Spend(business.Cost);
            BusinessesList.AddBusiness(business);
            business.Reset();
            business.SetOwner(this);

            return true;
        }
    }
}
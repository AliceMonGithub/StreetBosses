using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;

namespace Server.PlayerLogic
{
    public sealed class Player
    {
        public readonly Money Money;

        public readonly BusinessesList BusinessesList;
        public readonly CharactersList CharactersList;

        public readonly QuestsList QuestsList;

        public Player()
        {
            Money = new(5000);

            BusinessesList = new();
            CharactersList = new();

            QuestsList = new();
        }
    }
}
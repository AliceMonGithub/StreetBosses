using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;

namespace Server.PlayerLogic
{
    public sealed class Player : IReadOnlyPlayer
    {
        public readonly Money Money;

        public readonly BusinessesList BusinessesList;
        public readonly CharactersList CharactersList;

        public Player()
        {
            Money = new(5000);

            BusinessesList = new();
            CharactersList = new();
        }

        IReadOnlyMoney IReadOnlyPlayer.Money => Money;

        IReadOnlyBusinessesList IReadOnlyPlayer.BusinessesList => BusinessesList;
        IReadOnlyCharactersList IReadOnlyPlayer.CharactersList => CharactersList;
    }
}
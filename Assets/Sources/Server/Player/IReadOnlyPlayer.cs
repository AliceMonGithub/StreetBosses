using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;

namespace Server.PlayerLogic
{
    public interface IReadOnlyPlayer
    {
        IReadOnlyMoney Money { get; }

        IReadOnlyBusinessesList BusinessesList { get; }
        IReadOnlyCharactersList CharactersList { get; }
    }
}
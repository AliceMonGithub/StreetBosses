using Server.CharacterLogic;
using Server.MoneyLogic;

namespace Server.PlayerLogic
{
    internal interface IReadOnlyPlayer
    {
        IReadOnlyMoney Money { get; }
        IReadOnlyCharacterList CharacterList { get; }
    }
}
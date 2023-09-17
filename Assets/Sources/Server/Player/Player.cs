using Server.CharacterLogic;
using Server.MoneyLogic;

namespace Server.PlayerLogic
{
    internal sealed class Player : IReadOnlyPlayer
    {
        private readonly Money _money;

        private readonly CharacterList _characterList;

        public Player()
        {
            _money = new(5000);
            _characterList = new CharacterList();
        }

        public IReadOnlyMoney Money => _money;
        public IReadOnlyCharacterList CharacterList => _characterList;
    }
}
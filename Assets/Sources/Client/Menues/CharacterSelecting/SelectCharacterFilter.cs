using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;

namespace Client.MenuesLogic
{
    internal abstract class SelectCharacterFilter
    {
        public abstract List<Character> GetFiltered(Player player);
    }
}

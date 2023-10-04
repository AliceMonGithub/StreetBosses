using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;

namespace Client.MenuesLogic
{
    internal sealed class SecuritySelectFilter : SelectCharacterFilter
    {
        public override List<Character> GetFiltered(Player player)
        {
            List<Character> filtered = new();

            foreach (var keyPair in player.CharactersList.Characters)
            {
                Character character = keyPair.Value;

                if(character.Security == null)
                {
                    filtered.Add(character);
                }
            }

            return filtered;
        }
    }
}

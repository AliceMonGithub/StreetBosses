using System.Collections.Generic;

namespace Server.CharacterLogic
{
    internal sealed class CharacterList : IReadOnlyCharacterList
    {
        private List<Character> _characters;

        public CharacterList()
        {
            _characters = new();
        }

        public void AddCharacter(Character character)
        {
            _characters.Add(character);
        }

        public IReadOnlyList<IReadOnlyCharacter> Characters => _characters;
    }
}
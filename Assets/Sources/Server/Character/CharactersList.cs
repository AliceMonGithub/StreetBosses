using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public sealed class CharactersList : IReadOnlyCharactersList
    {
        private List<Character> _characters;

        public CharactersList()
        {
            _characters = new();
        }

        public IReadOnlyList<IReadOnlyCharacter> Characters => _characters;

        public void AddCharacter(Character character)
        {
            _characters.Add(character);
        }
    }
}
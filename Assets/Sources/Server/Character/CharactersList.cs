using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public sealed class CharactersList : IReadOnlyCharactersList
    {
        private Dictionary<string, Character> _characters;

        public CharactersList()
        {
            _characters = new();
        }

        public IReadOnlyDictionary<string, Character> Characters => _characters;

        public void AddCharacter(Character character)
        {
            _characters.Add(character.Name, character);
        }
    }
}
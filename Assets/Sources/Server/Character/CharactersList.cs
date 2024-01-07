using Client.AbilityLogic;
using System;
using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public sealed class CharactersList : IReadOnlyCharactersList
    {
        public event Action<Character> OnCharacterAdded;

        private Dictionary<string, Character> _characters;

        public CharactersList()
        {
            _characters = new();
        }

        public Dictionary<string, Character> Characters => _characters;

        public void AddCharacter(Character character)
        {
            _characters.Add(character.Name, character);

            OnCharacterAdded?.Invoke(character);
        }

        public List<Ability> GetAbilities()
        {
            List<Ability> abilities = new();

            foreach (Character character in _characters.Values)
            {
                abilities.Add(character.Ability);
            }

            return abilities;
        }
    }
}
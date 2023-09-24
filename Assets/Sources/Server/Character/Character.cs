using Server.BusinessLogic;
using UnityEngine;

namespace Server.CharacterLogic
{
    public sealed class Character
    {
        private readonly Sprite _avatar;
        private readonly string _name;

        private readonly CharacterInstance _characterInstance;

        public Character(CharacterData data)
        {
            _avatar = data.Avatar;
            _name = data.Name;

            _characterInstance = data.CharacterInstance;
        }

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public CharacterInstance CharacterInstance => _characterInstance;
    }
}
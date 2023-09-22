using Server.BusinessLogic;
using UnityEngine;

namespace Server.CharacterLogic
{
    public sealed class Character
    {
        private readonly Sprite _avatar;
        private readonly string _name;

        private readonly CharacterInstance _characterInstance;

        public Character(CharacterBlank blank)
        {
            _avatar = blank.Avatar;
            _name = blank.Name;

            _characterInstance = blank.CharacterInstance;
        }

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public CharacterInstance CharacterInstance => _characterInstance;
    }
}
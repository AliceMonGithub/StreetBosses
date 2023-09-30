using Server.BusinessLogic;
using Server.PlayerLogicTest;
using UnityEngine;

namespace Server.CharacterLogic
{
    public sealed class Character
    {
        private readonly Sprite _avatar;
        private readonly string _name;

        private readonly float _attackDistance;
        private readonly float _smoothTime;
        private readonly float _maxSpeed;

        private readonly CharacterInstance _characterInstance;

        public Character(Sprite avatar, string name, float attackDistance, float smoothTime, float maxSpeed, CharacterInstance characterInstance)
        {
            _avatar = avatar;
            _name = name;

            _attackDistance = attackDistance;
            _smoothTime = smoothTime;
            _maxSpeed = maxSpeed;

            _characterInstance = characterInstance;
        }

        public Character(CharacterData data) : this(data.Avatar, data.Name, 1, 0.3f, 4, data.CharacterInstance)
        {
        }

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public float AttackDistance => _attackDistance;
        public float SmoothTime => _smoothTime;
        public float MaxSpeed => _maxSpeed;

        public CharacterInstance CharacterInstance => _characterInstance;
    }
}
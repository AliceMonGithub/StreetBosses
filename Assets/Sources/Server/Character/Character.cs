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
        //private readonly float _smoothTime;
        //private readonly float _maxSpeed;
        private readonly float _health;
        private readonly float _damage;
        private readonly float _attackCooldown;

        private readonly CharacterInstance _characterInstance;
        private readonly Ability _ability;

        public Character(Sprite avatar, string name, float attackDistance, float smoothTime, float maxSpeed,
            float health, float damage, float attackCooldown, CharacterInstance characterInstance, Ability ability)
        {
            _avatar = avatar;
            _name = name;

            _attackDistance = attackDistance;
            //_smoothTime = smoothTime;
            //_maxSpeed = maxSpeed;
            _health = health;
            _damage = damage;
            _attackCooldown = attackCooldown;

            _characterInstance = characterInstance;
            _ability = ability;
        }

        public Character(CharacterData data) : this(data.Avatar, data.Name, data.AttackDistance, 0.3f, 4, data.Health, data.Damage, data.AttackCooldown, data.CharacterInstance, data.Ability)
        {
        }

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public float AttackDistance => _attackDistance;
        //public float SmoothTime => _smoothTime;
        //public float MaxSpeed => _maxSpeed;
        public float Health => _health;
        public float Damage => _damage;
        public float AttackCooldown => _attackCooldown;

        public Ability Ability => _ability;
        public CharacterInstance CharacterInstance => _characterInstance;
    }
}
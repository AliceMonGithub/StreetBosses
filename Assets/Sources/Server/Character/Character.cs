using Server.BusinessLogic;
using Server.PlayerLogic;
using System;
using UnityEngine;

namespace Server.CharacterLogic
{
    public sealed class Character
    {
        public const float UpgradeProgressMultiplier = 0.25f;

        public event Action OnUpgrade;

        private readonly Sprite _avatar;
        private readonly string _name;

        private float _health;
        private float _damage;
        private readonly float _attackDistance;
        private readonly float _attackCooldown;

        private CharacterUpgradeData[] _upgradeData;
        private int _level;
        private float _upgradeProgress;

        private Player _owner;

        private Business _security;
        private Business _manager;

        private readonly CharacterInstance _characterInstance;
        private readonly Ability _ability;

        public Character(
            Sprite avatar,
            string name,
            float attackDistance,
            float health,
            float damage,
            float attackCooldown,
            Player owner,
            CharacterUpgradeData[] upgradeData, 
            CharacterInstance characterInstance, 
            Ability ability)
        {
            _avatar = avatar;
            _name = name;

            _attackDistance = attackDistance;
            _health = health;
            _damage = damage;
            _attackCooldown = attackCooldown;

            _upgradeData = upgradeData;
            _level = 1;
            _upgradeProgress = 0f;

            _owner = owner;

            _security = null;

            _characterInstance = characterInstance;
            _ability = ability;
        }

        public Character(CharacterData data, Player owner = null) : this(
            data.Avatar,
            data.Name,
            data.AttackDistance,
            data.Health,
            data.Damage,
            data.AttackCooldown,
            owner,
            data.UpgradeData,
            data.CharacterInstance,
            data.Ability)
        {

        }

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public float AttackDistance => _attackDistance;
        public float Health => _health;
        public float Damage => _damage;
        public float AttackCooldown => _attackCooldown;

        public Ability Ability => _ability;
      
        public Business Security => _security;
        public Business Manager => _manager;
      
        public CharacterInstance CharacterInstance => _characterInstance;

        public int Level => _level;
        public float UpgradeProgress => _upgradeProgress;
        public int MoneyForUpgrade => (int)(_upgradeData[_level - 1].Cost * UpgradeProgressMultiplier);

        public void SetSecurity(Business security)
        {
            _security = security;
        }

        public void SetManager(Business manager)
        {
            _manager = manager;
        }


        public void TryUpgrade()
        {
            if ((_level - 1) == 2) return;
            if (_owner.Money.Value < MoneyForUpgrade) return;

            _owner.Money.Spend(MoneyForUpgrade);
            _upgradeProgress += UpgradeProgressMultiplier;

            if (_upgradeProgress >= 1f)
            {
                CharacterUpgradeData newData = _upgradeData[_level - 1];

                _damage = newData.Damage;
                _health = newData.Health;

                _level++;
                _upgradeProgress = 0f;
            }

            OnUpgrade?.Invoke();
        }
    }
}
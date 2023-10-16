using System;
using UnityEngine;

namespace Server.CharacterLogic
{
    [Serializable]
    public sealed class CharacterUpgradeData
    {
        [SerializeField] private int _cost;

        [Space]

        [SerializeField] private float _health;
        [SerializeField] private float _damage;

        public int Cost => _cost;

        public float Health => _health;
        public float Damage => _damage;
    }
}
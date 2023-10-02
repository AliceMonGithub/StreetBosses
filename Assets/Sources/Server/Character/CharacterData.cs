using UnityEngine;

namespace Server.CharacterLogic
{
    [CreateAssetMenu(fileName = "Character")]
    public sealed class CharacterData : ScriptableObject
    {
        public const float SmoothTime = 0.3f;
        public const float MaxSpeed = 3.0f;

        [SerializeField] private Sprite _avatar;
        [SerializeField] private string _name;
        
        //[SerializeField] private float _smoothTime;
        //[SerializeField] private float _maxSpeed;

        [Space]

        [SerializeField, Range(2, 20)] private float _damage;
        [SerializeField, Range(50f, 100f)] private float _health;
        [SerializeField, Range(0.3f, 1f)] private float _attackCooldown;
        [SerializeField, Range(1, 4)] private float _attackDistance;

        [Space]

        [SerializeField] private int _cost;

        [Space]

        [SerializeField] private Ability _ability;
        [SerializeField] private CharacterInstance _instance;

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public int Cost => _cost;

        public float Damage => _damage;
        public float Health => _health;
        public float AttackCooldown => _attackCooldown;
        public float AttackDistance => _attackDistance;
        public CharacterInstance CharacterInstance => _instance;
        public Ability Ability => _ability;
    }
}
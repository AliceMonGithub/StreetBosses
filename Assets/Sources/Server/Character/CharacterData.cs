using UnityEngine;

namespace Server.CharacterLogic
{
    [CreateAssetMenu(fileName = "Character")]
    public sealed class CharacterData : ScriptableObject
    {
        [SerializeField] private Sprite _avatar;
        [SerializeField] private string _name;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _attackDistance;

        [SerializeField] private float _smoothTime;
        [SerializeField] private float _maxSpeed;

        [Space]

        [SerializeField] private CharacterInstance _instance;

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public CharacterInstance CharacterInstance => _instance;
    }
}
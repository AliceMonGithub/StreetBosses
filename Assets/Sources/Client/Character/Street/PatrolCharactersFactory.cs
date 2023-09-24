using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Client.CharacterLogic
{
    internal sealed class PatrolCharactersFactory : MonoBehaviour
    {
        [SerializeField] private Vector2 _moveZoneX;
        [SerializeField] private Vector2 _moveZoneY;

        [SerializeField] private float _movementSmooth;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _waitTime;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            Create();
        }

        private void Create()
        {
            foreach (var pair in _player.CharactersList.Characters)
            {
                Character character = pair.Value;

                CharacterInstance instance = Instantiate(character.CharacterInstance, GetSpawnPoint(), Quaternion.identity);
                PatrolCharacter patrolInstance = instance.gameObject.AddComponent<PatrolCharacter>();

                patrolInstance.Init(instance, _moveZoneX, _moveZoneY, _movementSmooth, _maxSpeed, _waitTime);
                patrolInstance.Boot();
            }
        }

        private Vector2 GetSpawnPoint()
        {
            return new(UnityEngine.Random.Range(_moveZoneX.x, _moveZoneX.y), UnityEngine.Random.Range(_moveZoneY.x, _moveZoneY.y));
        }
    }
}
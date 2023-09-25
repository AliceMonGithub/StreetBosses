using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.CharacterLogic
{
    public class BattleCharactersFactory : MonoBehaviour
    {
        [SerializeField] private Vector2 _spawnZoneX;
        [SerializeField] private Vector2 _spawnZoneY;

        [SerializeField] private float _movementSmooth;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _waitTime;

        private Player _player;
        private Dictionary<string, Character> _characters;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
            _characters = _player.CharactersList.Characters;

        }

        private void Awake()
        {
            //��� �������� Dictionary ���� �������(_characters) � ���������
        }

        private void Create()
        {   
            //������ _player.CharactersList.Characters �������� ������ ��������� �� ����������
            foreach (var pair in _player.CharactersList.Characters)
            {
                Character character = pair.Value;

                CharacterInstance instance = Instantiate(character.CharacterInstance, GetSpawnPoint(), Quaternion.identity);
                BattleCharacter battleCharacter = instance.gameObject.AddComponent<BattleCharacter>();

                //battleCharacter.Init(instance, _movementSmooth, _maxSpeed);
                battleCharacter.Boot(); //���� �������� List ��� Dictionary � Enemy
            }
        }

        private Vector2 GetSpawnPoint()
        {
            return new(UnityEngine.Random.Range(_spawnZoneX.x, _spawnZoneX.y), UnityEngine.Random.Range(_spawnZoneY.x, _spawnZoneY.y));
        }
    }
}
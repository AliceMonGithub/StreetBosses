using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.CharacterLogic
{
    public class BattleCharactersFactory : MonoBehaviour
    {
        [SerializeField] private List<Vector2> _firstTeamSpawnPosition;
        [SerializeField] private List<Vector2> _secondTeamSpawnPosition;

        [SerializeField] private float _movementSmooth;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _waitTime;

        private Player _player;
        private Dictionary<string, Character> _characters;

        private int _indexFirstTeamSpawnPoint = 0;
        private int _indexSecondTeamSpawnPoint = 0;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
            _characters = _player.CharactersList.Characters;

        }

        private void Awake()
        {
            
        }
        public BattleCharacter Create(Character character, BattleData battleData, bool isFirstTeam)
        {
            CharacterInstance instance = Instantiate(character.CharacterInstance, GetSpawnPoint(isFirstTeam), Quaternion.identity);
            BattleCharacter battleCharacter = instance.gameObject.AddComponent<BattleCharacter>();

            int indexInTeam;

            if (isFirstTeam)
            {
               indexInTeam = _indexFirstTeamSpawnPoint;
            }
            else
            {
               indexInTeam = _indexSecondTeamSpawnPoint;
            }

            battleCharacter.Init(character, battleData, isFirstTeam, indexInTeam);

            if (isFirstTeam)
            {
                _indexFirstTeamSpawnPoint++;
            }
            else
            {
                _indexSecondTeamSpawnPoint++;
            }
            return battleCharacter;

        }
        public void DestroyCharacter(BattleCharacter character)
        {
            Destroy(character.gameObject);
        }

        private Vector2 GetSpawnPoint(bool isFirstTeam)
        {
            if (isFirstTeam)
            {
                if(_indexFirstTeamSpawnPoint >= 3)
                {
                    _indexFirstTeamSpawnPoint = 0;
                    return _firstTeamSpawnPosition[_indexFirstTeamSpawnPoint];
                }
                else
                {
                    return _firstTeamSpawnPosition[_indexFirstTeamSpawnPoint];
                }                
            }
            else
            {
                if (_indexSecondTeamSpawnPoint >= 3)
                {
                    _indexSecondTeamSpawnPoint = 0;
                    return _secondTeamSpawnPosition[_indexSecondTeamSpawnPoint];
                }
                else
                {
                    return _secondTeamSpawnPosition[_indexSecondTeamSpawnPoint];
                }
            }

        }
    }
}
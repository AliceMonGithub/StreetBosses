using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.CharacterLogic
{
    public class BattleCharactersFactory : MonoBehaviour
    {
        [SerializeField] private List<Transform> _firstTeamSpawnPoints;
        [SerializeField] private List<Transform> _secondTeamSpawnPoints;

        [SerializeField] private Dictionary<Transform, BattleCharacter> _firstTeamSpawns;
        [SerializeField] private Dictionary<Transform, BattleCharacter> _secondTeamSpawns;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _firstTeamSpawns = new(_firstTeamSpawnPoints.Count);

            foreach (Transform spawnPoint in _firstTeamSpawnPoints)
            {
                _firstTeamSpawns.Add(spawnPoint, null);
            }

            _secondTeamSpawns = new(_firstTeamSpawnPoints.Count);

            foreach (Transform spawnPoint in _secondTeamSpawnPoints)
            {
                _secondTeamSpawns.Add(spawnPoint, null);
            }
        }

        public BattleCharacter CreateCharacterInFirstTeam(Character character, BattleData battleData)
        {
            Transform spawnPoint = GetSpawnPoint(_firstTeamSpawns);

            CharacterInstance instance = Instantiate(character.CharacterInstance, spawnPoint.position, Quaternion.identity);
            instance.SpriteRenderer.flipX = true;

            BattleCharacter battleInstance = instance.gameObject.AddComponent<BattleCharacter>();
            battleInstance.Init(character, battleData, true);

            _firstTeamSpawns[spawnPoint] = battleInstance;

            return battleInstance;
        }

        public BattleCharacter CreateCharacterInSecondTeam(Character character, BattleData battleData)
        {
            Transform spawnPoint = GetSpawnPoint(_secondTeamSpawns);

            CharacterInstance instance = Instantiate(character.CharacterInstance, spawnPoint.position, Quaternion.identity);

            BattleCharacter battleInstance = instance.gameObject.AddComponent<BattleCharacter>();
            battleInstance.Init(character, battleData, false);

            _secondTeamSpawns[spawnPoint] = battleInstance;

            return battleInstance;
        }

        private Transform GetSpawnPoint(Dictionary<Transform, BattleCharacter> team)
        {
            foreach (var keyPair in team)
            {
                if(keyPair.Value == null)
                {
                    return keyPair.Key;
                }
            }

            throw new System.Exception("Can't find spawn point");
        }

        public void DestroyCharacter(BattleCharacter character)
        {
            Destroy(character.gameObject);
        }
    }
}
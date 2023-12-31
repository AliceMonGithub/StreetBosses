using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Server.CharacterLogic
{
  public sealed class BattleTeamSelector : MonoBehaviour
  {
        [SerializeField] BattleCharactersFactory _factory;
        [SerializeField] BattleMenu _battleMenu;

        private BattleData _battleData;
        private Player _player;
        private PlayerRuntime _playerRuntime;

        private List<Character> _firstTeamChoise = new List<Character>(3);
        private List<Character> _secondTeamChoise = new List<Character>(3);

        private List<BattleCharacter> _firstTeam = new List<BattleCharacter>(3);
        private List<BattleCharacter> _secondTeam = new List<BattleCharacter>(3);

        private bool _isFighting = true;

        [Inject]
        private void Constructor(Player player, PlayerRuntime playerRuntime)
        {
            _playerRuntime = playerRuntime;
            _player = player;
        }
        private void Awake()
        {
            _battleData = new BattleData(_firstTeam, _secondTeam);
            _battleMenu.Init(_player, this);
            _battleMenu.Boot();
        }

        private void Update()
        {
            if (_battleData.FirstTeamLose & _isFighting)
            {
                _battleMenu.EndFightEvent(false);
                _isFighting = false;
            }
            else if(_battleData.SecondTeamLose & _isFighting)
            {
                _playerRuntime.AttackBusiness.Reset();
                _player.BusinessesList.AddBusiness(_playerRuntime.AttackBusiness);
                _playerRuntime.AttackBusiness.SetOwner(_player);

                _battleMenu.EndFightEvent(true);
                _isFighting = false;
            }
        }

        public void BootAll()
        {
            foreach(BattleCharacter battleCharacterFirst in _firstTeam)
            {
                battleCharacterFirst.Boot();
            }
            foreach(BattleCharacter battleCharacterSecond in _secondTeam)
            {
                battleCharacterSecond.Boot();
            }
        }

        public bool AddCharacterFirstTeam(Character character)
        {
            if (_firstTeamChoise.Count >= 3) return false;

            _firstTeamChoise.Add(character);
            BattleCharacter battleCharacter = _factory.CreateCharacterInFirstTeam(character, _battleData);
            _firstTeam.Add(battleCharacter);
            //_battleMenu.AddAbility(character.Ability);

            return true;
        }

        public void RemoveCharacterFirstTeam(Character character)
        {
            int index = _firstTeamChoise.IndexOf(character);

            _firstTeamChoise.RemoveAt(index);
            _factory.DestroyCharacter(_firstTeam[index]);
            _firstTeam.RemoveAt(index);
        }

        public void AddCharacterSecondTeam(Character character)
        {
            if (_secondTeamChoise.Count >= 3) return;

            _secondTeamChoise.Add(character);
            _secondTeam.Add(_factory.CreateCharacterInSecondTeam(character, _battleData));
        }
    }
}

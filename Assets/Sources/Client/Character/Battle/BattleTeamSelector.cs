using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.CharacterLogic
{
  public sealed class BattleTeamSelector : MonoBehaviour
    {
        [SerializeField] BattleCharactersFactory _factory;
        [SerializeField] BattleMenu _battleMenu;
        [SerializeField] List<CharacterData> characterData; //реяр

        private BattleData _battleData;
        private Player _player;

        private List<Character> _firstTeamChoise = new List<Character>(3);
        private List<Character> _secondTeamChoise = new List<Character>(3);

        private List<BattleCharacter> _firstTeam = new List<BattleCharacter>(3);
        private List<BattleCharacter> _secondTeam = new List<BattleCharacter>(3);

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }
        private void Awake()
        {
            _battleData = new BattleData(_firstTeam, _secondTeam);
            _battleMenu.Init(_player, this);
            _battleMenu.Boot();
        }
        public void OnClick() //реяр
        {

            Character character = new Character(characterData[Random.Range(0, characterData.Count)]);
            AddCharacterFirstTeam(character);
            AddCharacterSecondTeam(character);
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
        public void AddCharacterFirstTeam(Character character)
        {
            if (_firstTeamChoise.Count >= 3) return;

            _firstTeamChoise.Add(character);
            _firstTeam.Add(_factory.CreateCharacterInFirstTeam(character, _battleData));
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

        //public void AddCharacterSecondTeam(Character character)
        //{
        //    if (_secondTeamChoise.Count < 3)
        //    {
        //        _secondTeamChoise.Add(character);
        //        _secondTeam.Add(_factory.CreateCharacterInSecondTeam(character, _battleData));
        //    }
        //    else if (_secondTeamChoise.Count >= 3)
        //    {
        //        _factory.DestroyCharacter(_secondTeam[0]);
        //        _secondTeam.RemoveAt(0);
        //        _secondTeamChoise.RemoveAt(0);

        //        _secondTeamChoise.Add(character);
        //        //_secondTeam.Add(_factory.Create(character, _battleData, false));
        //    }
        //}

    }
}

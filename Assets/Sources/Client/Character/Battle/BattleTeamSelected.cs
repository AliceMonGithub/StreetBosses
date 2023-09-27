using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Server.CharacterLogic
{
  public sealed class BattleTeamSelected : MonoBehaviour
    {
        [SerializeField] BattleCharactersFactory _factory;
        [SerializeField] List<CharacterData> characterData; //реяр

        private BattleData _battleData;

        private List<Character> _firstTeamChoise = new List<Character>(3);
        private List<Character> _secondTeamChoise = new List<Character>(3);

        private List<BattleCharacter> _firstTeam = new List<BattleCharacter>(3);
        private List<BattleCharacter> _secondTeam = new List<BattleCharacter>(3);

        private void Awake()
        {
            _battleData = new BattleData(_firstTeam, _secondTeam);
        }
        public void OnClick() //реяр
        {
            Character character = new Character(characterData[Random.Range(0, characterData.Count)]);
            AddCharacterFirstTeam(character);
            AddCharacterSecondTeam(character);
        }
        public void BootAll() //реяр
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
            if (_firstTeamChoise.Count < 3)
            {
                _firstTeamChoise.Add(character);
                _firstTeam.Add(_factory.Create(character, _battleData, true));
            }
            else if(_firstTeamChoise.Count >= 3)
            {
                _factory.DestroyCharacter(_firstTeam[0]);
                _firstTeam.RemoveAt(0);
                _firstTeamChoise.RemoveAt(0);

                _firstTeamChoise.Add(character);
                _firstTeam.Add(_factory.Create(character, _battleData, true));
            }
        }
        public void AddCharacterSecondTeam(Character character)
        {
            if (_secondTeamChoise.Count < 3)
            {
                _secondTeamChoise.Add(character);
                _secondTeam.Add(_factory.Create(character, _battleData, false));
            }
            else if (_secondTeamChoise.Count >= 3)
            {
                _factory.DestroyCharacter(_secondTeam[0]);
                _secondTeam.RemoveAt(0);
                _secondTeamChoise.RemoveAt(0);

                _secondTeamChoise.Add(character);
                _secondTeam.Add(_factory.Create(character, _battleData, false));
            }
        }

    }
}

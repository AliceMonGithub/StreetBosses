using UnityEngine;
using Server.CharacterLogic;
using UnityEngine.UI;
using TMPro;

namespace Client.MenuesLogic
{
    public sealed class FightCharacterBox : MonoBehaviour
    {
        [SerializeField] TMP_Text _nameText;
        [SerializeField] Image _avatar;

        [Space]

        [SerializeField] Button _button;

        public Character _character;
        private BattleTeamSelector _battleData;

        private bool _removeCharacter;

        public void Init(Character character, BattleTeamSelector battleData)
        {
            _battleData = battleData;
            _character = character;

            _button.onClick.AddListener(OnClick);

            _nameText.text = character.Name;
            _avatar.sprite = character.Avatar;
        }

        private void OnClick()
        {
            if (_removeCharacter)
            {
                DestroyCharacterAtFirstTeam();

                _removeCharacter = false;
            }
            else
            {
                if (AddCharacterToFirstTeam() == false) return;

                _removeCharacter = true;
            }
        }

        private void DestroyCharacterAtFirstTeam()
        {
            _battleData.RemoveCharacterFirstTeam(_character);
        }

        private bool AddCharacterToFirstTeam()
        {
            return _battleData.AddCharacterFirstTeam(_character);
        }
    }
}
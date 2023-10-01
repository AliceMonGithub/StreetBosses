using UnityEngine;
using Server.CharacterLogic;
using UnityEngine.UI;
using TMPro;

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
        if(_removeCharacter)
        {
            print("Remove character");

            DestroyCharacterAtFirstTeam();

            _removeCharacter = false;
        }
        else
        {
            print("Add character");

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

    //public void SwitchButton(Button button)
    //{
    //   if(button = _buttonAddcharacter)
    //   {
    //        _buttonAddcharacter.gameObject.SetActive(false);
    //        _buttonRemovecharacter.gameObject.SetActive(true);
    //   }
    //   else
    //   {
    //        _buttonAddcharacter.gameObject.SetActive(true);
    //        _buttonRemovecharacter.gameObject.SetActive(false);
    //   }
    //}
}

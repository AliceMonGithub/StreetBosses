using UnityEngine;
using Server.CharacterLogic;
using UnityEngine.UI;
using TMPro;

public sealed class BattleSlotMenu : MonoBehaviour
{
    [SerializeField] Button _buttonAddcharacter;
    [SerializeField] Button _buttonRemovecharacter;
    [SerializeField] Image _icon;
    [SerializeField] GameObject _name;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] TextMeshProUGUI _health;
    [SerializeField] TextMeshProUGUI _damage;

    public Character _character;
    private BattleTeamSelected _battleData;

    public void Init(Character character, BattleTeamSelected battleData)
    {
        _battleData = battleData; 
        _character = character;
        _buttonRemovecharacter.gameObject.SetActive(false);
        _buttonAddcharacter.onClick.AddListener(() => _battleData.AddCharacterFirstTeam(_character));
        _level.text = "Level:";
    }

    public void SwitchButton(Button button)
    {
       if(button = _buttonAddcharacter)
       {
            _buttonAddcharacter.gameObject.SetActive(false);
            _buttonRemovecharacter.gameObject.SetActive(true);
       }
       else
       {
            _buttonAddcharacter.gameObject.SetActive(true);
            _buttonRemovecharacter.gameObject.SetActive(false);
       }
    }
}

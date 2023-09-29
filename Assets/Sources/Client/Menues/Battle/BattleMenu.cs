using System.Collections.Generic;
using UnityEngine;
using Server.CharacterLogic;

public sealed class BattleMenu : MonoBehaviour
{
    [SerializeField] GameObject _slotPrefab;

    private Dictionary<string, Character> _characters;
    private BattleTeamSelected _battleData;

    public void Init(Dictionary<string, Character> characters, BattleTeamSelected battleData)
    {
        _characters = characters;
        _battleData = battleData;
    }

    public void Boot()
    {
        AddsCharactersSlotOnMenu();
    }

    private void AddsCharactersSlotOnMenu()    // Для первой команды
    {
        BattleSlotMenu slotMenu;
        foreach (var character in _characters)
        {
            RectTransform transform = UITransform();
            Instantiate(_slotPrefab, transform);
            slotMenu = _slotPrefab.GetComponent<BattleSlotMenu>();
            slotMenu.Init(character.Value, _battleData);
        }
    }

    private RectTransform UITransform() // Допилить метод, расставляющий слоты меню в правильном положении
    {
        return new RectTransform();
    }

    public void StartBattleButton()
    {
        _battleData.BootAll();
    }
}

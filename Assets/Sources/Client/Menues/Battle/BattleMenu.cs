using System.Collections.Generic;
using UnityEngine;
using Server.CharacterLogic;
using Server.PlayerLogic;
using UnityEngine.UI;
using Client.MenuesLogic;
using DG.Tweening;
using Zenject;

public sealed class BattleMenu : MonoBehaviour
{
    [Header("Start Fight Button")]
    [SerializeField] private Button _startFightButton;
    [SerializeField] private RectTransform _startFightButtonTransform;
    [SerializeField] private CanvasGroup _startFightButtonCanvasGroup;
    [SerializeField, Range(0, 10f)] private float _startButtonHideDuration;

    [Header("Character Selector")]

    [SerializeField] private RectTransform _characterSelector;
    [SerializeField] private CanvasGroup _characterSelectorCanvasGroup;
    [SerializeField, Range(0, 10f)] private float _characterSelectorHideDuration;

    [Header("Ability")]
    [SerializeField] private List<Button> _firstTeamAbilityButton = new List<Button>(3);

    [Header("Victory and Lose page")]

    [SerializeField] private VictoryMenu _victoryPage;
    [SerializeField] private LoseMenu _losePage;

    [Space]

    [SerializeField] private FightCharacterBox _boxPrefab;

    [SerializeField] private Transform _root;

    private Player _player;
    private PlayerRuntime _playerRuntime;

    private BattleTeamSelector _battleData;
    public List<Ability> _firstTeamAbilities = new List<Ability>(3);

    [Inject]
    private void Constructor(PlayerRuntime playerRuntime)
    {
        _playerRuntime = playerRuntime;
    }

    public void Init(Player player, BattleTeamSelector battleData)
    {
        _player = player;
        _battleData = battleData;

        _startFightButton.onClick.AddListener(StartFightEvent);
    }

    public void Boot()
    {
        CreateBoxes();
        CreateSecondTeam();
    }

    private void CreateBoxes()
    {
        foreach (var characterPair in _player.CharactersList.Characters)
        {
            Character character = characterPair.Value;

            FightCharacterBox instance = Instantiate(_boxPrefab, _root);
            instance.Init(character, _battleData);
        }
    }

    private void CreateSecondTeam()
    {
        foreach (Character character in _playerRuntime.AttackBusiness.Security)
        {
            if (character == null) continue;

            _battleData.AddCharacterSecondTeam(character);
        }
    }

    public void StartFightEvent()
    {
        HideCharacterSelector();
        HideFightBattleButton();
        _battleData.BootAll();
    }

    public void EndFightEvent(bool victory)
    {
        if (victory)
        {
            _victoryPage.Show();
        }
        else
        {
            _losePage.Show();
        }
    }

    private void HideCharacterSelector()
    {
        _characterSelectorCanvasGroup.alpha = 1;

        _characterSelectorCanvasGroup.DOFade(0, _characterSelectorHideDuration);
        _characterSelector.DOScale(Vector3.zero, _characterSelectorHideDuration);
    }

    private void HideFightBattleButton()
    {
        _startFightButtonCanvasGroup.alpha = 1;

        _startFightButtonCanvasGroup.DOFade(0, _startButtonHideDuration);
        _startFightButtonTransform.DOScale(Vector3.zero, _startButtonHideDuration);
    }

    public void AddAbility(Ability ability)
    {
        _firstTeamAbilities.Add(ability);

        for(int i = 0; i < _firstTeamAbilities.Count; i++)
        {
            _firstTeamAbilityButton[i].onClick.RemoveAllListeners();
            _firstTeamAbilityButton[i].onClick.AddListener(_firstTeamAbilities[i].UseAbility);
        }
    }
}

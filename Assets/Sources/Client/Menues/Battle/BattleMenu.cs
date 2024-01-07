using System.Collections.Generic;
using UnityEngine;
using Server.CharacterLogic;
using Server.PlayerLogic;
using UnityEngine.UI;
using Client.MenuesLogic;
using DG.Tweening;
using Zenject;
using Client.SceneLoading;
using Server.BusinessLogic;
using UnityEditor.Playables;

namespace Client.MenuesLogic
{
    public sealed class BattleMenu : MonoBehaviour
    {
        [Header("Start Fight Button")]
        [SerializeField] private Button _startFightButton;
        [SerializeField] private RectTransform _startFightButtonTransform;
        [SerializeField] private CanvasGroup _startFightButtonCanvasGroup;
        [SerializeField, Range(0, 10f)] private float _startButtonHideDuration;

        [Space]

        [SerializeField] private Button _exitBattleButton;
        [SerializeField] private RectTransform _exitBattleButtonTransform;
        [SerializeField] private CanvasGroup _exitBattleButtonCanvasGroup;
        [SerializeField, Range(0, 10f)] private float _exitBattleButtonHideDuration;

        [Header("Character Selector")]

        [SerializeField] private RectTransform _characterSelector;
        [SerializeField] private CanvasGroup _characterSelectorCanvasGroup;
        [SerializeField, Range(0, 10f)] private float _characterSelectorHideDuration;

        [Header("Ability")]
        [SerializeField] private AbilityIcons _abilityIcons;

        [Header("Victory and Lose page")]

        [SerializeField] private VictoryMenu _victoryPage;
        [SerializeField] private LoseMenu _losePage;

        [Space]

        [SerializeField] private FightCharacterBox _boxPrefab;

        [SerializeField] private Transform _root;

        private Player _player;
        private PlayerRuntime _playerRuntime;

        private SceneLoader _sceneLoader;

        private UnoccupiedBusiness _unoccupiedProperties;

        private BattleTeamSelector _battleData;

        [Inject]
        private void Constructor(PlayerRuntime playerRuntime, SceneLoader sceneLoader, UnoccupiedBusiness unoccupiedProperties)
        {
            _playerRuntime = playerRuntime;
            _sceneLoader = sceneLoader;

            _unoccupiedProperties = unoccupiedProperties;
        }

        public void Init(Player player, BattleTeamSelector battleData)
        {
            _player = player;
            _battleData = battleData;

            _startFightButton.onClick.AddListener(StartFight);
            _exitBattleButton.onClick.AddListener(ExitBattle);
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
            if (_playerRuntime.AttackBusiness.Owner == null)
            {
                foreach (CharacterData character in _unoccupiedProperties.Security)
                {
                    _battleData.AddCharacterSecondTeam(new(character));
                }
            }

            foreach (Character character in _playerRuntime.AttackBusiness.Security)
            {
                if (character == null) continue;

                _battleData.AddCharacterSecondTeam(character);
            }
        }

        public void StartFight()
        {
            HideCharacterSelector();
            HideFightBattleButton();
            HideExitBattleButton();

            _abilityIcons.Init(_player);
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

        private void HideExitBattleButton()
        {
            _exitBattleButtonCanvasGroup.alpha = 1;

            _exitBattleButtonCanvasGroup.DOFade(0, _exitBattleButtonHideDuration);
            _exitBattleButtonTransform.DOScale(Vector3.zero, _exitBattleButtonHideDuration);
        }

        private void ExitBattle()
        {
            _sceneLoader.LoadScene(ScenesNames.StreetSceneName);
        }
    }
}
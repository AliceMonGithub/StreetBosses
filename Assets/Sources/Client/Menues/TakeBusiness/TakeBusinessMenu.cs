using Client.SceneLoading;
using Server.BusinessLogic;
using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class TakeBusinessMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _buyButton;

        [Space]

        [SerializeField] private TMP_Text _costText;

        private SceneLoader _sceneLoader;

        private Player _player;
        private PlayerRuntime _playerRuntime;

        private BusinessData _businessData;

        [Inject]
        private void Constructor(SceneLoader sceneLoader, Player player, PlayerRuntime playerRuntime)
        {
            _sceneLoader = sceneLoader;

            _player = player;
            _playerRuntime = playerRuntime;
        }

        private void Awake()
        {
            _attackButton.onClick.AddListener(LoadBattle);
            _buyButton.onClick.AddListener(TryBuyBusiness);
            _exitButton.onClick.AddListener(Hide);
        }

        private void LoadBattle()
        {
            _sceneLoader.LoadScene(ScenesNames.BattleSceneName);
        }

        private void TryBuyBusiness()
        {
            if(_player.TryBuyBusiness(_playerRuntime.AttackBusiness))
            {
                Hide();
            }
        }

        private void OnEnable()
        {
            _costText.text = _playerRuntime.AttackBusiness.Cost.ToString();
        }
    }
}
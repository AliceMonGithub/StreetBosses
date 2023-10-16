using Client.SceneLoading;
using Server.BusinessLogic;
using Server.PlayerLogic;
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

        private SceneLoader _sceneLoader;
        private PlayerRuntime _playerRuntime;

        private BusinessData _businessData;

        [Inject]
        private void Constructor(SceneLoader sceneLoader, PlayerRuntime playerRuntime)
        {
            _sceneLoader = sceneLoader;
            _playerRuntime = playerRuntime;
        }

        private void Awake()
        {
            _attackButton.onClick.AddListener(LoadBattle);
            _buyButton.onClick.AddListener(() => Debug.Log("Buy"));
            _exitButton.onClick.AddListener(Hide);
        }

        public void Init(BusinessData businessData)
        {
            _businessData = businessData;
        }

        private void LoadBattle()
        {
            _sceneLoader.LoadScene(ScenesNames.BattleSceneName);
        }
    }
}
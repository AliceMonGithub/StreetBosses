using Client.SceneLoading;
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

        [Inject]
        private void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _attackButton.onClick.AddListener(LoadBattle);
            _buyButton.onClick.AddListener(() => Debug.Log("Buy"));
            _exitButton.onClick.AddListener(Hide);
        }

        private void LoadBattle()
        {
            _sceneLoader.LoadScene(ScenesNames.BattleSceneName);
        }
    }
}
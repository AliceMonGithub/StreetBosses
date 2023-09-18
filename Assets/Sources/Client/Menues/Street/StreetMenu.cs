using Client.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class StreetMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [SerializeField] private Button _metropolisButton;
        [SerializeField] private Button _bigTownButton;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
            _metropolisButton.onClick.AddListener(LoadMetropolis);
            _bigTownButton.onClick.AddListener(LoadBigTown);
        }

        private void LoadMetropolis()
        {
            _sceneLoader.LoadScene(ScenesNames.StreetSceneName);
        }

        private void LoadBigTown()
        {
            _sceneLoader.LoadScene(ScenesNames.Street2SceneName);
        }
    }
}
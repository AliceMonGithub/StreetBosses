using Client.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MainMenu
{
    internal sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Contructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(LoadStreet);
        }

        private void LoadStreet()
        {
            _sceneLoader.LoadScene(ScenesNames.StreetSceneName);
        }
    }
}
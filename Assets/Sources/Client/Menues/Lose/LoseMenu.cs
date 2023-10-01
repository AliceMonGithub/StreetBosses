using Client.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class LoseMenu : MonoBehaviour
    {
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _backToStreetButton;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _tryAgainButton.onClick.AddListener(TryAgain);
            _backToStreetButton.onClick.AddListener(BackToStreet);
        }

        private void TryAgain()
        {
            _sceneLoader.LoadScene("Battle");
        }

        private void BackToStreet()
        {
            _sceneLoader.LoadScene("Street");
        }


    }
}
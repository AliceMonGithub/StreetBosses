using Client.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class VictoryMenu : MonoBehaviour
    {
        [SerializeField] private Button _backToStreet;

        private SceneLoader _sceneLoader;

        [Inject]

        private void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _backToStreet.onClick.AddListener(BackToStreet);
        }

        private void BackToStreet()
        {
            _sceneLoader.LoadScene("Street");
        }
    }
}
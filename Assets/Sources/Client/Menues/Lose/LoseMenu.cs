using Client.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

namespace Client.MenuesLogic
{
    internal sealed class LoseMenu : MonoBehaviour
    {
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _backToStreetButton;
        [SerializeField] private RectTransform _transform;
        [SerializeField] CanvasGroup _canvasGroup;

        [Space]

        [SerializeField, Range(0, 10f)] float _showDuration;
        [SerializeField, Range(0, 10f)] float _hideDuration;

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
        public void Hide()
        {
            _canvasGroup.DOFade(0, _hideDuration);
            _transform.DOScale(Vector3.zero, _hideDuration);
        }
        public void Show()
        {
            gameObject.SetActive(true);

            _canvasGroup.alpha = 0;
            _transform.localScale = Vector3.zero;

            _canvasGroup.DOFade(1, _showDuration);
            _transform.DOScale(Vector3.one, _showDuration);
        }

    }
}
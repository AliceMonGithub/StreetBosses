using DG.Tweening;
using UnityEngine;

namespace Client.MenuesLogic
{
    internal class PopupMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private CanvasGroup _canvasGroup;

        [Space]

        [SerializeField] private GameObject _bgGameObject;
        [SerializeField] private CanvasGroup _bgCanvasGroup;

        [Space]

        [SerializeField] private float _showDuration;

        public void Show()
        {
            _transform.localScale = Vector3.zero;
            _canvasGroup.alpha = 0f;
            _bgCanvasGroup.alpha = 0f;

            _root.SetActive(true);
            _bgGameObject.SetActive(true);

            _transform.DOScale(Vector3.one, _showDuration);
            _bgCanvasGroup.DOFade(1, _showDuration);
            _canvasGroup.DOFade(1, _showDuration);
        }

        protected void Hide()
        {
            _transform.DOScale(Vector3.zero, _showDuration);
            _bgCanvasGroup.DOFade(0, _showDuration);
            _canvasGroup.DOFade(0, _showDuration).onComplete += Deactivate;
        }

        private void Deactivate()
        {
            _bgGameObject.SetActive(false);
            _root.SetActive(false);
        }
    }
}
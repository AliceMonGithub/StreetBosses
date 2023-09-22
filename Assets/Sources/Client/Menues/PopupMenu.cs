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

        [SerializeField] private float _showDuration;

        public void Show()
        {
            _transform.localScale = Vector3.zero;
            _canvasGroup.alpha = 0f;

            _root.SetActive(true);

            _transform.DOScale(Vector3.one, _showDuration);
            _canvasGroup.DOFade(1, _showDuration);
        }

        protected void Hide()
        {
            _transform.DOScale(Vector3.zero, _showDuration);
            _canvasGroup.DOFade(0, _showDuration).onComplete += Deactivate;
        }

        private void Deactivate()
        {
            _root.SetActive(false);
        }
    }
}
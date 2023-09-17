using System;
using UnityEngine;
using DG.Tweening;

namespace Client.SceneLoading
{
    internal sealed class LoadCurtain : MonoBehaviour
    {
        [SerializeField] private GameObject _root; 
        [SerializeField] private CanvasGroup _canvasGroup;

        [Space]

        [SerializeField] private float _fadeDuration;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Show(Action onShowed)
        {
            _canvasGroup.alpha = 0;

            _root.SetActive(true);

            var tween = _canvasGroup.DOFade(1f, _fadeDuration);

            if (onShowed != null)
            {
                tween.onComplete += onShowed.Invoke;
            }
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0f, _fadeDuration).onComplete += Deactivate; 
        }

        private void Deactivate()
        {
            _root.SetActive(false);
        }
    }
}
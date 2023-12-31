using DG.Tweening;
using Server.BusinessLogic;
using Server.NotificationLogic;
using Server.PlayerLogic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class NotificationPopup : MonoBehaviour
    {
        [SerializeField] private RectTransform _showPoint;
        [SerializeField] private RectTransform _hidePoint;
        [SerializeField] private float _animationDuration;
        [SerializeField] private float _waitToHideTime;

        [Space]

        [SerializeField] private RectTransform _transform;
        [SerializeField] private TMP_Text _messageText;

        private List<Notification> _notificationToShow;
        private bool _showingPopup;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _notificationToShow = new();

            _transform.position = _hidePoint.position;

            _player.NotificationList.OnNotificationAdded += CatchNotification;
        }

        private void CatchNotification(Notification notification)
        {
            _notificationToShow.Add(notification);

            TryShowNextNotification();
        }

        private void TryShowNextNotification()
        {
            if (_showingPopup || _notificationToShow.Count == 0) return;

            _showingPopup = true;

            Notification notification = _notificationToShow[0];

            _messageText.text = notification.Message;

            _transform.DOMove(_showPoint.position, _animationDuration).onComplete += () => StartCoroutine(HidePopup(notification));
        }

        private IEnumerator HidePopup(Notification notification)
        {
            yield return new WaitForSeconds(_waitToHideTime);

            _notificationToShow.Remove(notification);
            _transform
                .DOMove(_hidePoint.position, _animationDuration)
                .onComplete += () =>
                {
                    _showingPopup = false;

                    TryShowNextNotification();
                };
        }
    }
}
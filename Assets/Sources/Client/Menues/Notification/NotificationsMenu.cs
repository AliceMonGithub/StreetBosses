using Server.NotificationLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class NotificationsMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private NotificationBox _boxPrefab;
        [SerializeField] private Transform _instancingRoot;

        private List<NotificationBox> _instanties;

        private Player _player;

        [Inject]
        private void Contructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _instanties = new();

            _exitButton.onClick.AddListener(Hide);
        }

        private void OnEnable()
        {
            CreateBoxes();
        }

        private void CreateBoxes()
        {
            foreach (Notification notification in _player.NotificationList.Notifications)
            {
                NotificationBox instance = Instantiate(_boxPrefab, _instancingRoot);
                instance.Init(notification);

                _instanties.Add(instance);
            }
        }

        private void OnDisable()
        {
            DestroyBoxes();
        }

        private void DestroyBoxes()
        {
            for (int i = 0; i < _instanties.Count; i++)
            {
                _instanties[i].Destroy();
            }

            _instanties.Clear();
        }
    }
}
using Server.PlayerLogic;
using Server.TradeLogic;
using Sources.CameraLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class TradesMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private TradeBox _boxPrefab;
        [SerializeField] private Transform _instancingRoot;

        private List<TradeBox> _instancies;

        private Player _player;
        private CameraMovement _playerCamera;

        [Inject]
        private void Constructor(Player player, CameraMovement playerCamera)
        {
            _player = player;
            _playerCamera = playerCamera;
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);

            _instancies = new();
        }

        private void OnEnable()
        {
            CreateUIBoxes();
        }

        private void CreateUIBoxes()
        {
            foreach (Trade trade in _player.TradesList.Trades)
            {
                TradeBox instance = Instantiate(_boxPrefab, _instancingRoot);

                instance.Init(trade, this, _player, _playerCamera);

                _instancies.Add(instance);
            }
        }

        public void HideMenu()
        {
            Hide();
        }

        private void OnDisable()
        {
            DestroyUIBoxes();
        }

        private void DestroyUIBoxes()
        {
            for (int i = 0; i < _instancies.Count; i++)
            {
                if (_instancies[i] == null) continue;

                _instancies[i].Destroy();
            }

            _instancies.Clear();
        }
    }
}
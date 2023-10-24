using Server.PlayerLogic;
using Server.TradeLogic;
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

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }

        private void OnEnable()
        {
            CreateUIBoxes();
        }

        private void CreateUIBoxes()
        {
            foreach (Trade trade in _player.TradesList.Trades)
            {

            }
        }

        private void OnDisable()
        {
            DestroyUIBoxes();
        }

        private void DestroyUIBoxes()
        {

        }
    }
}
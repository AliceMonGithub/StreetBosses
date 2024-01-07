using DG.Tweening;
using Server.PlayerLogic;
using Server.TradeLogic;
using Sources.CameraLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class TradeBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tradeText;

        [Space]

        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _declineButton;
        [SerializeField] private Button _showButton;

        private Player _player;
        private CameraMovement _playerCamera;

        private Trade _trade;
        private TradesMenu _tradeMenu;

        public void Init(Trade trade, TradesMenu tradeMenu, Player player, CameraMovement playerCamera)
        {
            _trade = trade;
            _tradeMenu = tradeMenu;

            _player = player;
            _playerCamera = playerCamera;

            _acceptButton.onClick.AddListener(Accept);
            _declineButton.onClick.AddListener(Decline);
            _showButton.onClick.AddListener(Show);

            UpdateAllUI();
        }

        private void Accept()
        {
            _trade.Accept();

            Destroy(gameObject);
        }

        private void Decline()
        {
            _trade.Decline();

            Destroy(gameObject);
        }

        private void Show()
        {
            _playerCamera.MoveToBusiness(_trade.Business);

            _tradeMenu.HideMenu();
        }

        private void UpdateAllUI()
        {
            _tradeText.text = $"{_trade.From.Nickname} want to buy your business {_trade.Money}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _acceptButton.onClick.RemoveListener(Accept);
            _declineButton.onClick.RemoveListener(Decline);
        }
    }
}
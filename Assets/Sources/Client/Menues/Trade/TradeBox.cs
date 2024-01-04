using DG.Tweening;
using Server.PlayerLogic;
using Server.TradeLogic;
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

        private Player _player;
        private Camera _playerCamera;

        private Trade _trade;

        [Inject]
        private void Constructor(Player player, Camera playerCamera)
        {
            _player = player;
            _playerCamera = playerCamera;
        }

        public void Init(Trade trade)
        {
            _trade = trade;

            _acceptButton.onClick.AddListener(Accept);
            _declineButton.onClick.AddListener(Decline);

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
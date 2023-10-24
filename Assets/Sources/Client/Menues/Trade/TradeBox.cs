using Server.TradeLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class TradeBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tradeText;

        [Space]

        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _declineButton;

        private Trade _trade;

        public void Init(Trade trade)
        {
            _trade = trade;

            UpdateAllUI();
        }

        private void UpdateAllUI()
        {
            _tradeText.text = $"Player {_trade.From.Nickname} want to buy {_trade.Business.Name} for {_trade.Money}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
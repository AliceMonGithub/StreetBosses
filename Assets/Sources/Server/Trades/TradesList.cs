using Server.BusinessLogic;
using Server.PlayerLogic;
using System;
using System.Collections.Generic;

namespace Server.TradeLogic
{

    public sealed class TradesList
    {
        public event Action<Trade> OnTradeAdded;

        private List<Trade> _trades;

        public TradesList()
        {
            _trades = new();
        }

        public IReadOnlyList<Trade> Trades => _trades;

        public void CreateTrade(Business business, Player from, Player to, int money)
        {
            AddTrade(new(from, to, business, money));
        }

        private void AddTrade(Trade trade)
        {
            _trades.Add(trade);

            OnTradeAdded?.Invoke(trade);
        }

        public void RemoveTrade(Trade trade)
        {
            _trades.Remove(trade);
        }
    }
}
using System.Collections.Generic;

namespace Server.TradeLogic
{

    public sealed class TradesList
    {
        private List<Trade> _trades;

        public TradesList()
        {
            _trades = new();
        }

        public IReadOnlyList<Trade> Trades => _trades;

        public void AddTrade(Trade trade)
        {
            _trades.Add(trade);
        }

        public void RemoveTrade(Trade trade)
        {
            _trades.Remove(trade);
        }
    }
}
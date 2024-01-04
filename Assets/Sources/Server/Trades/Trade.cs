using Server.BusinessLogic;
using Server.PlayerLogic;
using System;

namespace Server.TradeLogic
{
    public sealed class Trade
    {
        public event Action OnDecline;

        private Player _from;
        private Player _to;

        private Business _business;
        private int _money;

        public Trade(Player from, Player to, Business business, int money)
        {
            _from = from;
            _to = to;
            _business = business;
            _money = money;
        }

        public Player From => _from;
        public Player To => _to;

        public Business Business => _business;
        public int Money => _money;

        public void Accept()
        {
            _from.BusinessesList.AddBusiness(_business);
            _to.BusinessesList.RemoveBusiness(_business);

            _to.Money.Add(_money);

            _business.SetOwner(_from);

            _to.TradesList.RemoveTrade(this);
        }

        public void Decline()
        {
            _to.TradesList.RemoveTrade(this);

            OnDecline?.Invoke();
        }
    }
}
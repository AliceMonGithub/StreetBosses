using Server.BusinessLogic;
using Server.PlayerLogic;

namespace Server.BotLogic
{
    public sealed class TrackPlayersAction : BotAction
    {
        private Player _player;
        private Player _bot;

        public TrackPlayersAction(Player player, Player bot)
        {
            _player = player;
            _bot = bot;
        }

        public override void Do(Bot bot)
        {
            _player.BusinessesList.OnBusinessAdded += SendTrade;
        }

        private void SendTrade(Business business)
        {
            _player.TradesList.CreateTrade(business, _bot, _player, business.Cost * 2);
        }
    }
}
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Linq;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class SendTradeBotAction : BotAction
    {
        private Player _player;

        public SendTradeBotAction(Player player)
        {
            _player = player;
        }

        public override void Do(Bot bot)
        {
            if (_player.BusinessesList.Businesses.Count == 0) return;

            Business target = _player.BusinessesList.Businesses.ElementAt(Random.Range(0, _player.BusinessesList.Businesses.Count)).Value;


        }
    }
}
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class DefaultBotBrain : BotBrain
    {
        public DefaultBotBrain(Bot bot, BusinessData[] allBusinesses, List<Player> players) : base(bot, allBusinesses, players)
        {
        }

        public override BotAction CalculateStep()
        {
            return new LookForBusinessBotAction(AllBusinesses[Random.Range(0, AllBusinesses.Length)]);
        }
    }
}
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class DefaultBotBrain : BotBrain
    {
        private BusinessData[] _allBusinesses;
        private List<Player> _players;

        public DefaultBotBrain(BusinessData[] allBusinesses, List<Player> players)
        {
            _allBusinesses = allBusinesses;
            _players = players;
        }

        public override BotAction CalculateStep()
        {
            return new LookForBusinessBotAction(_allBusinesses[Random.Range(0, _allBusinesses.Length)]);
        }
    }
}
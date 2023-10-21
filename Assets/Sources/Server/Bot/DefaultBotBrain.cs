using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class DefaultBotBrain : BotBrain
    {
        private CharacterData _defaultCharacter;

        public DefaultBotBrain(Bot bot, BusinessData[] allBusinesses, List<Player> players, CharacterData defaultCharacter) : base(bot, allBusinesses, players)
        {
            _defaultCharacter = defaultCharacter;
        }

        public override BotAction CalculateStep()
        {
            return new LookForBusinessBotAction(AllBusinesses[Random.Range(0, AllBusinesses.Length)], _defaultCharacter);
        }
    }
}
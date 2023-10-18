using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public abstract class BotBrain
    {
        protected BusinessData[] AllBusinesses;
        protected List<Player> Players;

        protected Bot Bot;

        public BotBrain(Bot bot, BusinessData[] allBusinesses, List<Player> players)
        {
            AllBusinesses = allBusinesses;
            Players = players;

            Bot = bot;
        }

        public abstract BotAction CalculateStep();

        public bool CheckBusinessForOwning(string name)
        {
            foreach (Player player in Players)
            {
                if(player.BusinessesList.ContainsBusiness(name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
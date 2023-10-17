using Server.BusinessLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public abstract class BotBrain
    {
        public abstract BotAction CalculateStep();
    }
}
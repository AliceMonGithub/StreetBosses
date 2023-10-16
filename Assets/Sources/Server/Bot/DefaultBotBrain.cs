using UnityEngine;

namespace Server.BotLogic
{
    public sealed class DefaultBotBrain : BotBrain
    {
        public override BotAction CalculateStep()
        {
            Debug.Log("Calculate step");

            return null;
        }
    }
}
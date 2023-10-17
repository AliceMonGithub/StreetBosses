using Server.BusinessLogic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class LookForBusinessBotAction : BotAction
    {
        private BusinessData _target;

        public LookForBusinessBotAction(BusinessData target)
        {
            _target = target;
        }

        public override void Do()
        {
            

            Debug.Log("Looking for business");
        }
    }
}
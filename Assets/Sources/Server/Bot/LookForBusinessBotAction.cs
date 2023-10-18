using Server.BusinessLogic;
using Server.MoneyLogic;
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

        public override void Do(Bot bot)
        {
            if (_target.Cost > bot.Money.Value) return;
            if (bot.CheckBusinessForOwning(_target.Name)) return;

            Debug.Log(bot.Money.Value);

            Business business = new(_target, null);

            bot.Money.Spend(0);//(business.Cost);
            bot.BusinessesList.AddBusiness(business);
            business.SetOwner(bot);

            _target.Create();

            Debug.Log("Looking for business");
        }
    }
}
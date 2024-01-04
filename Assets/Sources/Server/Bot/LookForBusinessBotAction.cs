using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.MoneyLogic;
using UnityEngine;

namespace Server.BotLogic
{

    public sealed class LookForBusinessBotAction : BotAction
    {
        private BusinessData _target;
        private CharacterData _defaultCharacter;

        public LookForBusinessBotAction(BusinessData target, CharacterData defaultCharacter)
        {
            _target = target;
            _defaultCharacter = defaultCharacter;
        }

        public override void Do(Bot bot)
        {
            if (_target.Cost > bot.Money.Value) return;
            if (bot.CheckBusinessForOwning(_target.Name)) return;

            Business business = new(_target, null);

            bot.Money.Spend(business.Cost);
            bot.BusinessesList.AddBusiness(business);
            business.Reset();
            business.SetOwner(bot);

            Character security = new(_defaultCharacter, bot);

            business.SetSecurity(0, security);
            bot.CharactersList.AddCharacter(security);

            _target.Create(business);
        }
    }
}
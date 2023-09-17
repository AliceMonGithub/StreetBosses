using Server.BusinessLogic;

namespace Server.PlayerLogic
{
    internal sealed class PlayerRuntime
    {
        private BusinessBlank _attackBusiness;

        public void SetAttackTarget(BusinessBlank attackBusiness)
        {
            _attackBusiness = attackBusiness;
        }

        public BusinessBlank AttackBusiness => _attackBusiness;
    }
}
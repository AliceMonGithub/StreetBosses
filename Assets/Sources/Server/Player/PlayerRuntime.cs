using Server.BusinessLogic;

namespace Server.PlayerLogic
{
    public sealed class PlayerRuntime
    {
        private BusinessBlank _attackBusiness;

        public void SetAttackTarget(BusinessBlank attackBusiness)
        {
            _attackBusiness = attackBusiness;
        }

        public BusinessBlank AttackBusiness => _attackBusiness;
    }
}
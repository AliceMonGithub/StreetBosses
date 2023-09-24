using Server.BusinessLogic;

namespace Server.PlayerLogic
{
    public sealed class PlayerRuntime
    {
        private BusinessData _attackBusiness;

        public void SetAttackTarget(BusinessData attackBusiness)
        {
            _attackBusiness = attackBusiness;
        }

        public BusinessData AttackBusiness => _attackBusiness;
    }
}
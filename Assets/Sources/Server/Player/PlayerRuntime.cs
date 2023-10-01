using Server.BusinessLogic;
using UnityEngine;

namespace Server.PlayerLogic
{
    public sealed class PlayerRuntime
    {
        private BusinessData _attackBusiness;

        public void SetAttackTarget(BusinessData attackBusiness)
        {
            _attackBusiness = attackBusiness;
            Debug.Log(_attackBusiness);
        }

        public BusinessData AttackBusiness => _attackBusiness;
    }
}
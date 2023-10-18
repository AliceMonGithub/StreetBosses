using Server.BusinessLogic;
using UnityEngine;

namespace Server.PlayerLogic
{
    public sealed class PlayerRuntime
    {
        private Business _attackBusiness;

        public void SetAttackTarget(Business attackBusiness)
        {
            _attackBusiness = attackBusiness;
        }

        public Business AttackBusiness => _attackBusiness;
    }
}
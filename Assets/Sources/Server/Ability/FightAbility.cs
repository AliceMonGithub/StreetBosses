using Server.CharacterLogic;
using UnityEngine;

namespace Client.AbilityLogic
{
    public abstract class FightAbility : Ability
    {
        private Character _target;

        public FightAbility(Character target, Sprite image) : base(image)
        {
            _target = target;
        }
    }
}
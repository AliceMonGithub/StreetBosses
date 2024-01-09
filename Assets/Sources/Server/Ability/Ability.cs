using Server.CharacterLogic;
using UnityEngine;

namespace Client.AbilityLogic
{
    public class Ability
    {
        public readonly Sprite Image;

        public Ability(Sprite image)
        {
            Image = image;
        }

        public Ability(AbilityData abilityData)
        {
            Image = abilityData.Image;
        }

        public virtual void Use(Character target)
        {
            
        }
    }
}
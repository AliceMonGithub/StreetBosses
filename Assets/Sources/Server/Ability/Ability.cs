using UnityEngine;

namespace Client.AbilityLogic
{
    public abstract class Ability
    {
        public readonly Sprite Image;

        public Ability(Sprite image)
        {
            Image = image;
        }

        public abstract void Use();
    }
}
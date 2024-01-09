using Client.AbilityLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    public sealed class AbilityIcon : MonoBehaviour
    {
        [SerializeField] private Image _abilityImage;

        private Ability _ability;

        public void Init(Ability ability)
        {
            _ability = ability;

            Render();
        }

        private void Render()
        {
            _abilityImage.sprite = _ability.Image;
        }
    }
}
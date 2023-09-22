using Server.BusinessLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class BusinessButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private BusinessMenu _businessMenu;
        private Business _business;

        public void Initialize(Business business, BusinessMenu businessMenu)
        {
            _businessMenu = businessMenu;
            _business = business;

            _button.onClick.AddListener(_businessMenu.Show);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class UnderMenu : MonoBehaviour
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _capoButton;
        [SerializeField] private Button _streetButton;
        [SerializeField] private Button _officeButton;
        [SerializeField] private Button _tradeButton;
        [SerializeField] private Button _notificationButton;

        private ShopMenu _shopMenu;
        private CapoMenu _capoMenu;
        private StreetMenu _streetMenu;

        [Inject]
        private void Constructor(ShopMenu shopMenu, CapoMenu capoMenu, StreetMenu streetMenu)
        {
            _shopMenu = shopMenu;
            _capoMenu = capoMenu;
            _streetMenu = streetMenu;
        }

        private void Awake()
        {
            _shopButton.onClick.AddListener(_shopMenu.Show);
            _capoButton.onClick.AddListener(_capoMenu.Show);
            _streetButton.onClick.AddListener(_streetMenu.Show);
        }
    }
}
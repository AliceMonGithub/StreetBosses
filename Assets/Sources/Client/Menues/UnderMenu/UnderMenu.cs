using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class UnderMenu : MonoBehaviour
    {
        [SerializeField] private Button _shopButton;

        private ShopMenu _shopMenu;

        [Inject]
        private void Constructor(ShopMenu shopMenu)
        {
            _shopMenu = shopMenu;
        }

        private void Awake()
        {
            _shopButton.onClick.AddListener(_shopMenu.Show);
        }
    }
}
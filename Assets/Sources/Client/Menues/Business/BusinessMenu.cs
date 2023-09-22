using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class BusinessMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }
    }
}
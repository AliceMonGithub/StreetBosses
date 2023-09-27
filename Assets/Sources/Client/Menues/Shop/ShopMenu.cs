using Server.CharacterLogic;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class ShopMenu : PopupMenu
    {
        [SerializeField] private CharacterData _aliceData;
        [SerializeField] private CharacterData _alineData;

        [SerializeField] private CharacterBuyBox _aliceButton;
        [SerializeField] private CharacterBuyBox _alineButton;

        [SerializeField] private Button _exitButton;

        private Player _player;

        [Inject]
        private void Contructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _aliceButton.Init(_aliceData, _player);
            _alineButton.Init(_alineData, _player);

            _exitButton.onClick.AddListener(Hide);
        }
    }
}
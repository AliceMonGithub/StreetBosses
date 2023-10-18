using Server.BotLogic;
using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class AnotherPlayerBusinessButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nicknameText;

        [Space]

        [SerializeField] private Button _button;

        private TakeBusinessMenu _takeBusinessMenu;
        private PlayerRuntime _playerRuntime;
        private Bot _bot;

        [Inject]
        private void Constructor(TakeBusinessMenu takeBusinessMenu, PlayerRuntime playerRuntime)
        {
            _takeBusinessMenu = takeBusinessMenu;
            _playerRuntime = playerRuntime;
        }

        public void Init(Bot bot)
        {
            _bot = bot;

            //_button.onClick.AddListener(ShowTakeBusinessMenu);

            UpdateAllUI();
        }

        private void ShowTakeBusinessMenu()
        {
            //_playerRuntime.SetAttackTarget()

            //_takeBusinessMenu.
        }

        private void UpdateAllUI()
        {
            _nicknameText.name = _bot.Nickname;
        }
    }
}
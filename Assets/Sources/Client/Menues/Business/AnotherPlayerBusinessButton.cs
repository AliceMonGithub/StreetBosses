using Server.BotLogic;
using Server.BusinessLogic;
using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class AnotherPlayerBusinessButton : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private TMP_Text _nicknameText;
        [SerializeField] private Button _button;

        [Space]

        [SerializeField] private BusinessButton _businessButton;

        private TakeBusinessMenu _takeBusinessMenu;
        private PlayerRuntime _playerRuntime;
        private BusinessMenu _businessMenu;
        private Transform _canvasRoot;
        private Player _player;
        private Player _bot;

        private Business _business;

        public void Init(Player bot, Player player, Business business, TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, PlayerRuntime playerRuntime, Transform canvasRoot)
        {
            _bot = bot;
            _player = player;
            _business = business;
            _canvasRoot = canvasRoot;
            _businessMenu = businessMenu;
            _playerRuntime = playerRuntime;
            _takeBusinessMenu = takeBusinessMenu;

            _button.onClick.AddListener(ShowTakeBusinessMenu);

            UpdateAllUI();
            SubscribeToBusiness();
        }

        private void ShowTakeBusinessMenu()
        {
            _playerRuntime.SetAttackTarget(_business);

            _takeBusinessMenu.Show();
        }

        private void UpdateAllUI()
        {
            _nicknameText.name = _bot.Nickname;
        }

        private void SubscribeToBusiness()
        {
            _business.OnSetOwner += InstantiateBusinessButton;
        }

        private void InstantiateBusinessButton()
        {
            try
            {
                if (string.IsNullOrEmpty(this.name))
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            BusinessButton instance = Instantiate(_businessButton, _root.position, Quaternion.identity, _canvasRoot);
            instance.Initialize(_business, _businessMenu, _player, _canvasRoot);

            Destroy(gameObject);
        }
    }
}
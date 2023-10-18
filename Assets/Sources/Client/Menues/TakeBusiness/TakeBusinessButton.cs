using Server.BotLogic;
using Server.BusinessLogic;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class TakeBusinessButton : MonoBehaviour
    {
        [SerializeField] private Transform _canvasRoot;
        [SerializeField] private Transform _root;
        [SerializeField] private Button _button;
        [SerializeField] private BusinessButton _businessButtonPrefab;
        [SerializeField] private AnotherPlayerBusinessButton _anotherPlayerBusinessButtonPrefab; 

        [Space]

        [SerializeField] private BusinessData _blank;

        private TakeBusinessMenu _takeBusinessMenu;
        private BusinessMenu _businessMenu;
        private Player _player;
        private Bot _bot;
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Constructor(TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, Player player, Bot bot, PlayerRuntime playerRuntime)
        {
            _takeBusinessMenu = takeBusinessMenu;
            _businessMenu = businessMenu;
            _player = player;
            _bot = bot;
            _playerRuntime = playerRuntime;
        }

        private void Awake()
        {
            TryFindOwner();

            _button.onClick.AddListener(SelectTarget);

            SubscribeToTaking();
        }

        private void SubscribeToTaking()
        {
            _blank.OnCreated += TryFindOwner;
        }

        private void TryFindOwner()
        {
            if (_player.BusinessesList.ContainsBusiness(_blank.Name, out Business playerBusiness))
            {
                CreateBusinessButton(playerBusiness);

                return;
            }

            if(_bot.BusinessesList.ContainsBusiness(_blank.Name))
            {
                CreateAnotherPlayerBusinessButton();
            }
        }

        private void CreateBusinessButton(Business business)
        {
            BusinessButton button = Instantiate(_businessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);

            button.Initialize(business, _businessMenu, _player);

            Destroy(gameObject);
        }

        private void CreateAnotherPlayerBusinessButton()
        {
            AnotherPlayerBusinessButton button = Instantiate(_anotherPlayerBusinessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);

            button.Init(_bot);

            Destroy(gameObject);
        }

        private void SelectTarget()
        {
            if(_blank == null)
            {
                throw new System.NullReferenceException();
            }
            _playerRuntime.SetAttackTarget(_blank);

            _takeBusinessMenu.Show();
        }
    }
}
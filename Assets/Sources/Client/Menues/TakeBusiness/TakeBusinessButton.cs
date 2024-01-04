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

        private Business _businessInstance;

        [Inject]
        private void Constructor(TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, Player player, Bot bot, PlayerRuntime playerRuntime)
        {
            _takeBusinessMenu = takeBusinessMenu;
            _businessMenu = businessMenu;
            _player = player;
            _bot = bot;
            _playerRuntime = playerRuntime;
        }

        public void Init(TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, Player player, Bot bot, PlayerRuntime playerRuntime)
        {
            _takeBusinessMenu = takeBusinessMenu;
            _businessMenu = businessMenu;
            _player = player;
            _bot = bot;
            _playerRuntime = playerRuntime;

            TryFindOwner();
        }

        private void Awake()
        {
            TryFindOwner();

            _button.onClick.AddListener(SelectTarget);

            _blank.OnCreated += TryFindOwner;
        }

        private void SelectTarget()
        {
            if (_blank == null)
            {
                throw new System.NullReferenceException();
            }

            Business businessInstance = new(_blank, null);

            _playerRuntime.SetAttackTarget(businessInstance);

            if (_businessInstance != null)
            {
                _businessInstance.OnSetOwner -= TryFindOwner;
            }

            _businessInstance = businessInstance;
            _businessInstance.OnSetOwner += TryFindOwner;

            _takeBusinessMenu.Show();
        }

        private void TryFindOwner()
        {
            if (_player == null) return;

            if (_player.BusinessesList.ContainsBusiness(_blank.Name, out Business playerBusiness))
            {
                CreateBusinessButton(playerBusiness);

                return;
            }

            if (_bot.BusinessesList.ContainsBusiness(_blank.Name, out Business botBusiness))
            {
                CreateAnotherPlayerBusinessButton(botBusiness);
            }
        }

        private void CreateBusinessButton(Business business)
        {
            try
            {
                if(string.IsNullOrEmpty(this.name))
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            BusinessButton button = Instantiate(_businessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);

            button.Initialize(business, _businessMenu, _player, _canvasRoot);

            Destroy(gameObject);
        }

        private void CreateAnotherPlayerBusinessButton(Business business)
        {
            if (_root == null) return;

            AnotherPlayerBusinessButton button = Instantiate(_anotherPlayerBusinessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);
            button.Init(_bot, _player, business, _takeBusinessMenu, _businessMenu, _playerRuntime, _canvasRoot);

            Destroy(gameObject);
        }
    }
}
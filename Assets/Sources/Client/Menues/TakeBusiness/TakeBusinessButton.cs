using Server.BusinessLogic;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Client.MenuesLogic
{
    internal sealed class TakeBusinessButton : MonoBehaviour
    {
        [SerializeField] private Transform _canvasRoot;
        [SerializeField] private Transform _root;
        [SerializeField] private Button _button;
        [SerializeField] private BusinessButton _businessButtonPrefab;

        [Space]

        [SerializeField] private BusinessData _blank;

        private TakeBusinessMenu _takeBusinessMenu;
        private BusinessMenu _businessMenu;
        private Player _player;
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Constructor(TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, Player player, PlayerRuntime playerRuntime)
        {
            _takeBusinessMenu = takeBusinessMenu;
            _businessMenu = businessMenu;
            _player = player;
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
            if (_player.BusinessesList.ContainsBusiness(_blank.Name, out Business business))
            {
                CreateBusinessButton(business);
            }
        }

        private void CreateBusinessButton(Business business)
        {
            BusinessButton button = Instantiate(_businessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);

            button.Initialize(business, _businessMenu, _player);

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
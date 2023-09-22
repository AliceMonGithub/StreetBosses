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

        [Space]

        [SerializeField] private BusinessBlank _blank;

        private TakeBusinessMenu _takeBusinessMenu;
        private BusinessMenu _businessMenu;
        private IReadOnlyPlayer _player;
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Constructor(TakeBusinessMenu takeBusinessMenu, BusinessMenu businessMenu, IReadOnlyPlayer player, PlayerRuntime playerRuntime)
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
        }

        private void TryFindOwner()
        {
            if (_player.BusinessesList.ContainsBusiness(_blank.Name, out Business business))
            {
                BusinessButton button = Instantiate(_businessButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);

                button.Initialize(business, _businessMenu);

                Destroy(gameObject);
            }
        }

        private void SelectTarget()
        {
            _playerRuntime.SetAttackTarget(_blank);

            _takeBusinessMenu.Show();
        }
    }
}
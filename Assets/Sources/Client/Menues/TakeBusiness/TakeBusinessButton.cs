using Server.BusinessLogic;
using Server.PlayerLogic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class TakeBusinessButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [Space]

        [SerializeField] private BusinessBlank _blank;

        private TakeBusinessMenu _menu;
        private IReadOnlyPlayer _player;
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Constructor(TakeBusinessMenu menu, IReadOnlyPlayer player, PlayerRuntime playerRuntime)
        {
            _menu = menu;
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
            if (_player.BusinessesList.ContainsBusiness(_blank.Name))
            {
                print("Player have this business");
            }
        }

        private void SelectTarget()
        {
            _playerRuntime.SetAttackTarget(_blank);

            _menu.Show();
        }
    }
}
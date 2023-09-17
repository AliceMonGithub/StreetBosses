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

        [SerializeField] private BusinessBlank _target;

        private TakeBusinessMenu _menu;
        private PlayerRuntime _playerRuntime;

        [Inject]
        private void Constructor(TakeBusinessMenu menu, PlayerRuntime playerRuntime)
        {
            _menu = menu;
            _playerRuntime = playerRuntime;
        }

        private void Awake()
        {
            _button.onClick.AddListener(SelectTarget);
        }

        private void SelectTarget()
        {
            _playerRuntime.SetAttackTarget(_target);

            _menu.Show();
        }
    }
}
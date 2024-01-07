using Client.MenuesLogic;
using Sources.CameraLogic;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class StreetInstaller : MonoInstaller
    {
        [SerializeField] private TakeBusinessMenu _takeBusinessMenu;
        [SerializeField] private ShopMenu _shopMenu;
        [SerializeField] private CapoMenu _capoMenu;
        [SerializeField] private StreetMenu _streetMenu;
        [SerializeField] private OfficeMenu _officeMenu;
        [SerializeField] private NotificationsMenu _notificationMenu;
        [SerializeField] private BusinessMenu _businessMenu;
        [SerializeField] private QuestsMenu _questsMenu;
        [SerializeField] private TradesMenu _tradesMenu;
        [SerializeField] private CharacterUpgradeMenu _characterUpgradeMenu;

        [Space]

        [SerializeField] private CameraMovement _playerCamera;

        public override void InstallBindings()
        {
            Container.Bind<TakeBusinessMenu>().FromInstance(_takeBusinessMenu).AsSingle();
            Container.Bind<ShopMenu>().FromInstance(_shopMenu).AsSingle();
            Container.Bind<CapoMenu>().FromInstance(_capoMenu).AsSingle();
            Container.Bind<StreetMenu>().FromInstance(_streetMenu).AsSingle();
            Container.Bind<OfficeMenu>().FromInstance(_officeMenu).AsSingle();
            Container.Bind<NotificationsMenu>().FromInstance(_notificationMenu).AsSingle();
            Container.Bind<BusinessMenu>().FromInstance(_businessMenu).AsSingle();
            Container.Bind<QuestsMenu>().FromInstance(_questsMenu).AsSingle();
            Container.Bind<TradesMenu>().FromInstance(_tradesMenu).AsSingle();
            Container.Bind<CharacterUpgradeMenu>().FromInstance(_characterUpgradeMenu).AsSingle();

            Container.Bind<CameraMovement>().FromInstance(_playerCamera).AsSingle();
        }
    }
}
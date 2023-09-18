using Client.MenuesLogic;
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

        public override void InstallBindings()
        {
            Container.Bind<TakeBusinessMenu>().FromInstance(_takeBusinessMenu).AsSingle();
            Container.Bind<ShopMenu>().FromInstance(_shopMenu).AsSingle();
            Container.Bind<CapoMenu>().FromInstance(_capoMenu).AsSingle();
            Container.Bind<StreetMenu>().FromInstance(_streetMenu).AsSingle();
        }
    }
}
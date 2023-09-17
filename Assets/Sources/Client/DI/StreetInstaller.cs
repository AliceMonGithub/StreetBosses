using Client.MenuesLogic;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class StreetInstaller : MonoInstaller
    {
        [SerializeField] private TakeBusinessMenu _takeBusinessMenu;
        [SerializeField] private ShopMenu _shopMenu;

        public override void InstallBindings()
        {
            Container.Bind<TakeBusinessMenu>().FromInstance(_takeBusinessMenu).AsSingle();
            Container.Bind<ShopMenu>().FromInstance(_shopMenu).AsSingle();
        }
    }
}
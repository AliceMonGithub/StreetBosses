using Client.SceneLoading;
using System.Collections;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class MainMenuInstaller : MonoInstaller//, ICoroutineRunner
    {
        [SerializeField] private LoadCurtain _curtain;

        public override void InstallBindings()
        {
            SceneLoader sceneLoader = new(_curtain);

            Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
        }


    }
}
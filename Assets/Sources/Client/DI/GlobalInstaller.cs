using Client.SceneLoading;
using Server.PlayerLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class GlobalInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private LoadCurtain _prefab;

        private LoadCurtain _loadCurtain;
        private SceneLoader _sceneLoader;

        private Player _player;
        private PlayerBusinessesGate _businessesGate;

        private PlayerRuntime _playerRuntime;

        public override void InstallBindings()
        {
            _loadCurtain = Instantiate(_prefab);

            _sceneLoader = new(_loadCurtain);

            _player = new();
            _businessesGate = new(_player);

            _playerRuntime = new();

            Container.Bind<IReadOnlyPlayer>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerRuntime>().FromInstance(_playerRuntime).AsSingle();
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }

        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
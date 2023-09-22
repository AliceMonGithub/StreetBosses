using Client.SceneLoading;
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class GlobalInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private BusinessBlank[] _startBusinesses;
        [SerializeField] private CharacterBlank[] _startCharacters;

        [Space]

        [SerializeField] private LoadCurtain _prefab;

        private LoadCurtain _loadCurtain;
        private SceneLoader _sceneLoader;

        private Player _player;

        private PlayerRuntime _playerRuntime;

        public override void InstallBindings()
        {
            _loadCurtain = Instantiate(_prefab);

            _sceneLoader = new(_loadCurtain);

            _player = new();

            foreach (BusinessBlank businessBlank in _startBusinesses)
            {
                _player.BusinessesList.AddBusiness(new(businessBlank));
            }

            foreach (CharacterBlank characterBlank in _startCharacters)
            {
                _player.CharactersList.AddCharacter(new(characterBlank));
            }

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
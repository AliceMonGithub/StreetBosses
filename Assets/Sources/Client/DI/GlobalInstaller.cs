using Client.SceneLoading;
using Server.NotificationLogic;
using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections;
using UnityEngine;
using Zenject;
using Server.QuestsLogic;
using Server.BusinessLogic;
using Server.BotLogic;
using System.Collections.Generic;

namespace DI
{
    internal sealed class GlobalInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private CharacterData[] _unoccupiedSecurity;
        [SerializeField] private BusinessData[] _startBusinesses;
        [SerializeField] private CharacterData[] _startCharacters;
        [SerializeField] private BuyCharactersQuestData _buyStartQuest;
        [SerializeField] private EarnMoneyQuestData _earnStartQuest;

        [Space]

        [SerializeField] private LoadCurtain _loadCurtainPrefab;
        [SerializeField] private BotRuntime _botRuntimePrefab;

        private LoadCurtain _loadCurtain;
        private SceneLoader _sceneLoader;

        private BotRuntime _botRuntime;
        private UnoccupiedBusiness _unoccupiedProperties;

        private Player _player;

        private PlayerRuntime _playerRuntime;

        public override void InstallBindings()
        {
            _loadCurtain = Instantiate(_loadCurtainPrefab);
            _sceneLoader = new(_loadCurtain);

            _botRuntime = Instantiate(_botRuntimePrefab);
            _unoccupiedProperties = new(_unoccupiedSecurity);

            _player = new("Hero");

            _botRuntime.Init(_player);

            foreach (BusinessData businessData in _startBusinesses)
            {
                _player.BusinessesList.AddBusiness(new(businessData, _player));
            }

            foreach (CharacterData characterData in _startCharacters)
            {
                _player.CharactersList.AddCharacter(new(characterData, _player));
            }

            _player.QuestsList.AddQuest(new BuyCharactersQuest(_buyStartQuest, _player));
            _player.QuestsList.AddQuest(new EarnMoneyQuest(_earnStartQuest, _player));

            _playerRuntime = new();

            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<Bot>().FromInstance(_botRuntime.Bot).AsSingle();
            Container.Bind<PlayerRuntime>().FromInstance(_playerRuntime).AsSingle();
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
            Container.Bind<BotRuntime>().FromInstance(_botRuntime).AsSingle();
            Container.Bind<UnoccupiedBusiness>().FromInstance(_unoccupiedProperties).AsSingle();
        }

        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
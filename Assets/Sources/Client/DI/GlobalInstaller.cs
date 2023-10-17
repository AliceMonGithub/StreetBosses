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

        private Player _player;

        private PlayerRuntime _playerRuntime;

        public override void InstallBindings()
        {
            _loadCurtain = Instantiate(_loadCurtainPrefab);
            _sceneLoader = new(_loadCurtain);

            _botRuntime = Instantiate(_botRuntimePrefab);

            _player = new();

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

            _player.NotificationList.AddNotification(new Notification("Your business is under attack"));
            _player.NotificationList.AddNotification(new Notification("The quest is completed"));

            _playerRuntime = new();

            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<List<Player>>().FromInstance(new(1) { _player }).AsSingle();
            Container.Bind<PlayerRuntime>().FromInstance(_playerRuntime).AsSingle();
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
            Container.Bind<BotRuntime>().FromInstance(_botRuntime).AsSingle();
        }

        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
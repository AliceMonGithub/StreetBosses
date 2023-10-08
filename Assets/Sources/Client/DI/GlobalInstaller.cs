using Client.SceneLoading;
using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace DI
{
    internal sealed class GlobalInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private BusinessData[] _startBusinesses;
        [SerializeField] private CharacterData[] _startCharacters;
        [SerializeField] private BuyCharactersQuestData _buyStartQuest;
        [SerializeField] private EarnMoneyQuestData _earnStartQuest;

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

            foreach (BusinessData businessData in _startBusinesses)
            {
                _player.BusinessesList.AddBusiness(new(businessData, _player));
            }

            foreach (CharacterData characterData in _startCharacters)
            {
                _player.CharactersList.AddCharacter(new(characterData));
            }

            _player.QuestsList.AddQuest(new BuyCharactersQuest(_buyStartQuest, _player));
            _player.QuestsList.AddQuest(new EarnMoneyQuest(_earnStartQuest, _player));

            _player.NotificationList.AddNotification(new Notification("Your business is under attack"));
            _player.NotificationList.AddNotification(new Notification("The quest is completed"));

            _playerRuntime = new();

            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerRuntime>().FromInstance(_playerRuntime).AsSingle();
            Container.Bind<SceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }

        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
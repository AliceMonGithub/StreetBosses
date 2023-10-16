using Server.PlayerLogic;
using UnityEngine;
using Zenject;

namespace Server.BotLogic
{
    public sealed class BotRuntime : MonoBehaviour
    {
        [SerializeField] private float _timeToNextStep;

        private Bot _bot;
        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _bot = new(new DefaultBotBrain(), _player, _timeToNextStep);
        }

        private void Update()
        {
            _bot.Tick();
        }
    }
}
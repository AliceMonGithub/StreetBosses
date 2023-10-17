using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.BotLogic
{
    public sealed class BotRuntime : MonoBehaviour
    {
        [SerializeField] private BusinessData[] _allBusinesses;

        [SerializeField] private float _timeToNextStep;

        private Bot _bot;

        private List<Player> _players;

        [Inject]
        private void Constructor(List<Player> players)
        {
            _players = players;
        }

        private void Awake()
        {
            _bot = new(new DefaultBotBrain(_allBusinesses, _players), _timeToNextStep);
        }

        private void Update()
        {
            _bot.Tick();
        }
    }
}
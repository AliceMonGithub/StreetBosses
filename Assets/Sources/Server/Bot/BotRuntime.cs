using Server.BusinessLogic;
using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Server.BotLogic
{
    public sealed class BotRuntime : MonoBehaviour
    {
        [SerializeField] private BusinessData[] _allBusinesses;
        [SerializeField] private CharacterData _defaultCharacter;

        [SerializeField] private float _timeToNextStep;

        private Bot _bot;

        public Bot Bot => _bot;

        public void Init(Player player)
        {
            List<Player> players = new(1);

            _bot = new("RussianCartel", _timeToNextStep);

            players.Add(player);
            players.Add(_bot);

            _bot.SetBrain(new DefaultBotBrain(_bot, _allBusinesses, players, _defaultCharacter));
        }

        private void Update()
        {
            _bot.Tick();
        }
    }
}
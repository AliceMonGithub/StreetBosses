using Server.PlayerLogic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class Bot
    {
        private readonly BotBrain _brain;
        private readonly Player _player;

        private readonly float _timeToNextStep;
        private float _stepTimer;

        public Bot(BotBrain brain, Player player, float timeToNextStep)
        {
            _brain = brain;
            _player = player;
            
            _timeToNextStep = timeToNextStep;
            _stepTimer = 0;
        }

        public void Tick()
        {
            _stepTimer += Time.deltaTime;

            if (_stepTimer >= _timeToNextStep)
            {
                _brain.CalculateStep();

                _stepTimer = 0;
            }
        }
    }
}
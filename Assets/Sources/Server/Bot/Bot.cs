using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class Bot : Player
    {
        private readonly BotBrain _brain;

        private readonly float _timeToNextStep;
        private float _stepTimer;

        public Bot(BotBrain brain, float timeToNextStep)
        {
            _brain = brain;
            
            _timeToNextStep = timeToNextStep;
            _stepTimer = 0;
        }

        public void Tick()
        {
            _stepTimer += Time.deltaTime;

            if (_stepTimer >= _timeToNextStep)
            {
                _brain.CalculateStep().Do();

                _stepTimer = 0;
            }
        }
    }
}
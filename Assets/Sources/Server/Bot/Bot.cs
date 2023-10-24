using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Server.BotLogic
{
    public sealed class Bot : Player
    {
        private BotBrain _brain;

        private readonly float _timeToNextStep;
        private float _stepTimer;

        public Bot(string nickname, float timeToNextStep) : base(nickname)
        {
            _timeToNextStep = timeToNextStep;
            _stepTimer = 0;
        }

        public void SetBrain(BotBrain brain)
        {
            _brain = brain;
        }

        public void Tick()
        {
            _stepTimer += Time.deltaTime;

            if (_stepTimer >= _timeToNextStep)
            {
                _brain.CalculateStep().Do(this);

                _stepTimer = 0;
            }
        }

        public bool CheckBusinessForOwning(string name)
        {
            return _brain.CheckBusinessForOwning(name);
        }
    }
}
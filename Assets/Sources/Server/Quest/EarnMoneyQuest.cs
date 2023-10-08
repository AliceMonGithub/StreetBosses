using Server.PlayerLogic;
using System;
using UnityEngine;

namespace Server.BusinessLogic
{
    public sealed class EarnMoneyQuest : Quest
    {
        public override event Action<Quest> OnQuestCompleted;

        private readonly int _amount;

        public EarnMoneyQuest(int amount, Player player)
        {
            _amount = amount;

            Player = player;
        }

        public EarnMoneyQuest(EarnMoneyQuestData data, Player player) : this(data.Amount, player)
        {

        }

        public override void Init()
        {
            Player.Money.OnValueChanged += InvokeTryComplete;

            TryComplete();
        }

        private void InvokeTryComplete(int amount)
        {
            TryComplete();
        }

        public override void TryComplete()
        {
            if (IsCompleted() == false) return;

            OnQuestCompleted?.Invoke(this);
        }

        public override bool IsCompleted()
        {
            return Player.Money.Value >= _amount;
        }

        public override string GetDescription()
        {
            return $"Earn {GetCompletedValue()} money to complete this task";
        }

        public override int GetCompletedValue()
        {
            return _amount;
        }

        public override int GetProgressValue()
        {
            return Mathf.Clamp(Player.Money.Value, 0, GetCompletedValue());
        }
    }
}
using Server.CharacterLogic;
using Server.PlayerLogic;
using System;
using UnityEngine;

namespace Server.BusinessLogic
{
    public sealed class BuyCharactersQuest : Quest
    {
        public override event Action<Quest> OnQuestCompleted;

        private readonly int _count;

        public BuyCharactersQuest(int count, Player player)
        {
            _count = count;

            Player = player;
        }

        public BuyCharactersQuest(BuyCharactersQuestData data, Player player) : this(data.Count, player)
        {

        }

        public override void Init()
        {
            Player.CharactersList.OnCharacterAdded += InvokeTryComplete;

            TryComplete();
        }

        private void InvokeTryComplete(Character character)
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
            return Player.CharactersList.Characters.Count >= GetCompletedValue();
        }

        public override string GetDescription()
        {
            return $"Buy {GetCompletedValue()} characters to complete this task";
        }

        public override int GetCompletedValue()
        {
            return _count;
        }

        public override int GetProgressValue()
        {
            return Mathf.Clamp(Player.CharactersList.Characters.Count, 0, GetCompletedValue());
        }
    }
}
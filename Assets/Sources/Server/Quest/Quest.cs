using Server.PlayerLogic;
using System;

namespace Server.BusinessLogic
{
    public abstract class Quest
    {
        public abstract event Action<Quest> OnQuestCompleted;

        protected Player Player;

        public abstract void Init();
        public abstract void TryComplete();
        public abstract bool IsCompleted();
        public abstract string GetDescription();
        public abstract int GetCompletedValue();
        public abstract int GetProgressValue();
    }
}
using System;
using System.Collections.Generic;

namespace Server.QuestsLogic
{
    public sealed class QuestsList
    {
        public event Action<Quest> OnQuestCompleted;

        private readonly List<Quest> _quests;

        public QuestsList()
        {
            _quests = new();

            OnQuestCompleted += RemoveQuest;
        }

        public List<Quest> Quests => _quests;

        public void RemoveQuest(Quest quest)
        {
            _quests.Remove(quest);
        }

        public void AddQuest(Quest quest)
        {
            _quests.Add(quest);

            quest.OnQuestCompleted += InvokeOnQuestCompleted;

            quest.Init();
        }

        private void InvokeOnQuestCompleted(Quest quest)
        {
            OnQuestCompleted?.Invoke(quest);
        }
    }
}
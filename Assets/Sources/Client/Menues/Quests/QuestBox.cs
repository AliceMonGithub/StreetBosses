using Server.QuestsLogic;
using TMPro;
using UnityEngine;

namespace Client.MenuesLogic
{
    internal sealed class QuestBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _descriptionText;

        [Space]

        [SerializeField] private TMP_Text _valueText;

        private Quest _quest;

        public void Init(Quest quest)
        {
            _quest = quest;

            UpdateAllUI();
        }

        private void UpdateAllUI()
        {
            _descriptionText.text = _quest.GetDescription();
            _valueText.text = $"{_quest.GetProgressValue()}/{_quest.GetCompletedValue()}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
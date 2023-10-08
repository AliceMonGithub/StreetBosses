using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class QuestButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private QuestsMenu _menu;

        [Inject]
        private void Constructor(QuestsMenu menu)
        {
            _menu = menu;
        }

        private void Awake()
        {
            _button.onClick.AddListener(_menu.Show);
        }
    }
}
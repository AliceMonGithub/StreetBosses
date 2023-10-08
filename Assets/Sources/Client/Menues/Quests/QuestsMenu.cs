using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class QuestsMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private QuestBox _boxPrefab;
        [SerializeField] private Transform _instancingRoot;

        private List<QuestBox> _questBoxes;

        private Player _player;

        [Inject]
        private void Contructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _questBoxes = new();

            _exitButton.onClick.AddListener(Hide);
        }

        private void OnEnable()
        {
            CreateUIBoxes();
        }

        private void CreateUIBoxes()
        {
            foreach (Quest quest in _player.QuestsList.Quests)
            {
                QuestBox instance = Instantiate(_boxPrefab, _instancingRoot);
                instance.Init(quest);

                _questBoxes.Add(instance);
            }
        }

        private void OnDisable()
        {
            DestroyUIBoxes();
        }

        private void DestroyUIBoxes()
        {
            for (int i = 0; i < _questBoxes.Count; i++)
            {
                _questBoxes[i].Destroy();
            }

            _questBoxes.Clear();
        }
    }
}
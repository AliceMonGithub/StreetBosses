using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class CapoMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private CapoCharacterBox _boxPrefab;
        [SerializeField] private Transform _instancingRoot;

        private List<CapoCharacterBox> _instancies;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _instancies = new();

            _exitButton.onClick.AddListener(Hide);
        }

        private void OnEnable()
        {
            CreateUIBoxes();
        }

        private void CreateUIBoxes()
        {
            foreach (var keyPair in _player.CharactersList.Characters)
            {
                Character character = keyPair.Value;

                CapoCharacterBox instance = Instantiate(_boxPrefab, _instancingRoot);
                instance.Init(character);

                _instancies.Add(instance);
            }
        }

        private void OnDisable()
        {
            DestroyUIBoxes();
        }

        private void DestroyUIBoxes()
        {
            for (int i = 0; i < _instancies.Count; i++)
            {
                _instancies[i].Destroy();
            }

            _instancies.Clear();
        }
    }
}
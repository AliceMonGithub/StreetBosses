using Server.CharacterLogic;
using Server.PlayerLogic;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class SelectCharacterMenu : PopupMenu
    {
        public event Action<Character> OnCharacterSelected;

        [SerializeField] private SelectCharacterBox _prefab;
        [SerializeField] private Transform _instantiesRoot;

        [Space]

        [SerializeField] private Button _exitButton;

        private List<SelectCharacterBox> _instanties;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        public void SelectCharacter(Character character)
        {
            OnCharacterSelected?.Invoke(character);

            Hide();
        }

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            DestroyInstanties();
        }

        private void DestroyInstanties()
        {
            for (int i = 0; i < _instanties.Count; i++)
            {
                _instanties[i].Destroy();
            }

            _instanties.Clear();
        }

        private void OnEnable()
        {
            _instanties = new();

            CreateUIElements();
        }

        private void CreateUIElements()
        {
            foreach (var keyPair in _player.CharactersList.Characters)
            {
                Character character = keyPair.Value;

                SelectCharacterBox instance = Instantiate(_prefab, _instantiesRoot);
                instance.Init(this, character);

                _instanties.Add(instance);
            }
        }
    }
}

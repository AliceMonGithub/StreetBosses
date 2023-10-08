using Server.CharacterLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class ShopMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private CharacterData[] _charactersForSale;
        [SerializeField] private CharacterBuyBox _boxPrefab;
        [SerializeField] private Transform _instancingRoot;

        private List<CharacterBuyBox> _instancies;

        private Player _player;

        [Inject]
        private void Contructor(Player player)
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
            foreach (CharacterData character in _charactersForSale)
            {
                if (_player.CharactersList.Characters.ContainsKey(character.Name)) continue;

                CharacterBuyBox instance = Instantiate(_boxPrefab, _instancingRoot);
                instance.Init(character, _player);
                instance.OnSell += DestroyBoxOnSell;

                _instancies.Add(instance);
            }
        }

        private void DestroyBoxOnSell(CharacterBuyBox box)
        {
            box.Destroy();

            _instancies.Remove(box);
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
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class OfficeMenu : PopupMenu
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private BusinessBox _boxPrefab;

        private List<BusinessBox> _boxInstancies;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            _boxInstancies = new();

            _exitButton.onClick.AddListener(Hide);
        }

        private void OnEnable()
        {
            CreateBusinessBoxes();
        }

        private void OnDisable()
        {
            DestroyBusinessBoxes();
        }

        private void CreateBusinessBoxes()
        {
            foreach (var businessPair in _player.BusinessesList.Businesses)
            {
                Business business = businessPair.Value;

                BusinessBox instance = Instantiate(_boxPrefab, _contentRoot);
                instance.Init(business);

                _boxInstancies.Add(instance);
            }
        }

        private void DestroyBusinessBoxes()
        {
            for (int i = 0; i < _boxInstancies.Count; i++)
            {
                _boxInstancies[i].Destroy();
            }

            _boxInstancies.Clear();
        }
    }
}
using Client.AbilityLogic;
using Server.PlayerLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Client.MenuesLogic
{
    public sealed class AbilityIcons : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private AbilityIcon _prefab;

        private List<AbilityIcon> _instancies;

        private Player _player;

        public void Init(Player player)
        {
            _instancies = new();

            _player = player;

            CreateAbilityIcons();
        }

        private void CreateAbilityIcons()
        {
            foreach (Ability ability in _player.CharactersList.GetAbilities())
            {
                AbilityIcon instance = Instantiate(_prefab, _root);
                instance.Init(ability);

                _instancies.Add(instance);
            }
        }
    }
}
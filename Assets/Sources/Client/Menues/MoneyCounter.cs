using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;

        private Player _player;

        [Inject]
        private void Constructor(Player player)
        {
            _player = player;
        }

        private void Awake()
        {
            UpdateCounter(_player.Money.Value);

            _player.Money.OnValueChanged += UpdateCounter;
        }

        private void UpdateCounter(int value)
        {
            _counter.text = value.ToString();
        }
    }
}
using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Client.MenuesLogic
{
    internal sealed class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;

        private IReadOnlyPlayer _player;

        [Inject]
        private void Constructor(IReadOnlyPlayer player)
        {
            _player = player;
        }

        private void Awake()
        {
            _counter.text = _player.Money.Value.ToString();
        }
    }
}
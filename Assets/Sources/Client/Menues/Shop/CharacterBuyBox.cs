using Server.CharacterLogic;
using Server.PlayerLogic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class CharacterBuyBox : MonoBehaviour
    {
        public event Action<CharacterBuyBox> OnSell;

        [SerializeField] private Image _avatar;

        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _costText;

        [Space]

        [SerializeField] private Button _buyButton;

        private CharacterData _characterData;
        private Player _player;

        public void Init(CharacterData characterData, Player player)
        {
            _buyButton.onClick.RemoveListener(TryBuyCharacter);

            _characterData = characterData;
            _player = player;

            UpdateUI();

            _buyButton.onClick.AddListener(TryBuyCharacter);
        }

        private void UpdateUI()
        {
            _avatar.sprite = _characterData.Avatar;

            _nameText.text = _characterData.Name.ToString();
            _costText.text = _characterData.Cost.ToString();
        }

        private void TryBuyCharacter()
        {
            if (_player.Money.Value < _characterData.Cost) return;
            if (_player.CharactersList.Characters.ContainsKey(_characterData.Name)) return;

            _player.Money.Spend(_characterData.Cost);

            _player.CharactersList.AddCharacter(new(_characterData, _player));

            OnSell?.Invoke(this);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
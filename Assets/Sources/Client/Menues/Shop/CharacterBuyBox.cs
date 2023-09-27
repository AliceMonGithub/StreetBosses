using Server.CharacterLogic;
using Server.PlayerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class CharacterBuyBox : MonoBehaviour
    {
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

            _player.Money.Spend(_characterData.Cost);

            _player.CharactersList.AddCharacter(new(_characterData));

            print(_player.CharactersList.Characters.Count);
        }
    }
}
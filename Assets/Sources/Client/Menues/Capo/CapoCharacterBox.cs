using Server.CharacterLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class CapoCharacterBox : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Image _avatar;

        [Space]

        [SerializeField] private Button _button;

        private CharacterUpgradeMenu _menu;
        private Character _character;

        public void Init(CharacterUpgradeMenu menu, Character character)
        {
            _menu = menu;
            _character = character;

            UpdateBoxUI();

            _button.onClick.AddListener(InvokeCharacterUpgradeMenu);
            _character.OnUpgrade += UpdateBoxUI;
        }

        private void UpdateBoxUI()
        {
            _levelText.text = $"{_character.Level}/3";
            _avatar.sprite = _character.Avatar;
        }

        private void InvokeCharacterUpgradeMenu()
        {
            _menu.Init(_character);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
using Server.CharacterLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class SelectCharacterBox : MonoBehaviour
    {
        [SerializeField] private Button _selectButton;

        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private Image _avatar;

        private SelectCharacterMenu _menu;
        private Character _character;

        public void Init(SelectCharacterMenu menu, Character character)
        {
            _menu = menu;
            _character = character;

            UpdateUI();

            _selectButton.onClick.AddListener(SelectCharacter);
        }

        private void UpdateUI()
        {
            _nameText.text = _character.Name;
            _avatar.sprite = _character.Avatar;
        }

        private void SelectCharacter()
        {
            _menu.SelectCharacter(_character);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}

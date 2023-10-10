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

        private Character _character;

        public void Init(Character character)
        {
            _character = character;

            UpdateBoxUI();
        }

        private void UpdateBoxUI()
        {
            _levelText.text = "Debug";
            _avatar.sprite = _character.Avatar;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
using DG.Tweening;
using Server.CharacterLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class CharacterUpgradeMenu : PopupMenu
    {
        [SerializeField] private Button _exitButton;

        [Space]

        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _damageText;
        [SerializeField] private Slider _upgradeSlider;
        [SerializeField] private float _sliderDuration;
        [SerializeField] private TMP_Text _upgradeCostText;
        [SerializeField] private Button _upgradeButton;

        [Space]

        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _nameText;

        private Character _character;

        public void Init(Character character)
        {
            _character = character;

            _character.OnUpgrade += UpdateAllUI;
            _upgradeButton.onClick.AddListener(UpgradeAction);
            
            Show();
        }

        private void UpgradeAction()
        {
            _character.TryUpgrade();
        }

        private void OnEnable()
        {
            UpdateAllUI();
        }

        private void UpdateAllUI()
        {
            _upgradeSlider.DOValue(_character.UpgradeProgress, _sliderDuration);

            _healthText.text = _character.Health.ToString();
            _damageText.text = _character.Damage.ToString();

            _avatar.sprite = _character.Avatar;
            _nameText.text = _character.Name;

            if ((_character.Level - 1) == 2) return;

            _upgradeCostText.text = "$" + _character.MoneyForUpgrade.ToString();
        }
        
        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }
    }
}
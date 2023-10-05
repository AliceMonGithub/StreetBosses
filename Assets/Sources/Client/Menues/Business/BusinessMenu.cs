using DG.Tweening;
using Server.BusinessLogic;
using Server.CharacterLogic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

namespace Client.MenuesLogic
{
    internal sealed class BusinessMenu : PopupMenu
    {
        [SerializeField] private Slider _upgradeSlider;
        [SerializeField] private float _sliderDuration;

        [Space]

        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _upgradeButton;

        [Space]

        [SerializeField] private Button[] _securityButtons;
        [SerializeField] private Image[] _securityImages;
        [SerializeField] private Sprite _nonSecuritySprite;

        [Space]

        [SerializeField] private Button _managerButton;
        [SerializeField] private Image _managerImage;
        [SerializeField] private Sprite _nonManagerSprite;

        [Space]

        [SerializeField] private SelectCharacterMenu _selectCharacterMenu;

        [Space]

        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _earnText;
        [SerializeField] private TMP_Text _nextEarnText;
        [SerializeField] private TMP_Text _costText;

        private Business _business;

        private int _securityIndex;

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);

            for (int i = 0; i < _securityButtons.Length; i++)
            {
                int buttonIndex = i;

                _securityButtons[i].onClick.AddListener(() => InvokeSecuritySelecting(buttonIndex));
            }

            _managerButton.onClick.AddListener(InvokeManagerSelecting);
        }

        private void InvokeSecuritySelecting(int index)
        {
            _securityIndex = index;

            _selectCharacterMenu.Init(new SecuritySelectFilter());
            _selectCharacterMenu.OnCharacterSelected += SelectSecurity;
        }

        private void SelectSecurity(Character character)
        {
            if (character == null)
            {
                _business.RemoveSecurity(_securityIndex);
            }
            else
            {
                _business.SetSecurity(_securityIndex, character);
            }

            _selectCharacterMenu.OnCharacterSelected -= SelectSecurity;

            UpdateSecurityUI();
        }

        private void UpdateSecurityUI()
        {
            for (int i = 0; i < _business.Security.Length; i++)
            {
                if (_business.Security[i] == null)
                {
                    _securityImages[i].sprite = _nonSecuritySprite;

                    continue;
                }

                _securityImages[i].sprite = _business.Security[i].Avatar;
            }
        }

        private void InvokeManagerSelecting()
        {
            _selectCharacterMenu.Init(new ManagerSelectFilter());
            _selectCharacterMenu.OnCharacterSelected += SelectManager;
        }

        private void SelectManager(Character character)
        {
            if (character == null)
            {
                _business.RemoveManager();
            }
            else
            {
                _business.SetManager(character);
            }

            _selectCharacterMenu.OnCharacterSelected -= SelectManager;
            UpdateManagerUI();
        }

        private void UpdateManagerUI()
        {
            if(_business.Manager == null)
            {
                _managerImage.sprite = _nonManagerSprite;

                return;
            }

            _managerImage.sprite = _business.Manager.Avatar;
        }

        public void Init(Business business)
        {
            _upgradeButton.onClick.RemoveListener(UpgradeAction);

            if(_business != null)
            {
                _business.OnUpgrade -= UpgradeAllUI;
            }

            _business = business;

            UpgradeAllUI();

            _business.OnUpgrade += UpgradeAllUI; 
            _upgradeButton.onClick.AddListener(UpgradeAction);

            Show();
        }

        private void UpgradeAllUI()
        {
            _upgradeSlider.DOValue(_business.UpgradeProgress, _sliderDuration);

            _levelText.text = _business.Level.ToString();
            _earnText.text = _business.Earn.ToString();

            if ((_business.Level - 1) == 2) return;

            _nextEarnText.text = _business.NextEarn.ToString();
            _costText.text = _business.MoneyForUpgrade.ToString();
        }
       
        private void UpgradeAction()
        {
            _business.TryUpgrade();
        }
    }
}
using DG.Tweening;
using Server.BusinessLogic;
using TMPro;
using UnityEngine;
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

        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _earnText;
        [SerializeField] private TMP_Text _nextEarnText;
        [SerializeField] private TMP_Text _costText;

        private Business _business;

        public void Init(Business business)
        {
            _upgradeButton.onClick.RemoveListener(UpgradeAction);

            if(_business != null )
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

        private void Awake()
        {
            _exitButton.onClick.AddListener(Hide);
        }
    }
}
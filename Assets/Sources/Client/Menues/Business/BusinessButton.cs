using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.MenuesLogic
{

    internal sealed class BusinessButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Button _getEarnButton;
        [SerializeField] private Image _getEarnButtonImage;
        [SerializeField] private TMP_Text _earnText;

        [Space]

        [SerializeField] private Transform _particleRoot;
        [SerializeField] private ParticleSystem _coinsParticle;

        private BusinessMenu _businessMenu;
        private Business _business;
        private Player _player;

        public void Initialize(Business business, BusinessMenu businessMenu, Player player)
        {
            _businessMenu = businessMenu;
            _business = business;
            _player = player;

            _button.onClick.AddListener(ShowBusinessMenu);
            _getEarnButton.onClick.AddListener(GetEarn);

            StartCoroutine(UpdateGetEarn());
        }

        private void ShowBusinessMenu()
        {
            _businessMenu.Init(_business);
        }

        private void GetEarn()
        {
            if (_business.CanGetEarn == false) return;

            _player.Money.Add(_business.Earned);
            InstantiateCoinParticle();

            _business.CanGetEarn = false;
            _business.Earned = 0;

            _earnText.text = string.Empty;

            StopAllCoroutines();
            StartCoroutine(UpdateGetEarn());
        }

        private ParticleSystem InstantiateCoinParticle()
        {
            return Instantiate(_coinsParticle, _particleRoot.position, Quaternion.identity);
        }

        private IEnumerator UpdateGetEarn()
        {
            float timer = 0f;

            _earnText.text = _business.Earned == 0 ? string.Empty : _business.Earned.ToString();

            while (timer < _business.GetEarnTime)
            {
                timer += Time.deltaTime;

                _getEarnButtonImage.fillAmount = timer / _business.GetEarnTime;

                yield return null;
            }

            _business.Earned += _business.Earn;

            _business.CanGetEarn = true;
            _earnText.text = _business.Earned.ToString();

            if(_business.Manager != null)
            {
                StartCoroutine(UpdateGetEarn());
            }
        }
    }
}
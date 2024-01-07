using Server.BotLogic;
using Server.BusinessLogic;
using Server.PlayerLogic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Client.MenuesLogic
{

    public sealed class BusinessButton : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private Button _button;
        [SerializeField] private Button _getEarnButton;
        [SerializeField] private Image _getEarnButtonImage;
        [SerializeField] private TMP_Text _earnText;

        [Space]

        [SerializeField] private AnotherPlayerBusinessButton _anotherPlayerButtonPrefab;

        [Space]

        [SerializeField] private Transform _particleRoot;
        [SerializeField] private ParticleSystem _coinsParticle;

        private BusinessMenu _businessMenu;
        private Transform _canvasRoot;
        private Business _business;

        private TakeBusinessMenu _takeBusinessMenu;

        private PlayerRuntime _playerRuntime;
        private Player _player;

        public void Initialize(Business business, BusinessMenu businessMenu, Player player, PlayerRuntime playerRuntime, TakeBusinessMenu takeBusinessMenu, Transform canvasRoot)
        {
            _canvasRoot = canvasRoot;
            _businessMenu = businessMenu;
            _business = business;

            _takeBusinessMenu = takeBusinessMenu;

            _playerRuntime = playerRuntime;
            _player = player;

            _button.onClick.AddListener(ShowBusinessMenu);
            _getEarnButton.onClick.AddListener(GetEarn);

            _business.OnSetManager += GetEarn;
            _business.OnSetOwner += TryRefreshToAnotherPlayer;

            _business.SetBusinessButton(this);

            StartCoroutine(UpdateGetEarn());
        }

        private void OnDestroy()
        {
            _business.OnSetManager -= GetEarn;

            _business.SetBusinessButton(null);
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

        private void TryRefreshToAnotherPlayer()
         {
            if (_business.Owner == null) return;
            if (_root == null) return;
            if (_canvasRoot == null) return;

            AnotherPlayerBusinessButton button = Instantiate(_anotherPlayerButtonPrefab, _root.position, Quaternion.identity, _canvasRoot);
            button.Init(_business.Owner, _player, _business, _takeBusinessMenu, _businessMenu, _playerRuntime, _canvasRoot);

            GetEarn();

            Destroy(gameObject);
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
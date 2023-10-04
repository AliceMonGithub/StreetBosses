using Server.CharacterLogic;
using Server.PlayerLogic;
using System;

namespace Server.BusinessLogic
{
    public sealed class Business
    {
        public const float UpgradeProgressMultiplier = 0.25f;

        public event Action OnUpgrade;

        private readonly string _name;
        private readonly Player _owner;

        private BusinessUpgradeData[] _upgradeData;
        private int _level;
        private float _upgradeProgress;

        private Character[] _security;

        private int _earn;
        private readonly float _getEarnTime;

        public bool CanGetEarn;

        public Business(string name, int earn, float getEarnTime, BusinessUpgradeData[] upgradeData, Player owner)
        {
            _name = name;
            _owner = owner;

            _upgradeData = upgradeData;
            _level = 1;
            _upgradeProgress = 0f;

            _security = new Character[3];

            _earn = earn;
            _getEarnTime = getEarnTime;

            CanGetEarn = true;
        }

        public Business(string name) : this(name, 0, 0f, new BusinessUpgradeData[] { null }, null)
        {

        }

        public Business(BusinessData data, Player player) : this(data.Name, data.Earn, data.GetEarnTime, data.UpgradeData, player)
        {

        }

        public string Name => _name;
       
        public int Level => _level;
        public float UpgradeProgress => _upgradeProgress;

        public Character[] Security => _security;

        public int Earn => _earn;
        public int NextEarn => _upgradeData[_level - 1].Earn;
        public float GetEarnTime => _getEarnTime;

        public int MoneyForUpgrade => (int)(_upgradeData[_level - 1].Cost * UpgradeProgressMultiplier);

        public void TryUpgrade()
        {
            if ((_level - 1) == 2) return;
            if (_owner.Money.Value < MoneyForUpgrade) return;

            _owner.Money.Spend(MoneyForUpgrade);

            _upgradeProgress += UpgradeProgressMultiplier;

            if(_upgradeProgress >= 1f)
            {
                BusinessUpgradeData newData = _upgradeData[_level - 1];

                _earn = newData.Earn;

                _level++;
                _upgradeProgress = 0f;
            }

            OnUpgrade?.Invoke();
        }

        public void SetSecurity(int index, Character character)
        {
            if (_security[index] != null)
            {
                _security[index].SetSecurity(null);
            }

            _security[index] = character;
            character.SetSecurity(this);
        }

        public void RemoveSecurity(int index)
        {
            if (_security[index] == null) return;

            _security[index].SetSecurity(null);
            _security[index] = null;
        }
    }
}
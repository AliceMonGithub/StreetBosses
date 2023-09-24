namespace Server.BusinessLogic
{
    public sealed class BusinessUpgradeEventData
    {
        private readonly int _level;
        private readonly float _upgradeProgress;

        private readonly int _earn;
        private readonly int _nextEarn;
        private readonly int _cost;

        public BusinessUpgradeEventData(int level, float upgradeProgress, int earn, int nextEarn, int cost)
        {
            _level = level;
            _upgradeProgress = upgradeProgress;

            _earn = earn;
            _nextEarn = nextEarn;
            _cost = cost;
        }

        public int Level => _level;
        public float UpgradeProgress => _upgradeProgress;

        public int Earn => _earn;
        public int NextEarn => _nextEarn;
        public int Cost => _cost;
    }
}
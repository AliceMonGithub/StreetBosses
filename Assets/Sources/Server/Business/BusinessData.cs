using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Business")]
    public sealed class BusinessData : ScriptableObject
    {
        [SerializeField] private string _name;

        [Space]

        [SerializeField] private int _earn;
        [SerializeField] private float _getEarnTime;

        [Space]

        [SerializeField] private BusinessUpgradeData[] _upgrade;

        public string Name => _name;

        public int Earn => _earn;
        public float GetEarnTime => _getEarnTime;

        public BusinessUpgradeData[] UpgradeData => _upgrade;
    }
}
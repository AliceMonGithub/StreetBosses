using System;
using UnityEngine;

namespace Server.BusinessLogic
{
    [Serializable]
    public sealed class BusinessUpgradeData
    {
        [SerializeField] private int _cost;

        [Space]

        [SerializeField] private int _earn;

        public int Cost => _cost;

        public int Earn => _earn;
    }
}
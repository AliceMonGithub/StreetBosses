using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Business")]
    public sealed class BusinessBlank : ScriptableObject
    {
        [SerializeField] private string _name;

        [Space]

        [SerializeField] private int _earn;
        [SerializeField] private float _getEarnTime;

        public string Name => _name;

        public int Earn => _earn;
        public float GetEarnTime => _getEarnTime;
    }
}
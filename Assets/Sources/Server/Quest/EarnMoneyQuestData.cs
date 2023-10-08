using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Earn Money Quest")]
    public sealed class EarnMoneyQuestData : ScriptableObject
    {
        [SerializeField] private int _amount;

        public int Amount => _amount;
    }
}
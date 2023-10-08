using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Buy Characters Quest")]
    public sealed class BuyCharactersQuestData : ScriptableObject
    {
        [SerializeField] private int _count;

        public int Count => _count;
    }
}
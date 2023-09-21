using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Business")]
    public sealed class BusinessBlank : ScriptableObject
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}
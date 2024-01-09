using UnityEngine;

namespace Client.AbilityLogic
{
    [CreateAssetMenu(fileName = "Ability")]
    public class AbilityData : ScriptableObject
    {
        [SerializeField] private Sprite _image;

        public Sprite Image => _image;
    }
}
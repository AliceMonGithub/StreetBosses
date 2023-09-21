using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Character")]
    public sealed class CharacterBlank : ScriptableObject
    {
        [SerializeField] private Sprite _avatar;

        public Sprite Avatar => _avatar;
    }
}
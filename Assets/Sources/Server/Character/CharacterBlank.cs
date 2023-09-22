using UnityEngine;

namespace Server.BusinessLogic
{
    [CreateAssetMenu(fileName = "Character")]
    public sealed class CharacterBlank : ScriptableObject
    {
        [SerializeField] private Sprite _avatar;
        [SerializeField] private string _name;

        [Space]

        [SerializeField] private CharacterInstance _instance;

        public Sprite Avatar => _avatar;
        public string Name => _name;

        public CharacterInstance CharacterInstance => _instance;
    }
}
using Server.CharacterLogic;
using Server.PlayerLogic;
using UnityEngine;
using Zenject;

namespace Client.BattleLogic
{
    internal sealed class BattleCharactersFactory : MonoBehaviour
    {
        private IReadOnlyPlayer _player;

        [Inject]
        private void Constructor(IReadOnlyPlayer player)
        {
            _player = player;
        }

        private void Awake()
        {
            CreatePlayerCharacters();
        }

        private void CreatePlayerCharacters()
        {
            Debug.Log("Characters count: " + _player.CharacterList.Characters.Count);

            foreach (IReadOnlyCharacter character in _player.CharacterList.Characters)
            {
                Debug.Log("Character!");
            }
        }
    }
}
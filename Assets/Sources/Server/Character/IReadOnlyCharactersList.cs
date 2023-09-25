using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public interface IReadOnlyCharactersList
    {
        Dictionary<string, Character> Characters { get; }
    }
}
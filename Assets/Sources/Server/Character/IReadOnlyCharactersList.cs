using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public interface IReadOnlyCharactersList
    {
        IReadOnlyDictionary<string, Character> Characters { get; }
    }
}
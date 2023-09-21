using System.Collections.Generic;

namespace Server.CharacterLogic
{
    public interface IReadOnlyCharactersList
    {
        IReadOnlyList<IReadOnlyCharacter> Characters { get; }
    }
}
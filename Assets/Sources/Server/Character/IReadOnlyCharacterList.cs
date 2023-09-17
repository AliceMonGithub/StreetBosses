using System.Collections.Generic;

namespace Server.CharacterLogic
{
    internal interface IReadOnlyCharacterList
    {
        IReadOnlyList<IReadOnlyCharacter> Characters { get; }
    }
}
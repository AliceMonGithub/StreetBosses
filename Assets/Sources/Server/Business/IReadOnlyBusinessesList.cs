using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public interface IReadOnlyBusinessesList
    {
        IReadOnlyDictionary<string, Business> Businesses { get; }

        bool ContainsBusiness(string name);
    }
}
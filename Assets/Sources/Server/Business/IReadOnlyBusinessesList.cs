using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public interface IReadOnlyBusinessesList
    {
        IReadOnlyList<IReadOnlyBusiness> Businesses { get; }
    }
}
using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public sealed class BusinessesList : IReadOnlyBusinessesList
    {
        private List<Business> _businesses;

        public BusinessesList()
        {
            _businesses = new();
        }

        public IReadOnlyList<IReadOnlyBusiness> Businesses => _businesses;

        public void AddBusiness(Business business)
        {
            _businesses.Add(business);
        }
    }
}
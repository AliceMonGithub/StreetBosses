using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public sealed class BusinessesList : IReadOnlyBusinessesList
    {
        private Dictionary<string, Business> _businesses;

        public BusinessesList()
        {
            _businesses = new();
        }

        public IReadOnlyDictionary<string, Business> Businesses => _businesses;

        public void AddBusiness(Business business)
        {
            _businesses.Add(business.Name, business);
        }

        public bool ContainsBusiness(string name)
        {
            return _businesses.ContainsKey(name);
        }
    }
}
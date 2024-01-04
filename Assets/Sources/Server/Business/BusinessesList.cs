using System;
using System.Collections.Generic;

namespace Server.BusinessLogic
{
    public sealed class BusinessesList : IReadOnlyBusinessesList
    {
        public event Action<Business> OnBusinessAdded;

        private Dictionary<string, Business> _businesses;

        public BusinessesList()
        {
            _businesses = new();
        }

        public IReadOnlyDictionary<string, Business> Businesses => _businesses;

        public void AddBusiness(Business business)
        {
            _businesses.Add(business.Name, business);

            OnBusinessAdded?.Invoke(business);
        }

        public void RemoveBusiness(Business business)
        {
            _businesses.Remove(business.Name);
        }

        public bool ContainsBusiness(string name)
        {
            return _businesses.ContainsKey(name);
        }

        public bool ContainsBusiness(string name, out Business business)
        {
            if(_businesses.ContainsKey(name))
            {
                business = _businesses[name];

                return true;
            }

            business = null;

            return false;
        }
    }
}
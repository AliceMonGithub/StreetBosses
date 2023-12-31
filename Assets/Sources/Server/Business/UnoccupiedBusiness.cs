using Server.CharacterLogic;

namespace Server.BusinessLogic
{
    public sealed class UnoccupiedBusiness
    {
        private readonly CharacterData[] _security;

        public UnoccupiedBusiness(CharacterData[] security)
        {
            _security = security;
        }

        public CharacterData[] Security => _security;
    }
}
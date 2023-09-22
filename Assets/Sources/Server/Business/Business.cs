namespace Server.BusinessLogic
{
    public sealed class Business
    {
        private readonly string _name;

        public Business(string name)
        {
            _name = name;
        }

        public Business(BusinessBlank blank)
        {
            _name = blank.Name;
        }

        public string Name => _name;

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }
}
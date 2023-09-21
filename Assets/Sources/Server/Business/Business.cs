namespace Server.BusinessLogic
{
    public sealed class Business : IReadOnlyBusiness
    {
        private readonly string _name;

        public Business(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
namespace Server.BusinessLogic
{
    internal sealed class Business
    {
        private readonly string _name;

        public Business(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
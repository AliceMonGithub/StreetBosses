namespace Server.BusinessLogic
{
    public sealed class Business
    {
        private readonly string _name;

        private readonly int _earn;
        private readonly float _getEarnTime;

        public bool CanGetEarn;

        public Business(string name)
        {
            _name = name;

            CanGetEarn = true;
        }

        public Business(BusinessBlank blank)
        {
            _name = blank.Name;

            _earn = blank.Earn;
            _getEarnTime = blank.GetEarnTime;

            CanGetEarn = true;
        }

        public string Name => _name;
       
        public int Earn => _earn;
        public float GetEarnTime => _getEarnTime;
    }
}
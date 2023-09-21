namespace Server.MoneyLogic
{
    public sealed class Money : IReadOnlyMoney
    {
        private int _value;

        public Money(int value)
        {
            _value = value;
        }

        public void Add(int value)
        {
            _value += value;
        }

        public void Spend(int value)
        {
            if (_value - value < 0) throw new System.ArgumentOutOfRangeException();

            _value -= value;
        }

        public int Value => _value;
    }
}
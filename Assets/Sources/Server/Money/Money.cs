using System;

namespace Server.MoneyLogic
{
    public sealed class Money : IReadOnlyMoney
    {
        public event Action<int> OnValueChanged;

        private int _value;

        public Money(int value)
        {
            _value = value;
        }

        public void Add(int value)
        {
            _value += value;

            OnValueChanged?.Invoke(_value);
        }

        public void Spend(int value)
        {
            if (_value - value < 0) throw new System.ArgumentOutOfRangeException();

            _value -= value;

            OnValueChanged?.Invoke(value);
        }

        public int Value => _value;
    }
}
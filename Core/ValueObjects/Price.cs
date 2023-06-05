using CheatCodes.DDD.Core;

namespace CheatCodes.DDD.Core.ValueObjects
{
    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = string.Empty;

        public Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

    }
}


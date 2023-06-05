namespace CheatCodes.DDD.Core
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetEqualityComponents();

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            ValueObject vo = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }


        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        bool IEquatable<ValueObject>.Equals(ValueObject? other)
        {
            return Equals(other);
        }
    }
}

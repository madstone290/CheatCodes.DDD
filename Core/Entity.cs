namespace CheatCodes.DDD.Core
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
         where TId : struct
    {
        public TId Id { get; protected set; }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> other && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        bool IEquatable<Entity<TId>>.Equals(Entity<TId>? other)
        {
            return Equals(other);
        }
    }
}

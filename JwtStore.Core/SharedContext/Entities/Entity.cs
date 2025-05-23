namespace JwtStore.Core.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Guid id) => Id == id;

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
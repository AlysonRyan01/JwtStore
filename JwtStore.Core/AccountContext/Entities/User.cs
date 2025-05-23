using JwtStore.Core.SharedContext.Entities;
using JwtStore.Core.SharedContext.ValueObjects;

namespace JwtStore.Core.AccountContext.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
    }
}
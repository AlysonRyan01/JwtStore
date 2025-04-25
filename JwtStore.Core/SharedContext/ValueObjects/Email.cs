using System.Text.RegularExpressions;
using JwtStore.Core.SharedContext.Extensions;

namespace JwtStore.Core.SharedContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new Exception("Email inválido");

            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new Exception("Email inválido");

            if (!EmailRegex().IsMatch(Address))
                throw new Exception("Email inválido");
        }

        public string Address { get; private set; }
        public string Hash => Address.ToBase64();
        public Verification Verification { get; private set; } = new();

        public void ResendVerification()
        {
            Verification = new Verification();
        }

        public static implicit operator string(Email email)
            => email.ToString();

        public static implicit operator Email(string address)
            => new Email(address);

        public override string ToString()
        {
            return Address;
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
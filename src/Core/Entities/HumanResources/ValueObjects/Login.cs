using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class Login : ValueObject
    {
        public const int MAX_LENGTH = 256;
        public string Value { get; }

        private Login(string value)
            => Value = value;

        public static implicit operator string(Login self) => self.Value;

        public static Login Create(string login)
        {
            CheckValidity(login);
            return new Login(login);
        }

        private static void CheckValidity(string login)
        {
            Guard.Against.NullOrEmpty(login);
            Guard.Against.LengthGreaterThan(login, MAX_LENGTH);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
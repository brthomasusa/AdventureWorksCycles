#pragma warning disable CS8618

using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class Login : ValueObject
    {
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
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login), "The login id is required.");
            }

            if (login.Length > 256)
            {
                throw new ArgumentException("Invalid login id, maximum length is 256 characters.");
            }
        }
    }
}
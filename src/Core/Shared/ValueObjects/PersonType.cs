using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed class PersonType : ValueObject
    {
        private static readonly string[] _personTypes = { "SC", "IN", "SP", "EM", "VC", "GC" };
        public string? Value { get; }

        private PersonType(string personType)
            => Value = personType;

        public static implicit operator string(PersonType self) => self.Value!;

        public static PersonType Create(string value)
        {
            CheckValidity(value);
            return new PersonType(value);
        }

        private static void CheckValidity(string value)
        {
            Guard.Against.NullOrEmpty(value, "PersonType", "The person type is required.");

            if (!Array.Exists(_personTypes, element => element == value.ToUpper()))
            {
                throw new ArgumentException("Invalid person type!");
            }
        }
    }
}
using AWC.SharedKernel.Exceptions;

namespace AWC.SharedKernel.Guards
{
    public static partial class GuardClauseExtensions
    {
        private static void Error(string message)
        {
            throw new DomainException(message);
        }
    }
}

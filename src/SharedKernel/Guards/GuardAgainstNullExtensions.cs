using System.Runtime.CompilerServices;

namespace AWC.SharedKernel.Guards
{
    public static partial class GuardClauseExtensions
    {
        public static string NullOrEmpty
        (
            this IGuardClause guardClause,
            string input,
            string? message = null,
            [CallerArgumentExpression("input")] string? parameterName = null
        )
        {
            if (string.IsNullOrEmpty(input))
            {
                Error(message ?? $"Required input '{parameterName}' is missing.");
            }
            return input!;
        }
    }
}

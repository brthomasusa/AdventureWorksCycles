
namespace AWC.SharedKernel.Guards
{
    public static partial class GuardClauseExtensions
    {
        public static int LessThan(this IGuardClause guardClause, int input, int minValue, string parameterName = "Amount", string message = null!)
        {
            if (input < minValue)
            {
                Error(message ?? $"'{parameterName}' must be greater than or equal to {minValue}.");
            }
            return input;
        }

        public static decimal LessThan(this IGuardClause guardClause, decimal input, decimal minValue, string parameterName = "Amount", string message = null!)
        {
            if (input < minValue)
            {
                Error(message ?? $"'{parameterName}' must be greater than or equal to {minValue}.");
            }
            return input;
        }

        public static decimal LessThanZero(this IGuardClause guardClause, decimal input, string parameterName = "Amount", string message = null!)
        {
            return guardClause.LessThan(input, 0, parameterName, message);
        }

        public static int LessThanZero(this IGuardClause guardClause, int input, string parameterName = "Amount", string message = null!)
        {
            return guardClause.LessThan(input, 0, parameterName, message);
        }

        public static int GreaterThan(this IGuardClause guardClause, int input, int minValue, string parameterName = "Amount", string message = null!)
        {
            if (input < minValue)
            {
                Error(message ?? $"'{parameterName}' must be greater than or equal to {minValue}.");
            }
            return input;
        }

        public static decimal GreaterThanTwoDecimalPlaces(this IGuardClause guardClause, decimal input, string parameterName = "Amount", string message = null!)
        {
            if (input % 0.01M != 0)
            {
                Error(message ?? $"'{parameterName}' is limited to two decimal places.");
            }
            return input;
        }
    }
}

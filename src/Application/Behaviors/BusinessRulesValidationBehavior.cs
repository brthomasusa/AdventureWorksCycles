#pragma warning disable CS8603

using AWC.Application.Interfaces.Messaging;
using AWC.SharedKernel.Utilities;
using MediatR;

namespace AWC.Application.Behaviors
{
    public sealed class BusinessRulesValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<int>, IRequest<TResponse>
        where TResponse : Result
    {
        private readonly CommandValidator<TRequest> _businessRulesValidator;

        public BusinessRulesValidationBehavior(CommandValidator<TRequest> rulesValidator)
            => _businessRulesValidator = rulesValidator;

        public async Task<TResponse> Handle
        (
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            Result result = await _businessRulesValidator.Validate(request);

            if (result.IsSuccess)
            {
                return await next();
            }
            else
            {
                var retVal = Result<int>.Failure<int>(new Error("BusinessRulesValidationBehavior.Handle", result.Error.Message));
                return (retVal) as TResponse;
            }
        }
    }
}
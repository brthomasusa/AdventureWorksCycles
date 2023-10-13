using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using Mapster;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IWriteRepositoryManager repo, IMapper mapper)
            => (_repo, _mapper) = (repo, mapper);

        public async Task<Result<int>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Result<Employee> employeeDomainObject = BuildEmployeeDomainObject.Build(command, _mapper);

                if (employeeDomainObject.IsFailure)
                    return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", employeeDomainObject.Error.Message));

                Result<int> updateDbResult = await _repo.EmployeeAggregateRepository.Update(employeeDomainObject.Value);

                if (updateDbResult.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", updateDbResult.Error.Message));

                return RETURN_VALUE;

            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
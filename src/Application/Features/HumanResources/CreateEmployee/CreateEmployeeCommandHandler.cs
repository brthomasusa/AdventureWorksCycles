using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Interfaces.Messaging;
using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, int>
    {
        private readonly IWriteRepositoryManager _repo;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IWriteRepositoryManager repo, IMapper mapper)
            => (_repo, _mapper) = (repo, mapper);

        public async Task<Result<int>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            Result<Employee> employeeDomainObject = BuildEmployeeDomainObject.ConvertToGenericCommand(command, _mapper);

            if (employeeDomainObject.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", employeeDomainObject.Error.Message));

            Result<int> insertDbResult = await _repo.EmployeeAggregateRepository.InsertAsync(employeeDomainObject.Value);

            if (insertDbResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", insertDbResult.Error.Message));

            return insertDbResult;
        }
    }
}
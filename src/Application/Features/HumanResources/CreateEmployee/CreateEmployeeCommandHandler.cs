using AWC.Application.Interfaces.Messaging;
using AWC.Application.Mappings.HumanResources;
using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.CreateEmployee
{
    internal sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, int>
    {
        private readonly IWriteRepositoryManager _repo;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IWriteRepositoryManager repo, IMapper mapper)
            => (_repo, _mapper) = (repo, mapper);

        public async Task<Result<int>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            CreateEmployeeCommandToEmployeeDomainModelMapper modelMapper = new(_mapper);
            Result<Employee> result = modelMapper.Map(command);

            if (result.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", result.Error.Message));

            Result<int> insertDbResult = await _repo.EmployeeAggregateRepository.InsertAsync(result.Value);

            if (insertDbResult.IsFailure)
                return Result<int>.Failure<int>(new Error("CreateEmployeeCommandHandler.Handle", insertDbResult.Error.Message));

            return insertDbResult;
        }
    }
}
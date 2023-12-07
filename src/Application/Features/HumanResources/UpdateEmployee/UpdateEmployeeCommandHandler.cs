using AWC.Application.Mappings.HumanResources;
using AWC.Application.Interfaces.Messaging;
using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.UpdateEmployee
{
    internal sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand, int>
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
                UpdateEmployeeCommandToEmployeeDomainModelMapper modelMapper = new(_mapper);
                Result<Employee> result = modelMapper.Map(command);

                if (result.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateEmployeeCommandHandler.Handle", result.Error.Message));

                Result<int> updateDbResult = await _repo.EmployeeAggregateRepository.Update(result.Value);

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
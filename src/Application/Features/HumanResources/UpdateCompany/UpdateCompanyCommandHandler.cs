using AWC.Application.Interfaces.Messaging;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.UpdateCompany
{
    internal sealed class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, int>
    {
        private const int RETURN_VALUE = 0;
        private readonly IWriteRepositoryManager _repo;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IWriteRepositoryManager repo, IMapper mapper)
            => (_repo, _mapper) = (repo, mapper);

        public async Task<Result<int>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result<Company> result = _mapper.Map<Result<Company>>(request);

                if (result.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", result.Error.Message));

                Result<int> updateDbResult = await _repo.CompanyAggregateRepository.Update(result.Value);

                if (updateDbResult.IsFailure)
                    return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", updateDbResult.Error.Message));

                return RETURN_VALUE;
            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error("UpdateCompanyCommandHandler.Handle", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    public class LookupsRepository_Tests : TestBase
    {
        [Fact]
        public async Task StateCodeIdUSA_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<StateCode>> result = await repository.SharedLookupsRepository.StateCodeIdUSA();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task StateCodeIdAll_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<StateCode>> result = await repository.SharedLookupsRepository.StateCodeIdAll();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task DepartmentIds_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<DepartmentId>> result = await repository.HumanResourcesLookupsRepository.DepartmentIds();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task ShiftIds_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<ShiftId>> result = await repository.HumanResourcesLookupsRepository.ShiftIds();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task ManagerIds_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<ManagerId>> result = await repository.HumanResourcesLookupsRepository.ManagerIds();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }
    }
}
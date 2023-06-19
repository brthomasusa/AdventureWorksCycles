using AWC.Infrastructure.Persistence.Repositories;
using AWC.Shared.Queries.Lookups;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Repositories
{
    public class LookupsRepository_Tests : TestBase
    {
        [Fact]
        public async Task StateCodeIdUSA_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<StateCode>> result = await repository.LookupsRepository.StateCodeIdUSA();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task StateCodeIdAll_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<StateCode>> result = await repository.LookupsRepository.StateCodeIdAll();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task DepartmentIds_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<DepartmentId>> result = await repository.LookupsRepository.DepartmentIds();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }

        [Fact]
        public async Task ShiftIds_LookupsRepository_ShouldSucceed()
        {
            LookupsRepositoryManager repository = new(_dapperCtx, new NullLogger<LookupsRepositoryManager>());

            Result<List<ShiftId>> result = await repository.LookupsRepository.ShiftIds();

            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());
        }
    }
}
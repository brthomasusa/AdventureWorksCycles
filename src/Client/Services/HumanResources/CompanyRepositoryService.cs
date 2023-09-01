using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services.HumanResources.Store;
using AWC.Client.Services.HumanResources.Store.Departments;
using AWC.Client.Services.HumanResources.Store.Shifts;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.Shared.Queries.Shared;
using Fluxor;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;

namespace AWC.Client.Services.HumanResources
{
    public sealed class CompanyRepositoryService : ICompanyRepositoryService
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;
        private readonly IDispatcher? _dispatcher;
        private readonly IState<DepartmentIdLookupState>? _departmentLookupState;
        private readonly IState<ShiftIdLookupState>? _shiftLookupState;

        public CompanyRepositoryService
        (
            GrpcChannel channel,
            IMapper mapper,
            IDispatcher dispatcher,
            IState<DepartmentIdLookupState> departmentLookupState,
            IState<ShiftIdLookupState> shiftLookupState
        )
        {
            // => (_channel, _mapper, _metaDataService, _dispatcher) = (channel, mapper, metaDataService, dispatcher);
            _channel = channel;
            _mapper = mapper;
            _dispatcher = dispatcher;
            _departmentLookupState = departmentLookupState;
            _shiftLookupState = shiftLookupState;
        }

        public async Task<Result<List<DepartmentId>>> GetDepartmentIDs()
        {
            try
            {
                if (!_departmentLookupState!.Value.DepartmentIds!.Any())
                {
                    TaskCompletionSource<List<DepartmentId>> tcs = new();
                    _dispatcher!.Dispatch(new LoadDepartmentIdAsyncAction(tcs));
                    await tcs.Task;
                    return tcs.Task.Result;
                }
                else
                {
                    return _departmentLookupState!.Value.DepartmentIds!;
                }
            }
            catch (Exception ex)
            {
                return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(new Error(
                    "CompanyRepositoryService.GetDepartmentIDs",
                    Helpers.GetExceptionMessage(ex))
                );
            }

            throw new NotImplementedException();
        }

        public Task<Result<List<ShiftId>>> GetShiftIDs()
        {
            throw new NotImplementedException();
        }
    }
}
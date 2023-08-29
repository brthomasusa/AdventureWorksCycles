using System.Threading.Tasks;
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Interfaces.Shared;
using AWC.Client.Services.HumanResources.Store;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.Shared.Queries.Shared;
using Fluxor;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Lookups;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Services.HumanResources
{
    public sealed class EmployeeRepositoryService : IEmployeeRepositoryService
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;
        private IHumanResourcesMetaDataService _metaDataService;
        private readonly IDispatcher? _dispatcher;
        private IState<EmployeeRepositoryState>? _employeeRepoState;

        public EmployeeRepositoryService
        (
            GrpcChannel channel,
            IMapper mapper,
            IHumanResourcesMetaDataService metaDataService,
            IDispatcher dispatcher,
            IState<EmployeeRepositoryState> employeeRepoState
        )
        {
            // => (_channel, _mapper, _metaDataService, _dispatcher) = (channel, mapper, metaDataService, dispatcher);
            _channel = channel;
            _mapper = mapper;
            _metaDataService = metaDataService;
            _dispatcher = dispatcher;
            _employeeRepoState = employeeRepoState;
        }


        public async Task<Result<EmployeeDetails>> GetEmployeeDetails(int businessEntityID)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                ItemRequest request = new() { Id = businessEntityID };

                grpc_EmployeeForDisplay grpcResponse = await client.GetEmployeeForDisplayAsync(request);

                EmployeeDetails employee = _mapper!.Map<EmployeeDetails>(grpcResponse);

                return employee;
            }
            catch (Exception ex)
            {
                return Result<EmployeeDetails>.Failure<EmployeeDetails>(new Error(
                    "EmployeeRepositoryService.GetEmployeeDetails",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result<List<EmployeeListItem>>> GetEmployeeListItems(StringSearchCriteria criteria)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                grpc_EmployeeListItems grpcResponse =
                    await client.GetEmployeesSearchByNameAsync(_mapper!.Map<grpc_StringSearchCriteria>(criteria));

                List<EmployeeListItem> employeeListItems = new();

                grpcResponse.GrpcEmployees.ToList()
                                          .ForEach(grpcItem => employeeListItems.Add(_mapper.Map<EmployeeListItem>(grpcItem)));

                _metaDataService.AddMetaData("EmployeeListItem", _mapper.Map<MetaData>(grpcResponse.GrpcMetaData));

                return employeeListItems;
            }
            catch (Exception ex)
            {
                return Result<List<EmployeeListItem>>.Failure<List<EmployeeListItem>>(new Error(
                    "EmployeeRepositoryService.GetEmployeeListItems",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result<List<StateCode>>> GetStateCodes()
        {
            try
            {
                if (!_employeeRepoState!.Value.StateCodes!.Any())
                {
                    _dispatcher!.Dispatch(new LoadStateCodesAction());

                    while (_employeeRepoState.Value.Loading)
                    {
                        await Task.Delay(5);
                    }
                }

                List<StateCode> stateCodes = _employeeRepoState.Value.StateCodes!;

                return stateCodes;
            }
            catch (Exception ex)
            {
                return Result<List<StateCode>>.Failure<List<StateCode>>(new Error(
                    "EmployeeRepositoryService.GetStateCodes",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result<List<ManagerId>>> GetManagerIDs()
        {
            try
            {
                if (!_employeeRepoState!.Value.ManagerIDs!.Any())
                {
                    TaskCompletionSource<List<ManagerId>> tcs = new();
                    _dispatcher!.Dispatch(new LoadManagerIdAsyncAction(tcs));
                    await tcs.Task;
                    return tcs.Task.Result;
                }
                else
                {
                    return _employeeRepoState.Value.ManagerIDs!;
                }
            }
            catch (Exception ex)
            {
                return Result<List<ManagerId>>.Failure<List<ManagerId>>(new Error(
                    "EmployeeRepositoryService.GetManagerIDs",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services.HumanResources.Store;
using AWC.Client.Services.HumanResources.Store.Managers;
using AWC.Client.Services.HumanResources.Store.StateCodes;
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
    public sealed class EmployeeRepositoryService : IEmployeeRepositoryService
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;
        private readonly IDispatcher? _dispatcher;
        private readonly IState<ManagerIdLookupState>? _managerLookupState;
        private readonly IState<StateCodesLookupState>? _stateCodeLookupState;

        public EmployeeRepositoryService
        (
            GrpcChannel channel,
            IMapper mapper,
            IDispatcher dispatcher,
            IState<ManagerIdLookupState> managerLookupState,
            IState<StateCodesLookupState> stateCodeLookupState
        )
        {
            // => (_channel, _mapper, _metaDataService, _dispatcher) = (channel, mapper, metaDataService, dispatcher);
            _channel = channel;
            _mapper = mapper;
            _dispatcher = dispatcher;
            _managerLookupState = managerLookupState;
            _stateCodeLookupState = stateCodeLookupState;
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

        public async Task<Result<PagedList<EmployeeListItem>>> GetEmployeeListItems(StringSearchCriteria criteria)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                grpc_EmployeeListItems grpcResponse =
                    await client.GetEmployeesSearchByNameAsync(_mapper!.Map<grpc_StringSearchCriteria>(criteria));

                PagedList<EmployeeListItem> employeeListItems = new() { Items = new() };

                grpcResponse.GrpcEmployees.ToList()
                                          .ForEach(grpcItem => employeeListItems.Items.Add(_mapper.Map<EmployeeListItem>(grpcItem)));

                employeeListItems.MetaData = _mapper.Map<MetaData>(grpcResponse.GrpcMetaData);

                return employeeListItems;
            }
            catch (Exception ex)
            {
                return Result<PagedList<EmployeeListItem>>.Failure<PagedList<EmployeeListItem>>(new Error(
                    "EmployeeRepositoryService.GetEmployeeListItems",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result<List<StateCode>>> GetStateCodes()
        {
            try
            {
                if (!_stateCodeLookupState!.Value.StateCodes!.Any())
                {
                    _dispatcher!.Dispatch(new LoadStateCodesAction());

                    while (_stateCodeLookupState.Value.Loading)
                    {
                        await Task.Delay(5);
                    }
                }

                List<StateCode> stateCodes = _stateCodeLookupState.Value.StateCodes!;

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
                if (!_managerLookupState!.Value.ManagerIds!.Any())
                {
                    TaskCompletionSource<List<ManagerId>> tcs = new();
                    _dispatcher!.Dispatch(new LoadManagerIdAsyncAction(tcs));
                    await tcs.Task;
                    return tcs.Task.Result;
                }
                else
                {
                    return _managerLookupState.Value.ManagerIds!;
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
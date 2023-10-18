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
            _channel = channel;
            _mapper = mapper;
            _dispatcher = dispatcher;
            _managerLookupState = managerLookupState;
            _stateCodeLookupState = stateCodeLookupState;
        }

        public async Task<Result<AWC.Shared.Commands.HumanResources.EmployeeGenericCommand>> GetEmployeeForUpdate(int businessEntityID)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                ItemRequest request = new() { Id = businessEntityID };
                grpc_EmployeeGenericCommand grpcResponse = await client.GetEmployeeForEditAsync(request);

                List<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand> departments = new();
                List<AWC.Shared.Commands.HumanResources.PayHistoryCommand> payHistories = new();

                grpcResponse.DepartmentHistories.ToList().ForEach(dept =>
                    departments.Add(_mapper.Map<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand>(dept))
                );

                grpcResponse.PayHistories.ToList().ForEach(pay =>
                    payHistories.Add(_mapper.Map<AWC.Shared.Commands.HumanResources.PayHistoryCommand>(pay))
                );

                var employee = _mapper.Map<AWC.Shared.Commands.HumanResources.EmployeeGenericCommand>(grpcResponse);
                employee.DepartmentHistories!.AddRange(departments);
                employee.PayHistories!.AddRange(payHistories);

                return employee;
            }
            catch (Exception ex)
            {
                return Result.Failure<AWC.Shared.Commands.HumanResources.EmployeeGenericCommand>(new Error(
                    "EmployeeRepositoryService.GetEmployeeForUpdate",
                    Helpers.GetExceptionMessage(ex))
                );
            }
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

        public async Task<Result<int>> CreateEmployee(AWC.Shared.Commands.HumanResources.EmployeeGenericCommand employee)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                grpc_EmployeeGenericCommand command = _mapper.Map<grpc_EmployeeGenericCommand>(employee);

                List<grpc_DepartmentHistoryCommand> grpcDeptHist = new();
                employee.DepartmentHistories!.ToList().ForEach(d =>
                    grpcDeptHist.Add(_mapper.Map<grpc_DepartmentHistoryCommand>(d))
                );

                List<grpc_PayHistoryCommand> grpcPayHist = new();
                employee.PayHistories!.ToList().ForEach(p =>
                    grpcPayHist.Add(_mapper.Map<grpc_PayHistoryCommand>(p))
                );

                command.DepartmentHistories.AddRange(grpcDeptHist);
                command.PayHistories.AddRange(grpcPayHist);

                CreateResponse grpcResponse = await client.CreateAsync(command);

                return grpcResponse.Id;
            }
            catch (Exception ex)
            {
                return Result<int>.Failure<int>(new Error(
                    "EmployeeRepositoryService.CreateEmployee",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result> UpdateEmployee(AWC.Shared.Commands.HumanResources.EmployeeGenericCommand employee)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                grpc_EmployeeGenericCommand command = _mapper.Map<grpc_EmployeeGenericCommand>(employee);
                await client.UpdateAsync(command);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error(
                    "EmployeeRepositoryService.UpdateEmployee",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result> DeleteEmployee(int businessEntityId)
        {
            try
            {
                var client = new EmployeeContract.EmployeeContractClient(_channel);
                ItemRequest request = new() { Id = businessEntityId };
                await client.DeleteAsync(request);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error(
                    "EmployeeRepositoryService.UpdateEmployee",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
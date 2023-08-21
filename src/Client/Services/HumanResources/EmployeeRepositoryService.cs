using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;

namespace AWC.Client.Services.HumanResources
{
    public sealed class EmployeeRepositoryService
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;

        public EmployeeRepositoryService(GrpcChannel channel, IMapper mapper)
            => (_channel, _mapper) = (channel, mapper);

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
    }
}
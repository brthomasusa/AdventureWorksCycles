using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Application.Features.HumanResources.ViewEmployeeDetails;
using AWC.Application.Features.HumanResources.ViewEmployees;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Core;
using MapsterMapper;
using MediatR;

namespace AWC.Server.Contracts
{
    public sealed class EmployeeContractService : EmployeeContract.EmployeeContractBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public EmployeeContractService(ISender sender, IMapper mapper)
            => (_sender, _mapper) = (sender, mapper);

        public async override Task<CreateResponse> Create(grpc_EmployeeGenericCommand request, ServerCallContext context)
        {
            List<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand> departmentHistory = new();
            request.DepartmentHistories.ToList().ForEach(grpcDept =>
                departmentHistory.Add(_mapper.Map<AWC.Shared.Commands.HumanResources.DepartmentHistoryCommand>(grpcDept))
            );

            List<AWC.Shared.Commands.HumanResources.PayHistoryCommand> payHistory = new();
            request.PayHistories.ToList().ForEach(grpcPay =>
                payHistory.Add(_mapper.Map<AWC.Shared.Commands.HumanResources.PayHistoryCommand>(grpcPay))
            );

            CreateEmployeeCommand createEmployeeCommand = _mapper.Map<CreateEmployeeCommand>(request);
            createEmployeeCommand = createEmployeeCommand with
            {
                DepartmentHistories = departmentHistory,
                PayHistories = payHistory
            };

            Result<int> result = await _sender.Send(createEmployeeCommand);

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            return new CreateResponse { Id = result.Value };
        }

        public async override Task<GenericResponse> Delete(ItemRequest request, ServerCallContext context)
        {
            DeleteEmployeeCommand deleteEmployeeCommand = new(request.Id);
            Result<int> result = await _sender.Send(deleteEmployeeCommand);

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            return new GenericResponse { Success = true };
        }

        public async override Task<GenericResponse> Update(grpc_EmployeeGenericCommand request, ServerCallContext context)
        {
            EmployeeGenericCommand genericCommand = _mapper.Map<EmployeeGenericCommand>(request);
            UpdateEmployeeCommand updateEmployeeCommand = _mapper.Map<UpdateEmployeeCommand>(genericCommand);

            Result<int> result = await _sender.Send(updateEmployeeCommand);

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            return new GenericResponse { Success = true };
        }

        public async override Task<grpc_EmployeeForDisplay> GetEmployeeForDisplay(ItemRequest request, ServerCallContext context)
        {
            Result<EmployeeDetails> result =
                await _sender.Send(new GetEmployeeDetailsRequest(EmployeeID: request.Id));

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            return _mapper.Map<grpc_EmployeeForDisplay>(result.Value);
        }

        public async override Task<grpc_EmployeeGenericCommand> GetEmployeeForEdit(ItemRequest request, ServerCallContext context)
        {
            Result<EmployeeGenericCommand> result =
                await _sender.Send(new GetEmployeeCommandRequest(EmployeeID: request.Id));

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            return _mapper.Map<grpc_EmployeeGenericCommand>(result.Value);
        }

        public async override Task<grpc_EmployeeListItems> GetEmployeesSearchByName(grpc_StringSearchCriteria request, ServerCallContext context)
        {
            StringSearchCriteria criteria = _mapper.Map<StringSearchCriteria>(request);
            GetEmployeeListItemsRequest query = new(SearchCriteria: criteria);

            Result<PagedList<EmployeeListItem>> result = await _sender.Send(query);

            if (result.IsFailure)
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));

            grpc_EmployeeListItems grpcEmployeeContainer = new();
            List<grpc_EmployeeListItem> grpcEmployeeListItems = new();

            result.Value.ToList().ForEach(emplListItem =>
                grpcEmployeeListItems.Add(_mapper.Map<grpc_EmployeeListItem>(emplListItem))
            );

            grpcEmployeeContainer.GrpcEmployees.AddRange(grpcEmployeeListItems);
            grpcEmployeeContainer.GrpcMetaData.Add(Helpers.LoadMetaData(result.Value.MetaData));

            return grpcEmployeeContainer;
        }
    }
}
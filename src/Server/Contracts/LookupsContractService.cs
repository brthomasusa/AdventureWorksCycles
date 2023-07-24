using AWC.Application.Lookups.HumanResources.GetDepartmentIds;
using AWC.Application.Lookups.HumanResources.GetManagerIds;
using AWC.Application.Lookups.HumanResources.GetShiftIds;
using AWC.Application.Lookups.Shared.GetStateCodesForAll;
using AWC.Application.Lookups.Shared.GetStateCodesForUSA;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;
using gRPC.Contracts.Lookups;
using Grpc.Core;
using MediatR;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Server.Contracts
{
    public sealed class LookupsContractService : LookupsContract.LookupsContractBase
    {
        private readonly ISender _sender;

        public LookupsContractService(ISender sender)
            => _sender = sender;

        public async override Task GetStateCodesAll
        (
            Empty request,
            IServerStreamWriter<grpc_StateProvinceCode> responseStream,
            ServerCallContext context
        )
        {
            Result<List<StateCode>> stateCodes = await _sender.Send(new GetStateCodeIdForAllRequest());

            if (stateCodes.IsSuccess)
            {
                stateCodes.Value.ToList().ForEach(stateCode => responseStream.WriteAsync(
                    new grpc_StateProvinceCode { Id = stateCode.StateProvinceID, StateCode = stateCode.StateProvinceCode }
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, stateCodes.Error.Message));
            }

        }

        public async override Task GetStateCodesUsa
        (
            Empty request,
            IServerStreamWriter<grpc_StateProvinceCode> responseStream,
            ServerCallContext context
        )
        {
            Result<List<StateCode>> stateCodes = await _sender.Send(new GetStateCodeIdForUSARequest());

            if (stateCodes.IsSuccess)
            {
                stateCodes.Value.ToList().ForEach(stateCode => responseStream.WriteAsync(
                    new grpc_StateProvinceCode { Id = stateCode.StateProvinceID, StateCode = stateCode.StateProvinceCode }
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, stateCodes.Error.Message));
            }
        }

        public async override Task GetDepartmentIds(Empty request, IServerStreamWriter<grpc_DepartmentId> responseStream, ServerCallContext context)
        {
            Result<List<DepartmentId>> result = await _sender.Send(new GetDepartmentIdsRequest());

            if (result.IsSuccess)
            {
                result.Value.ToList().ForEach(dept => responseStream.WriteAsync(
                    new grpc_DepartmentId { DepartmentId = dept.DepartmentID, Name = dept.DepartmentName }
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));
            }
        }

        public async override Task GetManagerIds(Empty request, IServerStreamWriter<grpc_ManagerId> responseStream, ServerCallContext context)
        {
            Result<List<ManagerId>> result = await _sender.Send(new GetManagerIdsRequest());

            if (result.IsSuccess)
            {
                result.Value.ToList().ForEach(mgr => responseStream.WriteAsync(
                    new grpc_ManagerId { BusinessEntityId = mgr.BusinessEntityID, ManagerFullName = mgr.ManagerFullName }
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));
            }
        }

        public async override Task GetShiftIds(Empty request, IServerStreamWriter<grpc_ShiftId> responseStream, ServerCallContext context)
        {
            Result<List<ShiftId>> result = await _sender.Send(new GetShiftIdsRequest());

            if (result.IsSuccess)
            {
                result.Value.ToList().ForEach(shift => responseStream.WriteAsync(
                    new grpc_ShiftId { ShiftId = shift.ShiftID, Name = shift.ShiftName }
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));
            }
        }
    }
}
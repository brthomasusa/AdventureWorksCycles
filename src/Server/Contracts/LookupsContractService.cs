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
using MapsterMapper;
using MediatR;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Server.Contracts
{
    public sealed class LookupsContractService : LookupsContract.LookupsContractBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public LookupsContractService(ISender sender, IMapper mapper)
            => (_sender, _mapper) = (sender, mapper);

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
                    _mapper.Map<grpc_StateProvinceCode>(stateCode)
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
            Result<List<StateCode>> stateCodes = await _sender.Send(new GetStateCodeIdForUsaRequest());

            if (stateCodes.IsSuccess)
            {
                stateCodes.Value.ToList().ForEach(stateCode => responseStream.WriteAsync(
                    _mapper.Map<grpc_StateProvinceCode>(stateCode)
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
                    _mapper.Map<grpc_DepartmentId>(dept)
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
                    _mapper.Map<grpc_ManagerId>(mgr)
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
                    _mapper.Map<grpc_ShiftId>(shift)
                ));
            }
            else
            {
                throw new RpcException(new(StatusCode.Internal, result.Error.Message));
            }
        }
    }
}
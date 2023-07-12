using AWC.Application.Lookups.HumanResources.GetDepartmentIds;
using AWC.Application.Lookups.HumanResources.GetManagerIds;
using AWC.Application.Lookups.HumanResources.GetShiftIds;
using AWC.Application.Lookups.Shared.GetCountryCodes;
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

            stateCodes.Value.ToList().ForEach(stateCode => responseStream.WriteAsync(
                new grpc_StateProvinceCode { Id = stateCode.StateProvinceID, StateCode = stateCode.StateProvinceCode }
            ));
        }

        public async override Task GetStateCodesUsa
        (
            Empty request,
            IServerStreamWriter<grpc_StateProvinceCode> responseStream,
            ServerCallContext context
        )
        {
            Result<List<StateCode>> stateCodes = await _sender.Send(new GetStateCodeIdForUSARequest());

            stateCodes.Value.ToList().ForEach(stateCode => responseStream.WriteAsync(
                new grpc_StateProvinceCode { Id = stateCode.StateProvinceID, StateCode = stateCode.StateProvinceCode }
            ));
        }
    }
}
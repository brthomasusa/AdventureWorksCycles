using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using Fluxor;
using gRPC.Contracts.HumanResources;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;

namespace AWC.Client.Features.HumanResources.ViewCompanyDetails.Store
{
    public sealed class ViewCompanyDetailEffects : Effect<SetViewCompanyDetailsAction>
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;

        public ViewCompanyDetailEffects(GrpcChannel channel, IMapper mapper)
            => (_channel, _mapper) = (channel, mapper);

        public override async Task HandleAsync
        (
            SetViewCompanyDetailsAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                dispatcher.Dispatch(new SetLoadingFlagAction());

                gRPC.Contracts.Shared.ItemRequest request = new() { Id = action.CompanyID };
                var client = new CompanyContract.CompanyContractClient(_channel);
                grpc_CompanyForDisplay grpcResponse = await client.GetCompanyForDisplayAsync(request);

                CompanyDetails model = _mapper.Map<CompanyDetails>(grpcResponse);

                dispatcher.Dispatch(new ViewCompanyDetailsSuccessAction(model));
                dispatcher.Dispatch(new ViewInitializeFlagAction(true));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new ViewCompanyDetailsFailureMessageAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
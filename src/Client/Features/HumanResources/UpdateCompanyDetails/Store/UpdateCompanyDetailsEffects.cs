
using AWC.Client.Features.HumanResources.ViewCompanyDetails.Store;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using Fluxor;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Lookups;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using Mapster;
using MapsterMapper;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Features.HumanResources.UpdateCompanyDetails.Store
{
    public sealed class UpdateCompanyDetailsEffects : Effect<LoadCompanyDetailsForEditingAction>
    {
        private readonly GrpcChannel? _channel;
        private readonly IMapper _mapper;

        public UpdateCompanyDetailsEffects
        (
            GrpcChannel channel,
            IMapper mapper
        )
            => (_channel, _mapper) = (channel, mapper);


        [EffectMethod(typeof(LoadStateCodesAction))]
        public async Task LoadStateCodes(IDispatcher dispatcher)
        {
            try
            {
                var client = new LookupsContract.LookupsContractClient(_channel);
                var stream = client.GetStateCodesUs(new Empty()).ResponseStream;

                List<StateCode> stateCodes = new();

                while (await stream.MoveNext(default))
                {
                    grpc_StateProvinceCode code = (grpc_StateProvinceCode)stream.Current;
                    stateCodes.Add(_mapper.Map<StateCode>(code));
                }

                dispatcher.Dispatch(new LoadStateCodesSuccessAction(stateCodes));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new LoadStateCodesFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }

        public override async Task HandleAsync
        (
            LoadCompanyDetailsForEditingAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                dispatcher.Dispatch(new SetLoadingFlagAction());

                var client = new CompanyContract.CompanyContractClient(_channel);
                ItemRequest request = new() { Id = action.CompanyID };
                grpc_CompanyGenericCommand grpcResponse = await client.GetCompanyForEditAsync(request);

                CompanyGenericCommand model = _mapper.Map<CompanyGenericCommand>(grpcResponse);

                dispatcher.Dispatch(new UpdateCompanyDetailsInitializeSuccessAction(model));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new UpdateCompanyDetailsInitializeFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }

        [EffectMethod]
        public async Task SubmitUpdatedCompanyCommandModel
        (
            UpdateCompanyDetailsSubmitAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                var client = new CompanyContract.CompanyContractClient(_channel);

                grpc_CompanyGenericCommand cmd = _mapper.Map<grpc_CompanyGenericCommand>(action.CommandModel);
                GenericResponse response = await client.UpdateAsync(cmd);

                if (response.Success)
                {
                    dispatcher.Dispatch(new ViewInitializeFlagAction(false));
                }
                else
                {
                    dispatcher.Dispatch(new UpdateCompanyDetailsSubmitFailureAction("Update failed! Server Error."));
                }
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new UpdateCompanyDetailsSubmitFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
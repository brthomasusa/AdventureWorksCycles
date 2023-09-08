using AWC.Client.Features.HumanResources.ViewCompanyDetails.Store;
using AWC.Client.Utilities;
using AWC.Shared.Commands.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using Fluxor;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Lookups;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Services.HumanResources.Store.StateCodes
{
    public sealed class LoadStateCodesEffects
    {
        private readonly GrpcChannel _channel;
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public LoadStateCodesEffects
        (
            GrpcChannel channel,
            IMapper mapper,
            NotificationService notificationService
        )
        {
            _channel = channel;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [EffectMethod(typeof(LoadStateCodesAction))]
        public async Task LoadStateCodes(IDispatcher dispatcher)
        {
            try
            {
                dispatcher.Dispatch(new SetStateCodesLoadingFlagAction());

                var client = new LookupsContract.LookupsContractClient(_channel);
                var stream = client.GetStateCodesUsa(new Empty()).ResponseStream;

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
                _notificationService!.Notify(
                    new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Style = "position: relative; left: -500px; top: 490px; width: 100%",
                        Detail = Helpers.GetExceptionMessage(ex),
                        Duration = 10000
                    }
                );

                dispatcher.Dispatch(new LoadStateCodesFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
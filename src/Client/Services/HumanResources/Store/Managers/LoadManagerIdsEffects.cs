using AWC.Client.Utilities;
using AWC.Shared.Queries.Lookups.HumanResources;
using Fluxor;
using gRPC.Contracts.Lookups;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Services.HumanResources.Store.Managers
{
    public sealed class LoadManagerIdsEffects : Effect<LoadManagerIdAsyncAction>
    {
        private readonly GrpcChannel _channel;
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public LoadManagerIdsEffects
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

        public override async Task HandleAsync
        (
            LoadManagerIdAsyncAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                dispatcher.Dispatch(new SetManagerIDsLoadingFlagAction());

                var client = new LookupsContract.LookupsContractClient(_channel);
                var stream = client.GetManagerIds(new Empty()).ResponseStream;

                List<ManagerId> managers = new();

                while (await stream.MoveNext(default))
                {
                    grpc_ManagerId mgr = stream.Current;
                    managers.Add(_mapper.Map<ManagerId>(mgr));
                }

                action.TaskCompletionSource.SetResult(managers);

                dispatcher.Dispatch(new LoadManagerIdAsyncSuccessAction(managers));
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

                dispatcher.Dispatch(new LoadManagerIdAsyncFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
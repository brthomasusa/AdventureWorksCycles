using AWC.Client.Utilities;
using AWC.Shared.Queries.Lookups.HumanResources;
using Fluxor;
using gRPC.Contracts.Lookups;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Services.HumanResources.Store.Shifts
{
    public sealed class LoadShiftIdsEffects : Effect<LoadShiftIdAsyncAction>
    {
        private readonly GrpcChannel _channel;
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public LoadShiftIdsEffects
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
            LoadShiftIdAsyncAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                var client = new LookupsContract.LookupsContractClient(_channel);
                var stream = client.GetShiftIds(new Empty()).ResponseStream;

                List<ShiftId> shifts = new();

                while (await stream.MoveNext(default))
                {
                    grpc_ShiftId shift = stream.Current;
                    shifts.Add(_mapper.Map<ShiftId>(shift));
                }

                action.TaskCompletionSource.SetResult(shifts);

                dispatcher.Dispatch(new LoadShiftIdAsyncSuccessAction(shifts));
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

                dispatcher.Dispatch(new LoadShiftIdAsyncFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
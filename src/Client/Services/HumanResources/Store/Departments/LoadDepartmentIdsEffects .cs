using AWC.Client.Utilities;
using AWC.Shared.Queries.Lookups.HumanResources;
using Fluxor;
using gRPC.Contracts.Lookups;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace AWC.Client.Services.HumanResources.Store.Departments
{
    public sealed class LoadDepartmentIdsEffects : Effect<LoadDepartmentIdAsyncAction>
    {
        private readonly GrpcChannel _channel;
        private readonly IMapper _mapper;
        private readonly NotificationService _notificationService;

        public LoadDepartmentIdsEffects
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
            LoadDepartmentIdAsyncAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                var client = new LookupsContract.LookupsContractClient(_channel);
                var stream = client.GetDepartmentIds(new Empty()).ResponseStream;

                List<DepartmentId> departments = new();

                while (await stream.MoveNext(default))
                {
                    grpc_DepartmentId dept = (grpc_DepartmentId)stream.Current;
                    departments.Add(_mapper.Map<DepartmentId>(dept));
                }

                action.TaskCompletionSource.SetResult(departments);

                dispatcher.Dispatch(new LoadDepartmentIdAsyncSuccessAction(departments));
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

                dispatcher.Dispatch(new LoadDepartmentIdAsyncFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}
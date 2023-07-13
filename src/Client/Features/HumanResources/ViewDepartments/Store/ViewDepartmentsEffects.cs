using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using Fluxor;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;
using Radzen;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Store
{
    public class ViewDepartmentsEffects : Effect<GetDepartmentsAction>
    {
        private readonly GrpcChannel _channel;
        private readonly NotificationService _notificationService;
        private readonly IMapper _mapper;

        public ViewDepartmentsEffects
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
            GetDepartmentsAction action,
            IDispatcher dispatcher
        )
        {
            try
            {
                dispatcher.Dispatch(new SetLoadingFlagAction());

                var client = new CompanyContract.CompanyContractClient(_channel);
                grpc_GetCompanyDepartments grpcResponse =
                    await client.GetDepartmentsSearchByNameAsync(_mapper.Map<grpc_StringSearchCriteria>(action.SearchCriteria));

                List<DepartmentDetails> departments = new();
                grpcResponse.GrpcDepartments.ToList()
                                            .ForEach(grpcDept => departments.Add(_mapper.Map<DepartmentDetails>(grpcDept)));

                MetaData metaData = new()
                {
                    TotalCount = grpcResponse.GrpcMetaData["TotalCount"],
                    PageSize = grpcResponse.GrpcMetaData["PageSize"],
                    CurrentPage = grpcResponse.GrpcMetaData["CurrentPage"],
                    TotalPages = grpcResponse.GrpcMetaData["TotalPages"]
                };

                dispatcher.Dispatch(new GetDepartmentsSuccessAction(departments, metaData, action.SearchCriteria));
            }
            catch (Exception ex)
            {
                _notificationService!.Notify(
                    new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Style = "position: relative; left: -500px; top: 490px; width: 100%",
                        Detail = Helpers.GetExceptionMessage(ex),
                        Duration = 40000
                    }
                );

                dispatcher.Dispatch(new GetDepartmentsFailureAction(Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}

/*
message grpc_StringSearchCriteria {
    string search_field = 1;
	string search_criteria = 2;
    string order_by = 3;
	int32 page_number = 4;
	int32 page_size = 5;    
}
*/
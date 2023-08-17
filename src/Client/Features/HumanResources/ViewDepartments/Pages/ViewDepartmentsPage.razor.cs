using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace AWC.Client.Features.HumanResources.ViewDepartments.Pages
{
    public partial class ViewDepartmentsPage
    {
        private bool isLoading;
        private IEnumerable<DepartmentDetails>? departmentDetails;
        private int count;
        private readonly IEnumerable<int> pageSizeOptions = new List<int>() { 5, 10, 15, 20 };

        protected NotificationService? NotificationService { get; set; }

        [Inject] private GrpcChannel? GrpcChannel { get; set; }
        [Inject] private IMapper? Mapper { get; set; }

        protected async Task LoadDepartmentData(LoadDataArgs args)
        {
            try
            {
                string searchField = string.Empty;
                string searchCriteria = string.Empty;

                if (args.Filters is not null)
                {
                    List<FilterDescriptor> descriptors = args.Filters.ToList();
                    FilterDescriptor? filterDescriptor
                        = descriptors.Find(x => !string.IsNullOrEmpty(x.Property) && !string.IsNullOrEmpty(x.FilterValue.ToString()));

                    if (filterDescriptor is not null)
                    {
                        searchField = filterDescriptor.Property;
                        searchCriteria = filterDescriptor.FilterValue.ToString()!;
                    }
                }

                StringSearchCriteria criteria = new
                (
                    searchField,
                    searchCriteria,
                    !string.IsNullOrEmpty(args.OrderBy) ? args.OrderBy : string.Empty,
                    0,
                    0,
                    args.Skip ?? default,
                    args.Top ?? default
                );

                isLoading = true;

                await GetDepartments(criteria);

                isLoading = false;

                await InvokeAsync(StateHasChanged);

            }
            catch (Exception ex)
            {
                NotificationService!.Notify(
                    new NotificationMessage
                    {
                        Severity = NotificationSeverity.Error,
                        Style = "position: relative; left: -500px; top: 490px; width: 100%",
                        Detail = Helpers.GetExceptionMessage(ex),
                        Duration = 2500
                    }
                );
            }
        }

        private async Task GetDepartments(StringSearchCriteria criteria)
        {
            var client = new CompanyContract.CompanyContractClient(GrpcChannel);
            grpc_GetCompanyDepartments grpcResponse =
                await client.GetDepartmentsSearchByNameAsync(Mapper!.Map<grpc_StringSearchCriteria>(criteria));

            List<DepartmentDetails> departments = new();
            grpcResponse.GrpcDepartments.ToList()
                                        .ForEach(grpcDept => departments.Add(Mapper.Map<DepartmentDetails>(grpcDept)));

            departmentDetails = departments;
            count = grpcResponse.GrpcMetaData["TotalCount"];
        }
    }
}
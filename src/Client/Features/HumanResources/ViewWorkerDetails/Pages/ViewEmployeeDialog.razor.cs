using AWC.Client.Services;
using AWC.Client.Utilities;
using AWC.Shared.Queries.HumanResources;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Net.Client;
using MapsterMapper;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace AWC.Client.Features.HumanResources.ViewWorkerDetails.Pages
{
    public partial class ViewEmployeeDialog
    {
        private bool isLoading;
        private EmployeeDetails? employee;
        // private IEnumerable<AWC.Shared.Queries.HumanResources.PayHistory>? payHistories;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic>? Attributes { get; set; }
        [Parameter] public dynamic? BusinessEntityID { get; set; }
        [Inject] private DialogService? DialogService { get; set; }
        [Inject] private NotificationService? NotificationService { get; set; }
        [Inject] private GrpcChannel? GrpcChannel { get; set; }
        [Inject] private IMapper? Mapper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync()");
            await Load();
            await base.OnInitializedAsync();
        }

        private async Task Load()
        {
            isLoading = true;
            var client = new EmployeeContract.EmployeeContractClient(GrpcChannel);
            ItemRequest request = new() { Id = BusinessEntityID };

            grpc_EmployeeForDisplay grpcResponse = await client.GetEmployeeForDisplayAsync(request);

            employee = Mapper!.Map<EmployeeDetails>(grpcResponse);
            isLoading = false;
        }

        protected EmployeeDetails? Employee
        {
            get
            {
                return employee;
            }
            set
            {
                if (!object.Equals(employee, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "employee", NewValue = value, OldValue = employee };
                    employee = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        protected void CloseEmployeeDetailsDialog(MouseEventArgs args)
        {
            DialogService!.Close(null);
        }
    }
}
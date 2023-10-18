using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Services.HumanResources.Store;
using AWC.Client.Services.HumanResources.Store.Departments;
using AWC.Client.Services.HumanResources.Store.Shifts;
using AWC.Client.Utilities;
using AWC.Shared.Queries.Lookups.HumanResources;
using Fluxor;

namespace AWC.Client.Services.HumanResources
{
    public sealed class CompanyRepositoryService : ICompanyRepositoryService
    {
        private readonly IDispatcher? _dispatcher;
        private readonly IState<DepartmentIdLookupState>? _departmentLookupState;
        private readonly IState<ShiftIdLookupState>? _shiftLookupState;

        public CompanyRepositoryService
        (
            IDispatcher dispatcher,
            IState<DepartmentIdLookupState> departmentLookupState,
            IState<ShiftIdLookupState> shiftLookupState
        )
        {
            _dispatcher = dispatcher;
            _departmentLookupState = departmentLookupState;
            _shiftLookupState = shiftLookupState;
        }

        public async Task<Result<List<DepartmentId>>> GetDepartmentIDs()
        {
            try
            {
                if (!_departmentLookupState!.Value.DepartmentIds!.Any())
                {
                    TaskCompletionSource<List<DepartmentId>> tcs = new();
                    _dispatcher!.Dispatch(new LoadDepartmentIdAsyncAction(tcs));
                    await tcs.Task;
                    return tcs.Task.Result;
                }
                else
                {
                    return _departmentLookupState!.Value.DepartmentIds!;
                }
            }
            catch (Exception ex)
            {
                return Result<List<DepartmentId>>.Failure<List<DepartmentId>>(new Error(
                    "CompanyRepositoryService.GetDepartmentIDs",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }

        public async Task<Result<List<ShiftId>>> GetShiftIDs()
        {
            try
            {
                if (!_shiftLookupState!.Value.ShiftIds!.Any())
                {
                    TaskCompletionSource<List<ShiftId>> tcs = new();
                    _dispatcher!.Dispatch(new LoadShiftIdAsyncAction(tcs));
                    await tcs.Task;
                    return tcs.Task.Result;
                }
                else
                {
                    return _shiftLookupState!.Value.ShiftIds!;
                }
            }
            catch (Exception ex)
            {
                return Result<List<ShiftId>>.Failure<List<ShiftId>>(new Error(
                    "CompanyRepositoryService.GetShiftIDs",
                    Helpers.GetExceptionMessage(ex))
                );
            }
        }
    }
}
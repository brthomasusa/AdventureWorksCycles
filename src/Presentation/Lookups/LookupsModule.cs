using AWC.Application.Lookups.HumanResources.GetDepartmentIds;
using AWC.Application.Lookups.HumanResources.GetManagerIds;
using AWC.Application.Lookups.HumanResources.GetShiftIds;
using AWC.Application.Lookups.Shared.GetCountryCodes;
using AWC.Application.Lookups.Shared.GetStateCodesForAll;
using AWC.Application.Lookups.Shared.GetStateCodesForUSA;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;
using AWC.SharedKernel.Utilities;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace REA.Accounting.Presentation.Lookups
{
    public sealed class LookupsModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/lookups/statecodes/all", async (ISender sender) =>
            {
                Result<List<StateCode>> result = await sender.Send(new GetStateCodeIdForAllRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/lookups/statecodes/usa", async (ISender sender) =>
            {
                Result<List<StateCode>> result = await sender.Send(new GetStateCodeIdForUsaRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/lookups/countrycodes", async (ISender sender) =>
            {
                Result<List<CountryCode>> result = await sender.Send(new GetCountryCodesRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/lookups/departmentids", async (ISender sender) =>
            {
                Result<List<DepartmentId>> result = await sender.Send(new GetDepartmentIdsRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/lookups/shiftids", async (ISender sender) =>
            {
                Result<List<ShiftId>> result = await sender.Send(new GetShiftIdsRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/lookups/managerids", async (ISender sender) =>
            {
                Result<List<ManagerId>> result = await sender.Send(new GetManagerIdsRequest());

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });
        }
    }
}
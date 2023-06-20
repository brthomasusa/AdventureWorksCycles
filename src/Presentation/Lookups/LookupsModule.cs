using AWC.Application.Lookups.GetDepartmentIds;
using AWC.Application.Lookups.GetShiftIds;
using AWC.Application.Lookups.GetStateCodesForAll;
using AWC.Application.Lookups.GetStateCodesForUSA;
using AWC.Shared.Queries.Lookups;
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
                Result<List<StateCode>> result = await sender.Send(new GetStateCodeIdForUSARequest());

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
        }
    }
}
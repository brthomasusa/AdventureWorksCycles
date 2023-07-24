using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Application.Features.HumanResources.ViewEmployeeDetails;
using AWC.Application.Features.HumanResources.ViewEmployees;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AWC.Presentation.HumanResources.Employee
{
    public sealed class EmployeeModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/employees/details/{id}", async (int id, ISender sender) =>
            {
                Result<EmployeeDetails> result =
                    await sender.Send(new GetEmployeeDetailsRequest(EmployeeID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/employees/command/{id}", async (int id, ISender sender) =>
            {
                Result<EmployeeGenericCommand> result =
                    await sender.Send(new GetEmployeeCommandRequest(EmployeeID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/employees/filterbylastname", async (QueryParameters.FilterByFieldNameParameters parameters, ISender sender) =>
            {
                StringSearchCriteria criteria = new
                (
                    parameters.SearchField,
                    parameters.SearchCriteria,
                    parameters.OrderBy,
                    parameters.PageNumber,
                    parameters.PageSize,
                    parameters.Skip,
                    parameters.Take
                );


                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetEmployeeListItemsRequest request = new(SearchCriteria: criteria);

                Result<PagedList<EmployeeListItem>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapPost("api/employees/create", async (CreateEmployeeCommand cmd, ISender sender) =>
            {
                Result<int> result = await sender.Send(cmd);

                if (result.IsSuccess)
                {
                    return Results.Created($"api/employees/allinfo/{result.Value}", new GetEmployeeDetailsRequest(EmployeeID: result.Value));
                }

                return Results.Problem(result.Error);
            });

            app.MapPut("api/employees/update", async (UpdateEmployeeCommand cmd, ISender sender) =>
            {
                Result<int> result = await sender.Send(cmd);

                if (result.IsSuccess)
                    return Results.Ok();

                return Results.Problem(result.Error);
            });

            app.MapDelete("api/employees/delete", async ([FromBody] DeleteEmployeeCommand cmd, ISender sender) =>
            {
                Result<int> result = await sender.Send(cmd);

                if (result.IsSuccess)
                    return Results.Ok();

                return Results.Problem(result.Error);
            });
        }
    }
}
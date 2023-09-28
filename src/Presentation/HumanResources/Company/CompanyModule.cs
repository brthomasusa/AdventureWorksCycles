using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace AWC.Presentation.HumanResources.Company
{
    public sealed class CompanyModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/companies/details/{id}", async (int id, ISender sender) =>
            {
                Result<CompanyDetails> result = await sender.Send(new GetCompanyDetailsRequest(CompanyID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/command/{id}", async (int id, ISender sender) =>
            {
                Result<CompanyGenericCommand> result = await sender.Send(new GetCompanyCommandRequest(CompanyID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/departments", async (QueryParameters.PaginationParameters parameters, ISender sender) =>
            {
                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetCompanyDepartmentsRequest request = new(PagingParameters: pagingParameters);
                Result<PagedList<DepartmentDetails>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/departments/filterbyname", async (QueryParameters.FilterByFieldNameParameters parameters, ISender sender) =>
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

                GetCompanyDepartmentsFilteredRequest request = new(SearchCriteria: criteria);

                Result<PagedList<DepartmentDetails>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/shifts", async (QueryParameters.PaginationParameters parameters, ISender sender) =>
            {
                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetCompanyShiftsRequest request = new(PagingParameters: pagingParameters);
                Result<PagedList<ShiftDetails>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapPut("api/companies/update", async (UpdateCompanyCommand cmd, ISender sender) =>
            {
                Console.WriteLine($"CompanyID: {cmd.CompanyID}");
                Result<int> result = await sender.Send(cmd);

                if (result.IsSuccess)
                    return Results.Ok();

                return Results.Problem(result.Error);
            });
        }
    }
}

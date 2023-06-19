using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
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
                Result<GetCompanyDetailByIdResponse> result = await sender.Send(new GetCompanyDetailByIdRequest(CompanyID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/command/{id}", async (int id, ISender sender) =>
            {
                Result<GetCompanyCommandByIdResponse> result = await sender.Send(new GetCompanyCommandByIdRequest(CompanyID: id));

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/departments", async (QueryParameters.PaginationParameters parameters, ISender sender) =>
            {
                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetCompanyDepartmentsRequest request = new(PagingParameters: pagingParameters);
                Result<PagedList<GetCompanyDepartmentsResponse>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/departments/filterbyname", async (QueryParameters.FilterDepartmentByNameParameters parameters, ISender sender) =>
            {
                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetCompanyDepartmentsSearchByNameRequest request = new(DepartmentName: parameters.DepartmentName!, PagingParameters: pagingParameters);

                Result<PagedList<GetCompanyDepartmentsResponse>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapGet("api/companies/shifts", async (QueryParameters.PaginationParameters parameters, ISender sender) =>
            {
                PagingParameters pagingParameters = new(parameters.PageNumber, parameters.PageSize);
                GetCompanyShiftsRequest request = new(PagingParameters: pagingParameters);
                Result<PagedList<GetCompanyShiftsResponse>> result = await sender.Send(request);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.Problem(result.Error);
            });

            app.MapPut("api/companies/update", async (UpdateCompanyCommand cmd, ISender sender) =>
            {
                Result<int> result = await sender.Send(cmd);

                if (result.IsSuccess)
                    return Results.Ok();

                return Results.Problem(result.Error);
            });
        }
    }
}

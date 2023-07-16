using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.Application.Features.HumanResources.ViewCompanyDepartments;
using AWC.Application.Features.HumanResources.ViewCompanyDetails;
using AWC.Application.Features.HumanResources.ViewCompanyShifts;
using AWC.Shared.Queries.HumanResources;
using AWC.Shared.Queries.Shared;
using AWC.SharedKernel.Utilities;
using gRPC.Contracts.HumanResources;
using gRPC.Contracts.Shared;
using Grpc.Core;
using MapsterMapper;
using MediatR;

namespace AWC.Server.Contracts
{
    public sealed class CompanyContractService : CompanyContract.CompanyContractBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public CompanyContractService(ISender sender, IMapper mapper)
            => (_sender, _mapper) = (sender, mapper);

        public override async Task<grpc_CompanyForDisplay> GetCompanyForDisplay(ItemRequest request, ServerCallContext context)
        {
            Result<CompanyDetails> result = await _sender.Send(new GetCompanyDetailsRequest(CompanyID: request.Id));
            return _mapper.Map<grpc_CompanyForDisplay>(result.Value);
        }

        public override async Task<grpc_CompanyGenericCommand> GetCompanyForEdit(ItemRequest request, ServerCallContext context)
        {
            Result<CompanyGenericCommand> result = await _sender.Send(new GetCompanyCommandRequest(CompanyID: request.Id));
            return _mapper.Map<grpc_CompanyGenericCommand>(result.Value);
        }

        public override async Task<grpc_GetCompanyDepartments> GetDepartmentsSearchByName(grpc_StringSearchCriteria request, ServerCallContext context)
        {
            StringSearchCriteria criteria = new
            (
                request.SearchField,
                request.SearchCriteria,
                request.OrderBy,
                request.PageNumber,
                request.PageSize,
                request.Skip,
                request.Take
            );

            GetCompanyDepartmentsFilteredRequest requestParameter = new(criteria);

            Result<PagedList<DepartmentDetails>> result = await _sender.Send(requestParameter);

            grpc_GetCompanyDepartments grpcDepartmentContainer = new();
            List<grpc_Department> grpcDepartmentListItems = new();

            result.Value.ToList().ForEach(dept =>
                grpcDepartmentListItems.Add(_mapper.Map<grpc_Department>(dept))
            );

            grpcDepartmentContainer.GrpcDepartments.AddRange(grpcDepartmentListItems);
            grpcDepartmentContainer.GrpcMetaData.Add(Helpers.LoadMetaData(result.Value.MetaData));

            return grpcDepartmentContainer;
        }

        public override async Task<grpc_GetCompanyShifts> GetShifts(grpc_PagingParameters request, ServerCallContext context)
        {
            PagingParameters pagingParameters = new(request.PageNumber, request.PageSize);
            GetCompanyShiftsRequest shiftsRequest = new(PagingParameters: pagingParameters);
            Result<PagedList<ShiftDetails>> getShiftsResult = await _sender.Send(shiftsRequest);

            grpc_GetCompanyShifts grpcResponse = new();
            List<grpc_Shift> grpcShiftList = new();

            getShiftsResult.Value.ForEach(shift => grpcShiftList.Add(_mapper.Map<grpc_Shift>(shift)));

            grpcResponse.GrpcShifts.AddRange(grpcShiftList);
            grpcResponse.GrpcMetaData.Add(Helpers.LoadMetaData(getShiftsResult.Value.MetaData));

            return grpcResponse;
        }

        public override async Task<GenericResponse> Update(grpc_CompanyGenericCommand request, ServerCallContext context)
        {
            UpdateCompanyCommand cmd = _mapper.Map<UpdateCompanyCommand>(request);

            Result<int> result = await _sender.Send(cmd);

            if (result.IsFailure)
                return new GenericResponse { Success = false };

            return new GenericResponse { Success = true };
        }
    }
}
using AWC.Shared.Queries.Shared;
using gRPC.Contracts.Shared;
using Mapster;

namespace AWC.Server.Mapping.Shared
{
    public sealed class SharedMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination>

            config.NewConfig<grpc_StringSearchCriteria, StringSearchCriteria>()
                .Map(dest => dest.SearchField, src => src.SearchField)
                .Map(dest => dest.SearchCriteria, src => src.SearchCriteria)
                .Map(dest => dest.OrderBy, src => src.OrderBy)
                .Map(dest => dest.SearchField, src => src.SearchField)
                .Map(dest => dest.PageNumber, src => src.PageNumber)
                .Map(dest => dest.PageSize, src => src.PageSize)
                .Map(dest => dest.Skip, src => src.Skip)
                .Map(dest => dest.Take, src => src.Take);
        }
    }
}
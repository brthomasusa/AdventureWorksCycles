using AWC.Shared.Queries.Shared;
using gRPC.Contracts.Shared;
using Mapster;

namespace AWC.Client.Utilities.Mapping
{
    public sealed class SharedMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {
            // TypeAdapterConfig<TSource, TDestination>

            config.NewConfig<StringSearchCriteria, grpc_StringSearchCriteria>()
                .Map(dest => dest.SearchField, src => src.SearchField)
                .Map(dest => dest.SearchCriteria, src => src.SearchCriteria)
                .Map(dest => dest.OrderBy, src => src.OrderBy)
                .Map(dest => dest.SearchField, src => src.SearchField)
                .Map(dest => dest.PageNumber, src => src.PageNumber)
                .Map(dest => dest.PageSize, src => src.PageSize);
        }
    }
}
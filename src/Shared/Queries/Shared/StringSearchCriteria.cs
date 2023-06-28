namespace AWC.Shared.Queries.Shared
{
    public sealed record StringSearchCriteria
    (
        string? SearchField,
        string? SearchCriteria,
        string? OrderBy,
        int PageNumber,
        int PageSize
    );
}
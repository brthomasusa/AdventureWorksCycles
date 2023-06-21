using AWC.Application.Interfaces.Messaging;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.Application.Lookups.Shared.GetCountryCodes
{
    public sealed record GetCountryCodesRequest() : IQuery<List<CountryCode>>;
}
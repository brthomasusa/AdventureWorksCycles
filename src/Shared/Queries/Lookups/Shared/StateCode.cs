using System.Security.Cryptography.X509Certificates;

namespace AWC.Shared.Queries.Lookups.Shared
{
    public sealed class StateCode
    {
        public int StateProvinceID { get; set; }
        public string? StateProvinceCode { get; set; }
        public string? StateProvinceName { get; set; }
    }
}
using AWC.Client.Utilities;

namespace AWC.Client.Interfaces.Shared
{
    public interface IMetaDataService
    {
        event Action OnChange;
        Result AddMetaData(string key, MetaData metaData);
        Result DeleteMetaData(string key);
        Result<MetaData> GetMetaData(string key);
    }
}
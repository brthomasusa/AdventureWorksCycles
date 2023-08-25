using AWC.Client.Interfaces.HumanResources;
using AWC.Client.Interfaces.Shared;
using AWC.Client.Utilities;

namespace AWC.Client.Services.HumanResources
{
    public sealed class HumanResourcesMetaDataService : IHumanResourcesMetaDataService
    {
        private Dictionary<string, MetaData>? _metaData = new();

        public event Action? OnChange;

        public Result AddMetaData(string key, MetaData metaData)
        {
            try
            {
                if (_metaData!.ContainsKey(key))
                {
                    _metaData[key] = metaData;
                }
                else
                {
                    _metaData!.Add(key, metaData);
                    NotifyStateChanged();
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("HumanResourcesMetaDataService.AddMetaData", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result DeleteMetaData(string key)
        {
            if (_metaData!.ContainsKey(key))
            {
                _metaData.Remove(key);
                NotifyStateChanged();
                return Result.Success();
            }
            else
            {
                return Result<MetaData>.Failure<MetaData>(
                    new Error("HumanResourcesMetaDataService.GetMetaData", $"Delete failed. MetaData for {key} not found.")
                );
            }
        }

        public Result<MetaData> GetMetaData(string key)
        {
            if (_metaData!.ContainsKey(key))
            {
                return _metaData[key];
            }
            else
            {
                return Result<MetaData>.Failure<MetaData>(
                    new Error("HumanResourcesMetaDataService.GetMetaData", $"MetaData for {key} not found.")
                );
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
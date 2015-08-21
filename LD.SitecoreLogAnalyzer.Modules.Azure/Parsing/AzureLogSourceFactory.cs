using Sitecore.LogAnalyzer.Parsing;
using Sitecore.LogAnalyzer.Settings;
using System.Collections.Generic;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureLogSourceFactory : ILogSourceFactory
    {
        public ILogSource GetSource(IConnectionSettings connectionSettings)
        {
            AzureConnectionSettings azureConnectionSettings = connectionSettings as AzureConnectionSettings;
            azureConnectionSettings = new AzureConnectionSettings(azureConnectionSettings.StorageName, azureConnectionSettings.StorageKey, true, azureConnectionSettings.QueryFilter, azureConnectionSettings.StartTimeFilter, azureConnectionSettings.EndTimeFilter, azureConnectionSettings.RoleFilter, azureConnectionSettings.RoleInstanceFilter);
            return new AzureLogSource(azureConnectionSettings);
        }

        public IEnumerable<ILogSource> GetSources(IConnectionSettings settings)
        {
            return new List<ILogSource> { GetSource(settings) };
        }
    }
}

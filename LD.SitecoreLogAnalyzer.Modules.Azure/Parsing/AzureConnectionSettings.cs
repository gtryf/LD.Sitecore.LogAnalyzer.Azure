using Sitecore.LogAnalyzer.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureConnectionSettings : IConnectionSettings
    {
        public string StorageName { get; }

        public string StorageKey { get; }

        public bool UseHttps { get; }

        public string QueryFilter { get; }

        public DateTime StartTimeFilter { get; }

        public DateTime EndTimeFilter { get; }

        public string[] RoleFilter { get; }

        public string[] RoleInstanceFilter { get; }

        public string ConnectionDetailsString
        {
            get
            {
                var roleFilters = string.Empty;
                var roleInstanceFilters = string.Empty;
                if (RoleFilter?.Length > 0)
                    roleFilters = string.Join("|", RoleFilter);

                if (RoleInstanceFilter?.Length > 0)
                    roleInstanceFilters = string.Join("|", RoleInstanceFilter);

                return string.Format(CultureInfo.InvariantCulture, "SName={0}&SKey={1}&Https={2}&Filter={3}&StartTime={4:G}&EndTime={5:G}&Roles={6}&RoleInstances={7}", new object[]
                {
                    this.StorageName,
                    this.StorageKey,
                    this.UseHttps,
                    this.QueryFilter,
                    this.StartTimeFilter,
                    this.EndTimeFilter,
                    roleFilters,
                    roleInstanceFilters
                });
            }
        }

        public AzureConnectionSettings(string storageName, string storageKey, bool useHttps, string queryFilter, DateTime startTimeFilter, DateTime endTimeFilter, string[] roleFilter, string[] roleInstanceFilter)
        {
            this.StorageName = storageName;
            this.StorageKey = storageKey;
            this.UseHttps = useHttps;
            this.QueryFilter = queryFilter;
            this.StartTimeFilter = startTimeFilter;
            this.EndTimeFilter = endTimeFilter;
            this.RoleFilter = roleFilter;
            this.RoleInstanceFilter = roleInstanceFilter;
        }
    }
}

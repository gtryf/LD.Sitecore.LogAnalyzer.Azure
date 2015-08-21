using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Sitecore.LogAnalyzer.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureLogSource : LogSourceBase, IEnumerable<string[]>, IEnumerable
    {
        private readonly IEnumerator<string[]> list;

        public AzureLogSource(AzureConnectionSettings settings)
        {
            list = LoadLinesWithMetadata(settings).GetEnumerator();
            base.NumberOfLinesReadToNotifyOfProgress = 1500u;
        }

        public override void Dispose()
        {
            if (list != null)
            {
                list.Dispose();
            }
        }

        public override IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string[]>)this).Select(x => x.First()).GetEnumerator();
        }

        IEnumerator<string[]> IEnumerable<string[]>.GetEnumerator()
        {
            return this.list;
        }

        protected virtual IEnumerable<string[]> LoadLinesWithMetadata(AzureConnectionSettings settings)
        {
            CloudTable cloudTable = BuildTable(settings, "WADLogsTable");
            TableQuery tableQuery = BuildQuery(settings);
            tableQuery.Select(new List<string>
            {
                "Message",
                "EventTickCount",
                "Role",
                "RoleInstance"
            });
            EntityResolver<string[]> resolver = (string key, string rowKey, DateTimeOffset timestamp, IDictionary<string, EntityProperty> properties, string etag) =>
            {
                CurrentLogDate = timestamp.Date;
                LinesReadFromSource += 1uL;
                return new string[]
                {
                    properties["Message"].StringValue,
                    properties["EventTickCount"].Int64Value?.ToString(),
                    properties["Role"].StringValue,
                    properties["RoleInstance"].StringValue
                };
            };
            return cloudTable.ExecuteQuery(tableQuery, resolver, null, null);
        }

        protected virtual CloudTable BuildTable(AzureConnectionSettings settings, string tableName)
        {
            StorageCredentials storageCredentials = new StorageCredentials(settings.StorageName, settings.StorageKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(storageCredentials, settings.UseHttps);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            return cloudTableClient.GetTableReference(tableName);
        }

        protected virtual TableQuery BuildQuery(AzureConnectionSettings settings)
        {
            var tableQuery = new TableQuery();
            // Text filter
            string filterText = settings.QueryFilter.Trim();

            // Min time filter
            if (settings.StartTimeFilter != DateTime.MinValue)
            {
                var ticks = TimeZoneInfo.ConvertTimeToUtc(settings.StartTimeFilter).Ticks;
                var startTimeFilterCondition = TableQuery.GenerateFilterCondition("PartitionKey", "ge", "0" + ticks);
                filterText = !string.IsNullOrEmpty(filterText) ? TableQuery.CombineFilters(filterText, "and", startTimeFilterCondition) : startTimeFilterCondition;
            }

            // Max time filter
            if (settings.EndTimeFilter != DateTime.MinValue)
            {
                var ticks = TimeZoneInfo.ConvertTimeToUtc(settings.EndTimeFilter).Ticks;
                var endTimeFilterCondition = TableQuery.GenerateFilterCondition("PartitionKey", "le", "0" + ticks);
                filterText = !string.IsNullOrEmpty(filterText) ? TableQuery.CombineFilters(filterText, "and", endTimeFilterCondition) : endTimeFilterCondition;
            }

            // Role filter
            if (settings.RoleFilter?.Length > 0)
            {
                var roleFilterCondition = settings.RoleFilter.Aggregate(string.Empty, (acc, x) => TableQuery.CombineFilters(acc, "or", TableQuery.GenerateFilterCondition("Role", "eq", x)));
                filterText = !string.IsNullOrEmpty(filterText) ? TableQuery.CombineFilters(filterText, "and", roleFilterCondition) : roleFilterCondition;
            }

            // Role instance filter
            if (settings.RoleInstanceFilter?.Length > 0)
            {
                var roleInstanceFilterCondition = settings.RoleInstanceFilter.Aggregate(string.Empty, (acc, x) => TableQuery.CombineFilters(acc, "or", TableQuery.GenerateFilterCondition("RoleInstance", "eq", x)));
                filterText = !string.IsNullOrEmpty(filterText) ? TableQuery.CombineFilters(filterText, "and", roleInstanceFilterCondition) : roleInstanceFilterCondition;
            }

            tableQuery.FilterString = filterText;
            return tableQuery;
        }
    }
}

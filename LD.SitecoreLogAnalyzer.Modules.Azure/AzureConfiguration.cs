using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure
{
    public static class AzureConfiguration
    {
        public static string StorageName { get; set; } 
       
        public static string StorageKey { get; set; }

        public static string RoleFilter { get; set; }

        public static string RoleInstanceFilter { get; set; }

        public static string QueryFilter { get; set; }

        public static string StartTimeFilter { get; set; }

        public static string EndTimeFilter { get; set; }

        static AzureConfiguration()
        {
            var configFileName = "LD.SitecoreLogAnalyzer.Modules.Azure.config";
            if (!File.Exists(configFileName))
                configFileName = "SitecoreLogAnalyzer.Modules.Azure.config";
            var elements = XDocument.Load(configFileName).Descendants("setting");
            Func<string, string> RetrieveSetting = 
                name => 
                    elements.First(x => x.Attribute("name") != null && 
                    x.Attribute("name").Value == name).Attribute("value").Value;

            StorageName = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.StorageName");
            StorageKey = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.StorageKey");
            RoleFilter = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.RoleFilter");
            RoleInstanceFilter = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.RoleInstanceFilter");
            QueryFilter = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.QueryFilter");
            StartTimeFilter = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.StartTimeFilter");
            EndTimeFilter = RetrieveSetting("Sitecore.LogAnalyzer.Modules.Azure.EndTimeFilter");
        }
    }
}

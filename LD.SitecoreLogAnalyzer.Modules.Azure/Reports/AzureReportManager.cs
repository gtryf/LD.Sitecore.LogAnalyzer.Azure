using LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing;
using Sitecore.LogAnalyzer.Managers;
using Sitecore.LogAnalyzer.Reports;
using Sitecore.LogAnalyzer.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Reports
{
    public class AzureReportManager : ReportManager
    {
        public AzureReportManager(IGeneralManager generalManager, IIntervalReportManager intervalReportManager) 
            : base(generalManager, intervalReportManager)
        {
        }

        protected override string GetInstanceName(ProcessContext context)
        {
            AzureConnectionSettings azureConnectionSettings = context.Settings.ConnectionSettings as AzureConnectionSettings;
            if (azureConnectionSettings != null)
            {
                string storageName = azureConnectionSettings.StorageName;
                return base.GetSHA1(storageName).Substring(0, 32);
            }
            return base.GetInstanceName(context);
        }
    }
}

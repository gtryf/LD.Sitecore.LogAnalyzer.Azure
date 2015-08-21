using LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing;
using LD.Sitecore.LogAnalyzer.Modules.Azure.Reports;
using Ninject.Modules;
using Sitecore.LogAnalyzer.Managers;
using Sitecore.LogAnalyzer.Parsing;
using Sitecore.LogAnalyzer.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.SitecoreLogAnalyzer.Modules.Azure
{
    public class AzureDIModule : NinjectModule
    {
        public override void Load()
        {
            Rebind<IGeneralManager>().To<GeneralManager>().InSingletonScope();
            Rebind<ILogSourceFactory>().To<AzureLogSourceFactory>().InSingletonScope();
            Rebind<ILogReader>().To<AzureLogReader>().InSingletonScope();
            Rebind<ILogParser>().To<AzureLogParser>().InSingletonScope();
            Rebind<IErrorParser>().To<AzureErrorParser>().InSingletonScope();
            Rebind<IHealthMonitorParser>().To<AzureHealthMonitorParser>().InSingletonScope();

            Rebind<IReportManager>().To<AzureReportManager>().InSingletonScope();
        }
    }
}

using Sitecore.LogAnalyzer.Models;
using Sitecore.LogAnalyzer.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureHealthMonitorParser : HealthMonitorParser
    {
        private const string TraceSourceString = "; TraceSource 'w3wp.exe' event";
        public override HealthMonitorDetails ParseHealthMonitor(string text, TextStorage storage)
        {
            if (text.EndsWith(TraceSourceString))
                text = text.Replace(TraceSourceString, string.Empty);

            return base.ParseHealthMonitor(text, storage);
        }
    }
}

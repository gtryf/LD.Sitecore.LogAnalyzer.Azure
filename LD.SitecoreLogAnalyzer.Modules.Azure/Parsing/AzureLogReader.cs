using Sitecore.LogAnalyzer.Models;
using Sitecore.LogAnalyzer.Parsing;
using Sitecore.LogAnalyzer.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureLogReader : LogReader
    {
        private readonly ILogParser logParser;

        public AzureLogReader(ILogParser logParser, IAuditParser auditParser, IErrorParser errorParser, IHealthMonitorParser healthMonitorParser) : base(logParser, auditParser, errorParser, healthMonitorParser)
        {
            this.logParser = logParser;
        }

        public override ParsingResult ParseLogs(ILogSource source, LogReaderSettings settings)
        {
            if (AzureSourceStateStorage.ParsingResultWithoutFiltering == null)
                AzureSourceStateStorage.ParsingResultWithoutFiltering = base.ParseLogs(source, null);

            ParsingResult result = FilterLogs(AzureSourceStateStorage.ParsingResultWithoutFiltering, settings);
            return ReorginizeParsingResult(result);
        }

        protected override ParsingResult SearchKernelInfo(ParsingResult result)
        {
            ParsingResult parsingResult = base.SearchKernelInfo(result);
            int semicolonIndex = parsingResult.SitecoreVersion.IndexOf("; TraceSource", StringComparison.InvariantCultureIgnoreCase);
            if (semicolonIndex != -1)
            {
                parsingResult.SitecoreVersion = parsingResult.SitecoreVersion.Remove(semicolonIndex).TrimEnd('\n', '\r');
            }
            return parsingResult;
        }

        private ParsingResult FilterLogs(ParsingResult parsingResultWithoutFiltering, LogReaderSettings settings)
        {
            ParsingResult parsingResult = new ParsingResult();
            foreach (var entry in parsingResultWithoutFiltering.All)
            {
                bool matchesFilter = false;
                ApplyFilter(entry.LogDateTime, settings, entry.ToString(), ref matchesFilter, false);
                if (matchesFilter)
                    parsingResult.AddToGroupAll(entry);
            }
            return parsingResult;
        }

        protected override ParsingResult ParseSource(ILogSource source, LogReaderSettings settings, ParsingResult result = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            
            TextStorage storage = new TextStorage();
            result = result ?? new ParsingResult();
            var log = (IEnumerable<string[]>)source;
            if (!(source is AzureLogSource))
                throw new ApplicationException("Non Azure log source was tried to be parsed by Azure log reader");
            
            foreach (var lines in log)
            {
                var logEntry = logParser.ParseLine(lines[0], new DateTime(long.Parse(lines[1])), storage);
                if (logEntry != null)
                {
                    logEntry = AnalyzeLog(logEntry, storage);
                    result.AddToGroupAll(logEntry);
                }
            }
            return result;
        }
    }
}

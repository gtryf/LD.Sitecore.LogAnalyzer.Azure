using Sitecore.LogAnalyzer.Models;
using Sitecore.LogAnalyzer.Parsing;
using Sitecore.LogAnalyzer;
using System;
using System.Globalization;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureLogParser : LogParser
    {
        protected const string StandardTraceSource = "\n; TraceSource 'w3wp.exe' event";

        public override LogEntry ParseLine(string line, DateTime startDateTime, TextStorage storage)
        {
            if (ContainsStandardTracesource(line))
                line = line.Substring(0, line.Length - StandardTraceSource.Length);

            LogEntry logEntry = base.ParseLine(line, startDateTime, storage);
            if (logEntry != null)
                logEntry.LinesCount = logEntry.Text.GetLinesCount();
            
            return logEntry;
        }

        protected bool ContainsStandardTracesource(string line) => line.EndsWith(StandardTraceSource);

        protected override DateTime? GetDateTime(string line, ref int index, DateTime startDateTime)
        {
            DateTime result;
            if (index + 18 >= line.Length) return null;
            var candidate = line.Substring(index, 19);
            if (!DateTime.TryParseExact(candidate, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                return null;
            
            index = ParserHelper.GoToNextWord(line, index + 19);
            return result;
        }
    }
}

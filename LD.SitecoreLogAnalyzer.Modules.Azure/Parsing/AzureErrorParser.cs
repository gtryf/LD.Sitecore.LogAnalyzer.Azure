using Sitecore.LogAnalyzer.Models;
using Sitecore.LogAnalyzer.Parsing;
using Sitecore.LogAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing
{
    public class AzureErrorParser : SmartErrorParser
    {
        public static readonly string TraceSourceHeader = Environment.NewLine + "; TraceSource";

        private static readonly string[] headers = new string[]
        {
            ExceptionHeader,
            MessageHeader,
            SourceHeader,
            NestedExceptionHeader,
            TraceSourceHeader
        };

        protected virtual string[] Headers
        {
            get
            {
                return headers;
            }
        }

        protected override Substring GetHeaderText(string text, string startHeader, string[] finishHeaders, bool withHeader = false)
        {
            var headerText = base.GetHeaderText(text, startHeader, finishHeaders, withHeader);
            if (finishHeaders != null && !headerText.IsEmpty())
            {
                string text2 = text.Substring(headerText);
                var dictionary = new Dictionary<string, int>();
                string[] array = Headers;
                for (int i = 0; i < array.Length; i++)
                {
                    string text3 = array[i];
                    int num = text2.IndexOf(text3);
                    if (num != -1)
                    {
                        dictionary.Add(text3, num);
                    }
                }
                if (dictionary.Count > 0)
                {
                    KeyValuePair<string, int> keyValuePair = new KeyValuePair<string, int>(null, 2147483647);
                    foreach (KeyValuePair<string, int> current in dictionary)
                    {
                        if (keyValuePair.Value > current.Value)
                        {
                            keyValuePair = current;
                        }
                    }
                    headerText = this.GetHeaderText(text, startHeader, new string[]
                    {
                        keyValuePair.Key
                    }, withHeader);
                }
            }
            return headerText;
        }
    }
}

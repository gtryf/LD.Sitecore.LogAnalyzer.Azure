# LD.Sitecore.LogAnalyzer.Azure
A better version of the Azure module for Sitecore Log Analyzer.

This module is meant to replace the default Azure plugin that comes with 
[Sitecore Log Analyzer](https://marketplace.sitecore.net/Modules/S/Sitecore_Log_Analyzer.aspx). The problem with the original
plugin is that the date/time filter is performed on the `Timestamp` column for the `WADLogsTable` table on your Azure table storage.
This is a no-no, as this column is not indexed, so in effect the query amounts to a simple table scan. For chatty logs, this
may take hours to process, or even fail altogether.

This plugin performs the query the right way, i.e. it queries on the `PartitionKey` column which *is* indexed. The performance
benefit is many-fold.

## Installation
Edit SitecoreLogAnalyzer.config, and add the following in the `configuration/modules` section:

```xml
<add name="Azure Storage Table (LD)" assembly="LD.SitecoreLogAnalyzer.Modules.Azure">
  <invoker type="LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation.AzureSourceInvoker, LD.SitecoreLogAnalyzer.Modules.Azure.Present" image="..\Resources\Azure.png"></invoker>
</add>
```

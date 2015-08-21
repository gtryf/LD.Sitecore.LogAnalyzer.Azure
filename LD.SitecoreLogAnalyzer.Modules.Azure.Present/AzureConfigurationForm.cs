using LD.Sitecore.LogAnalyzer.Modules.Azure.Parsing;
using System;
using System.Windows.Forms;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation
{
    public partial class AzureConfigurationForm : Form
    {
        public AzureConnectionSettings ConnectionSettings { get; private set; }

        public AzureConfigurationForm()
        {
            InitializeComponent();
            azureManualConfigurationControl1.OkClick += SaveManualConfigurationSettings;
        }

        protected virtual void SaveManualConfigurationSettings(object sender, EventArgs e)
        {
            var azureManualConfigurationControl = (AzureManualConfigurationControl)sender;
            if (string.IsNullOrEmpty(azureManualConfigurationControl.StorageName) || string.IsNullOrEmpty(azureManualConfigurationControl.StorageKey))
            {
                MessageBox.Show("StorageName and StorageKey cannot be empty.");
                return;
            }
            if (azureManualConfigurationControl.StartTimeFilter > azureManualConfigurationControl.EndTimeFilter)
            {
                MessageBox.Show("Incorrect Date filter: start date > end date.");
                return;
            }
            this.ConnectionSettings = new AzureConnectionSettings(azureManualConfigurationControl.StorageName, azureManualConfigurationControl.StorageKey, true, azureManualConfigurationControl.QueryFilter, azureManualConfigurationControl.StartTimeFilter, azureManualConfigurationControl.EndTimeFilter, azureManualConfigurationControl.RoleFilter.Split(new char[]
            {
                ','
            }, StringSplitOptions.RemoveEmptyEntries), azureManualConfigurationControl.RoleInstanceFilter.Split(new char[]
            {
                ','
            }, StringSplitOptions.RemoveEmptyEntries));
            AzureSourceStateStorage.ParsingResultWithoutFiltering = null;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LD.SitecoreLogAnalyzer.Modules.Azure;
using System.Globalization;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation
{
    public partial class AzureManualConfigurationControl : UserControl
    {
        public event EventHandler OkClick;

        public string StorageName
        {
            get { return storageName.Text; }
            set { storageName.Text = value; }
        }

        public string StorageKey
        {
            get { return storageKey.Text; }
            set { storageKey.Text = value; }
        }

        public string RoleFilter
        {
            get { return filterByRole.Text; }
            set { filterByRole.Text = value; }
        }

        public string RoleInstanceFilter
        {
            get { return filterByInstance.Text; }
            set { filterByInstance.Text = value; }
        }

        public string QueryFilter
        {
            get { return filterQuery.Text; }
            set { filterQuery.Text = value; }
        }

        public DateTime StartTimeFilter
        {
            get { return startTime.Value; }
            set { startTime.Value = value; }
        }

        public DateTime EndTimeFilter
        {
            get { return endTime.Value; }
            set { endTime.Value = value; }
        }

        public AzureManualConfigurationControl()
        {
            InitializeComponent();
            okButton.Click += (sender, args) => OnOkClick(args);
            cancelButton.Click += (sender, args) => ParentForm.Close();
            LoadDefaultValues();
        }

        protected virtual void OnOkClick(EventArgs e)
        {
            SaveEnteredValues();
            EventHandler okClick = OkClick;
            if (okClick != null)
            {
                okClick(this, e);
            }
        }

        private void SaveEnteredValues()
        {
            AzureConfiguration.StorageName = this.StorageName;
            AzureConfiguration.StorageKey = this.StorageKey;
            AzureConfiguration.QueryFilter = this.QueryFilter;
            AzureConfiguration.RoleFilter = this.RoleFilter;
            AzureConfiguration.RoleInstanceFilter = this.RoleInstanceFilter;
            AzureConfiguration.StartTimeFilter = this.StartTimeFilter.ToString("HH:mm:ss dd.MM.yyyy");
            AzureConfiguration.EndTimeFilter = this.EndTimeFilter.ToString("HH:mm:ss dd.MM.yyyy");
        }

        private void LoadDefaultValues()
        {
            StorageName = AzureConfiguration.StorageName;
            StorageKey = AzureConfiguration.StorageKey;
            QueryFilter = AzureConfiguration.QueryFilter;
            RoleFilter = AzureConfiguration.RoleFilter;
            RoleInstanceFilter = AzureConfiguration.RoleInstanceFilter;
            if (!string.IsNullOrEmpty(AzureConfiguration.StartTimeFilter))
            {
                DateTime startTimeFilter;
                if (DateTime.TryParseExact(AzureConfiguration.StartTimeFilter, "HH:mm:ss dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTimeFilter))
                {
                    StartTimeFilter = startTimeFilter;
                }
                else
                {
                    MessageBox.Show(this, string.Format("Sitecore.LogAnalyzer.Modules.Azure.StartTimeFilter setting was not recognized as a valid datetime filter.\nFilter should be represented using the format {0}.", "HH:mm:ss dd.MM.yyyy"));
                    StartTimeFilter = DateTime.UtcNow.Date;
                }
            }
            else
            {
                StartTimeFilter = DateTime.UtcNow.Date;
            }
            if (string.IsNullOrEmpty(AzureConfiguration.EndTimeFilter))
            {
                EndTimeFilter = DateTime.UtcNow.Date.AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
                return;
            }
            DateTime endTimeFilter;
            if (DateTime.TryParseExact(AzureConfiguration.EndTimeFilter, "HH:mm:ss dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTimeFilter))
            {
                EndTimeFilter = endTimeFilter;
                return;
            }
            MessageBox.Show(this, string.Format("Sitecore.LogAnalyzer.Modules.Azure.EndTimeFilter setting was not recognized as a valid datetime filter.\nFilter should be represented using the format {0}.", "HH:mm:ss dd.MM.yyyy"));
            EndTimeFilter = DateTime.UtcNow.Date.AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0);
        }
    }
}

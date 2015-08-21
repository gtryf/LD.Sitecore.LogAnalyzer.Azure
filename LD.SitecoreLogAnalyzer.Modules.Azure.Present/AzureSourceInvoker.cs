using LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation.Properties;
using Sitecore.LogAnalyzer;
using Sitecore.LogAnalyzer.Presentation.Invokers;
using Sitecore.LogAnalyzer.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation
{
    public class AzureSourceInvoker : IVisibleSourceInvoker, ISourceInvoker
    {
        public const string DefaultName = "Azure Storage Table (LD)";

        public event EventHandler Load;

        public event EventHandler<EventArgs<IConnectionSettings>> Done;

        public event EventHandler Cancel;

        public event EventHandler<EventArgs<Tuple<DateTime, DateTime>>> DateFilterChanged;

        public string Name { get; }

        public Image Image { get; }

        public AzureSourceInvoker()
        {
            this.Name = DefaultName;
            this.Image = Resources.Azure;
        }

        public void Invoke()
        {
            this.OnLoad();
            using (AzureConfigurationForm form = new AzureConfigurationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.OnDateFilterChanged(form);
                    this.OnDone(form);
                }
                else
                {
                    this.OnCancel();
                }
            }
        }

        protected virtual void OnDateFilterChanged(AzureConfigurationForm owner)
        {
            EventHandler<EventArgs<Tuple<DateTime, DateTime>>> dateFilterChanged = this.DateFilterChanged;
            if (dateFilterChanged != null)
            {
                dateFilterChanged(this, new EventArgs<Tuple<DateTime, DateTime>>(new Tuple<DateTime, DateTime>(owner.ConnectionSettings.StartTimeFilter, owner.ConnectionSettings.EndTimeFilter)));
            }
        }

        protected virtual void OnDone(AzureConfigurationForm owner)
        {
            EventHandler<EventArgs<IConnectionSettings>> done = this.Done;
            if (done != null)
            {
                done(this, new EventArgs<IConnectionSettings>(owner.ConnectionSettings));
            }
        }

        protected virtual void OnLoad()
        {
            EventHandler load = this.Load;
            if (load != null)
            {
                load(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCancel()
        {
            EventHandler cancel = this.Cancel;
            if (cancel != null)
            {
                cancel(this, EventArgs.Empty);
            }
        }
    }
}

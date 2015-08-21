namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation
{
    partial class AzureConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.azureManualConfigurationControl1 = new LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation.AzureManualConfigurationControl();
            this.SuspendLayout();
            // 
            // azureManualConfigurationControl1
            // 
            this.azureManualConfigurationControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.azureManualConfigurationControl1.Location = new System.Drawing.Point(13, 13);
            this.azureManualConfigurationControl1.MinimumSize = new System.Drawing.Size(0, 266);
            this.azureManualConfigurationControl1.Name = "azureManualConfigurationControl1";
            this.azureManualConfigurationControl1.Size = new System.Drawing.Size(518, 276);
            this.azureManualConfigurationControl1.TabIndex = 0;
            // 
            // AzureConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 301);
            this.Controls.Add(this.azureManualConfigurationControl1);
            this.Name = "AzureConfigurationForm";
            this.Text = "AzureConfigurationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private AzureManualConfigurationControl azureManualConfigurationControl1;
    }
}
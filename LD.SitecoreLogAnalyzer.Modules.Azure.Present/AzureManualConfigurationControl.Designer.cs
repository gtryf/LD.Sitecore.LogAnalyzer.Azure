namespace LD.Sitecore.LogAnalyzer.Modules.Azure.Presentation
{
    partial class AzureManualConfigurationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.storageNameLabel = new System.Windows.Forms.Label();
            this.storageName = new System.Windows.Forms.TextBox();
            this.storageKeyLabel = new System.Windows.Forms.Label();
            this.storageKey = new System.Windows.Forms.TextBox();
            this.filterByRole = new System.Windows.Forms.TextBox();
            this.filterByRoleLabel = new System.Windows.Forms.Label();
            this.filterByInstance = new System.Windows.Forms.TextBox();
            this.filterByInstanceLabel = new System.Windows.Forms.Label();
            this.filterQuery = new System.Windows.Forms.TextBox();
            this.filterQueryLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // storageNameLabel
            // 
            this.storageNameLabel.AutoSize = true;
            this.storageNameLabel.Location = new System.Drawing.Point(4, 4);
            this.storageNameLabel.Name = "storageNameLabel";
            this.storageNameLabel.Size = new System.Drawing.Size(76, 13);
            this.storageNameLabel.TabIndex = 0;
            this.storageNameLabel.Text = "Storage name:";
            // 
            // storageName
            // 
            this.storageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storageName.Location = new System.Drawing.Point(163, 4);
            this.storageName.Name = "storageName";
            this.storageName.Size = new System.Drawing.Size(454, 20);
            this.storageName.TabIndex = 1;
            // 
            // storageKeyLabel
            // 
            this.storageKeyLabel.AutoSize = true;
            this.storageKeyLabel.Location = new System.Drawing.Point(4, 34);
            this.storageKeyLabel.Name = "storageKeyLabel";
            this.storageKeyLabel.Size = new System.Drawing.Size(67, 13);
            this.storageKeyLabel.TabIndex = 2;
            this.storageKeyLabel.Text = "Storage key:";
            // 
            // storageKey
            // 
            this.storageKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storageKey.Location = new System.Drawing.Point(163, 31);
            this.storageKey.Name = "storageKey";
            this.storageKey.Size = new System.Drawing.Size(454, 20);
            this.storageKey.TabIndex = 3;
            // 
            // filterByRole
            // 
            this.filterByRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterByRole.Location = new System.Drawing.Point(163, 57);
            this.filterByRole.Name = "filterByRole";
            this.filterByRole.Size = new System.Drawing.Size(454, 20);
            this.filterByRole.TabIndex = 5;
            // 
            // filterByRoleLabel
            // 
            this.filterByRoleLabel.AutoSize = true;
            this.filterByRoleLabel.Location = new System.Drawing.Point(4, 60);
            this.filterByRoleLabel.Name = "filterByRoleLabel";
            this.filterByRoleLabel.Size = new System.Drawing.Size(100, 13);
            this.filterByRoleLabel.TabIndex = 4;
            this.filterByRoleLabel.Text = "Filter by Role name:";
            // 
            // filterByInstance
            // 
            this.filterByInstance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterByInstance.Location = new System.Drawing.Point(163, 83);
            this.filterByInstance.Name = "filterByInstance";
            this.filterByInstance.Size = new System.Drawing.Size(454, 20);
            this.filterByInstance.TabIndex = 7;
            // 
            // filterByInstanceLabel
            // 
            this.filterByInstanceLabel.AutoSize = true;
            this.filterByInstanceLabel.Location = new System.Drawing.Point(4, 86);
            this.filterByInstanceLabel.Name = "filterByInstanceLabel";
            this.filterByInstanceLabel.Size = new System.Drawing.Size(144, 13);
            this.filterByInstanceLabel.TabIndex = 6;
            this.filterByInstanceLabel.Text = "Filter by Role Instance name:";
            // 
            // filterQuery
            // 
            this.filterQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterQuery.Location = new System.Drawing.Point(163, 109);
            this.filterQuery.Name = "filterQuery";
            this.filterQuery.Size = new System.Drawing.Size(454, 20);
            this.filterQuery.TabIndex = 9;
            // 
            // filterQueryLabel
            // 
            this.filterQueryLabel.AutoSize = true;
            this.filterQueryLabel.Location = new System.Drawing.Point(4, 112);
            this.filterQueryLabel.Name = "filterQueryLabel";
            this.filterQueryLabel.Size = new System.Drawing.Size(61, 13);
            this.filterQueryLabel.TabIndex = 8;
            this.filterQueryLabel.Text = "Filter query:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date Filter (UTC):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start time";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "End time";
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "HH:mm:ss dd.MM.yyyy";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(4, 195);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(155, 20);
            this.startTime.TabIndex = 13;
            // 
            // endTime
            // 
            this.endTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endTime.CustomFormat = "HH:mm:ss dd.MM.yyyy";
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTime.Location = new System.Drawing.Point(462, 195);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(155, 20);
            this.endTime.TabIndex = 14;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(357, 240);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(127, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(490, 240);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AzureManualConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterQuery);
            this.Controls.Add(this.filterQueryLabel);
            this.Controls.Add(this.filterByInstance);
            this.Controls.Add(this.filterByInstanceLabel);
            this.Controls.Add(this.filterByRole);
            this.Controls.Add(this.filterByRoleLabel);
            this.Controls.Add(this.storageKey);
            this.Controls.Add(this.storageKeyLabel);
            this.Controls.Add(this.storageName);
            this.Controls.Add(this.storageNameLabel);
            this.MinimumSize = new System.Drawing.Size(0, 266);
            this.Name = "AzureManualConfigurationControl";
            this.Size = new System.Drawing.Size(620, 266);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label storageNameLabel;
        private System.Windows.Forms.TextBox storageName;
        private System.Windows.Forms.Label storageKeyLabel;
        private System.Windows.Forms.TextBox storageKey;
        private System.Windows.Forms.TextBox filterByRole;
        private System.Windows.Forms.Label filterByRoleLabel;
        private System.Windows.Forms.TextBox filterByInstance;
        private System.Windows.Forms.Label filterByInstanceLabel;
        private System.Windows.Forms.TextBox filterQuery;
        private System.Windows.Forms.Label filterQueryLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

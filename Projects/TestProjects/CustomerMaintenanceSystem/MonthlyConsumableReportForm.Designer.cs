namespace CustomerMaintenanceSystem
{
    partial class MonthlyConsumableReportForm
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CustomerMaintenanceSystemDatabaseDataSet = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSet();
            this.JobDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JobDetailsTableAdapter = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.JobDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerMaintenanceSystemDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "JobsDetailsDataSet";
            reportDataSource1.Value = this.JobDetailsBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "CustomerMaintenanceSystem.MonthlyConsumableReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 12);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(483, 318);
            this.reportViewer.TabIndex = 0;
            // 
            // CustomerMaintenanceSystemDatabaseDataSet
            // 
            this.CustomerMaintenanceSystemDatabaseDataSet.DataSetName = "CustomerMaintenanceSystemDatabaseDataSet";
            this.CustomerMaintenanceSystemDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // JobDetailsBindingSource
            // 
            this.JobDetailsBindingSource.DataMember = "JobDetails";
            this.JobDetailsBindingSource.DataSource = this.CustomerMaintenanceSystemDatabaseDataSet;
            // 
            // JobDetailsTableAdapter
            // 
            this.JobDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // MonthlyConsumableReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 342);
            this.Controls.Add(this.reportViewer);
            this.Name = "MonthlyConsumableReportForm";
            this.Text = "MonthlyConsumableReportForm";
            this.Load += new System.EventHandler(this.MonthlyConsumableReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerMaintenanceSystemDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource JobDetailsBindingSource;
        private CustomerMaintenanceSystemDatabaseDataSet CustomerMaintenanceSystemDatabaseDataSet;
        private CustomerMaintenanceSystemDatabaseDataSetTableAdapters.JobDetailsTableAdapter JobDetailsTableAdapter;
    }
}
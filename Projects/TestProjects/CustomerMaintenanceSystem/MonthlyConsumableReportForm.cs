using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenanceSystem
{
    public partial class MonthlyConsumableReportForm : Form
    {
        public MonthlyConsumableReportForm()
        {
            InitializeComponent();
        }

        private void MonthlyConsumableReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CustomerMaintenanceSystemDatabaseDataSet.JobDetails' table. You can move, or remove it, as needed.
            this.JobDetailsTableAdapter.Fill(this.CustomerMaintenanceSystemDatabaseDataSet.JobDetails);

            this.reportViewer.RefreshReport();
        }
    }
}

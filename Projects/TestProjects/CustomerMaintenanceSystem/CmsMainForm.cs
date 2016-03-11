namespace CustomerMaintenanceSystem
{
    using System;
    using System.Windows.Forms;

    public partial class CmsMainForm : Form
    {
        public CmsMainForm()
        {
            InitializeComponent();
        }

        private void workerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workerForm = new WorkersForm();
            workerForm.Show(this);
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            customerForm.Show(this);
        }

        private void jobDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jobsDetailsForm = new JobsDetailsForm();
            jobsDetailsForm.Show(this);
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm();
            reportsForm.Show(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

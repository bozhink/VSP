namespace CustomerMaintenanceSystem
{
    using System;
    using System.Windows.Forms;

    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var reportForm = new MonthlyConsumableReportForm();
            reportForm.Show(this);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class JobsDetailsForm : Form
    {
        public JobsDetailsForm()
        {
            InitializeComponent();
        }

        private void jobDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.jobDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.customerMaintenanceSystemDatabaseDataSet);

        }

        private void JobsDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerMaintenanceSystemDatabaseDataSet.JobDetails' table. You can move, or remove it, as needed.
            this.jobDetailsTableAdapter.Fill(this.customerMaintenanceSystemDatabaseDataSet.JobDetails);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.jobDateDateTimePicker.Value = DateTime.Now;
        }
    }
}

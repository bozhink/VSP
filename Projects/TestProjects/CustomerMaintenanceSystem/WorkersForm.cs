namespace CustomerMaintenanceSystem
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class WorkersForm : Form
    {
        delegate void SetTextCallback(string text);

        public WorkersForm()
        {
            InitializeComponent();
        }

        private void WorkersForm_Load(object sender, EventArgs e)
        {
            this.workersTableAdapter.Fill(this.customerMaintenanceSystemDatabaseDataSet.Workers);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Ivalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void SaveData()
        {
            try
            {
                workersTableAdapter.Update(customerMaintenanceSystemDatabaseDataSet);

                this.BlinkStatusStripText("Successfuly saved.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error on update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshData()
        {
            try
            {
                customerMaintenanceSystemDatabaseDataSet.Clear();
                workersTableAdapter.Fill(customerMaintenanceSystemDatabaseDataSet.Workers);

                this.BlinkStatusStripText("Successfuly refreshed.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error on refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BlinkStatusStripText(string text)
        {
            Task.Run(() =>
            {
                this.SetStatusStripText(text);
                Thread.Sleep(3000);
                this.SetStatusStripText(string.Empty);
            });
        }

        private void SetStatusStripText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.statusStrip.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(SetStatusStripText);
                this.Invoke(callback, new object[] { text });
            }
            else
            {
                this.toolStripStatusLabel.Text = text;
            }
        }
    }
}

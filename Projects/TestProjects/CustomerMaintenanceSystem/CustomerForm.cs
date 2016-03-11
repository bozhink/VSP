using System;
namespace CustomerMaintenanceSystem
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class CustomerForm : Form
    {
        delegate void SetTextCallback(string text);

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            this.RemoveAllErrorMessages();
        }

        private void RemoveAllErrorMessages()
        {
            this.errorProvider.SetError(this.carNoTextBox, string.Empty);
            this.errorProvider.SetError(this.nameTextBox, string.Empty);
            this.errorProvider.SetError(this.addressTextBox, string.Empty);
            this.errorProvider.SetError(this.makeTextBox, string.Empty);
        }

        private bool ValidateContent(TextBox textBox)
        {
            bool result;
            result = textBox.Text.Trim().Length > 0;
            return result;
        }

        private bool UpdateErrorState(TextBox textBox, string errorMessage)
        {
            bool validationFlag = true;
            if (!this.ValidateContent(textBox))
            {
                this.errorProvider.SetError(textBox, errorMessage);
                validationFlag = false;
            }

            return validationFlag;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.RemoveAllErrorMessages();

            bool validationFlag = true;

            validationFlag = this.UpdateErrorState(this.carNoTextBox, "Please specify a valid car number.");

            validationFlag = this.UpdateErrorState(this.nameTextBox, "Please specify a valid name.");

            validationFlag = this.UpdateErrorState(this.addressTextBox, "Please specify a valid address.");

            validationFlag = this.UpdateErrorState(this.makeTextBox, "Please specify a valid make.");

            if (validationFlag)
            {
                this.SaveData();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            this.previousButton.BindingContext[customerMaintenanceSystemDatabaseDataSet.Customers].Position -= 1;
            this.CurrentPosition();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            this.nextButton.BindingContext[customerMaintenanceSystemDatabaseDataSet.Customers].Position += 1;
            this.CurrentPosition();
        }

        private void CurrentPosition()
        {
            int currentPosition, count;
            count = this.BindingContext[customerMaintenanceSystemDatabaseDataSet.Customers].Count;
            if (count == 0)
            {
                this.displayTextBox.Text = "(There are no records in the Customer table.)";
            }
            else
            {
                currentPosition = this.BindingContext[customerMaintenanceSystemDatabaseDataSet.Customers].Position + 1;
                this.displayTextBox.Text = currentPosition.ToString() + " of " + count.ToString();
            }
        }

        private void SaveData()
        {
            try
            {
                customersTableAdapter.Update(customerMaintenanceSystemDatabaseDataSet.Customers);
                this.CurrentPosition();

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
                customersTableAdapter.Fill(customerMaintenanceSystemDatabaseDataSet.Customers);
                this.CurrentPosition();

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
                SetStatusStripText(text);
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

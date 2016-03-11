namespace CustomerMaintenanceSystem
{
    partial class CustomerForm
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
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerMaintenanceSystemDatabaseDataSet = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSet();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.customersTableAdapter = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.CustomersTableAdapter();
            this.carNoLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.makeLabel = new System.Windows.Forms.Label();
            this.carNoTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.makeTextBox = new System.Windows.Forms.TextBox();
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.tableAdapterManager = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerMaintenanceSystemDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.customerMaintenanceSystemDatabaseDataSet;
            // 
            // customerMaintenanceSystemDatabaseDataSet
            // 
            this.customerMaintenanceSystemDatabaseDataSet.DataSetName = "CustomerMaintenanceSystemDatabaseDataSet";
            this.customerMaintenanceSystemDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 427);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(783, 22);
            this.statusStrip.TabIndex = 12;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // carNoLabel
            // 
            this.carNoLabel.AutoSize = true;
            this.carNoLabel.Location = new System.Drawing.Point(13, 13);
            this.carNoLabel.Name = "carNoLabel";
            this.carNoLabel.Size = new System.Drawing.Size(43, 13);
            this.carNoLabel.TabIndex = 0;
            this.carNoLabel.Text = "Car No.";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 97);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(334, 13);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.TabIndex = 0;
            this.addressLabel.Text = "Address";
            // 
            // makeLabel
            // 
            this.makeLabel.AutoSize = true;
            this.makeLabel.Location = new System.Drawing.Point(337, 97);
            this.makeLabel.Name = "makeLabel";
            this.makeLabel.Size = new System.Drawing.Size(34, 13);
            this.makeLabel.TabIndex = 0;
            this.makeLabel.Text = "Make";
            // 
            // carNoTextBox
            // 
            this.carNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "CarNo", true));
            this.errorProvider.SetError(this.carNoTextBox, "Car No schould not be empty");
            this.carNoTextBox.Location = new System.Drawing.Point(63, 13);
            this.carNoTextBox.Name = "carNoTextBox";
            this.carNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.carNoTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Name", true));
            this.errorProvider.SetError(this.nameTextBox, "Name schould not be empty");
            this.nameTextBox.Location = new System.Drawing.Point(63, 97);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Address", true));
            this.errorProvider.SetError(this.addressTextBox, "Address schould not be empty");
            this.addressTextBox.Location = new System.Drawing.Point(386, 13);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressTextBox.TabIndex = 3;
            // 
            // makeTextBox
            // 
            this.makeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customersBindingSource, "Make", true));
            this.errorProvider.SetError(this.makeTextBox, "Make schould not be empty");
            this.makeTextBox.Location = new System.Drawing.Point(386, 97);
            this.makeTextBox.Name = "makeTextBox";
            this.makeTextBox.Size = new System.Drawing.Size(100, 20);
            this.makeTextBox.TabIndex = 4;
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(97, 247);
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.Size = new System.Drawing.Size(255, 20);
            this.displayTextBox.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(16, 202);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editButton.Location = new System.Drawing.Point(97, 202);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(178, 202);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(260, 202);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "&Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(16, 244);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 10;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(358, 244);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 11;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CustomersTableAdapter = this.customersTableAdapter;
            this.tableAdapterManager.JobDetailsTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkersTableAdapter = null;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 449);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.makeTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.carNoTextBox);
            this.Controls.Add(this.makeLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.carNoLabel);
            this.Name = "CustomerForm";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerMaintenanceSystemDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private CustomerMaintenanceSystemDatabaseDataSet customerMaintenanceSystemDatabaseDataSet;
        private CustomerMaintenanceSystemDatabaseDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.TextBox makeTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox carNoTextBox;
        private System.Windows.Forms.Label makeLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label carNoLabel;
        private CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}
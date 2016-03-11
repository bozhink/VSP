namespace CustomerMaintenanceSystem
{
    partial class JobsDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobsDetailsForm));
            System.Windows.Forms.Label carNoLabel;
            System.Windows.Forms.Label jobDateLabel;
            System.Windows.Forms.Label workerIDLabel;
            System.Windows.Forms.Label kMsLabel;
            System.Windows.Forms.Label tuningLabel;
            System.Windows.Forms.Label alignmentLabel;
            System.Windows.Forms.Label balancingLabel;
            System.Windows.Forms.Label tiresLabel;
            System.Windows.Forms.Label weightsLabel;
            System.Windows.Forms.Label oilChangedLabel;
            System.Windows.Forms.Label oilQtyLabel;
            System.Windows.Forms.Label oilFilterLabel;
            System.Windows.Forms.Label gearOilLabel;
            System.Windows.Forms.Label gearOilQtyLabel;
            System.Windows.Forms.Label pointLabel;
            System.Windows.Forms.Label condenserLabel;
            System.Windows.Forms.Label plugLabel;
            System.Windows.Forms.Label plugQtyLabel;
            System.Windows.Forms.Label fuelFilterLabel;
            System.Windows.Forms.Label airFilterLabel;
            System.Windows.Forms.Label remarksLabel;
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.customerMaintenanceSystemDatabaseDataSet = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSet();
            this.jobDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jobDetailsTableAdapter = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.JobDetailsTableAdapter();
            this.tableAdapterManager = new CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager();
            this.jobDetailsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.jobDetailsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.carNoTextBox = new System.Windows.Forms.TextBox();
            this.jobDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.workerIDTextBox = new System.Windows.Forms.TextBox();
            this.kMsTextBox = new System.Windows.Forms.TextBox();
            this.tuningTextBox = new System.Windows.Forms.TextBox();
            this.alignmentTextBox = new System.Windows.Forms.TextBox();
            this.balancingTextBox = new System.Windows.Forms.TextBox();
            this.tiresTextBox = new System.Windows.Forms.TextBox();
            this.weightsTextBox = new System.Windows.Forms.TextBox();
            this.oilChangedTextBox = new System.Windows.Forms.TextBox();
            this.oilQtyTextBox = new System.Windows.Forms.TextBox();
            this.oilFilterTextBox = new System.Windows.Forms.TextBox();
            this.gearOilTextBox = new System.Windows.Forms.TextBox();
            this.gearOilQtyTextBox = new System.Windows.Forms.TextBox();
            this.pointTextBox = new System.Windows.Forms.TextBox();
            this.condenserTextBox = new System.Windows.Forms.TextBox();
            this.plugTextBox = new System.Windows.Forms.TextBox();
            this.plugQtyTextBox = new System.Windows.Forms.TextBox();
            this.fuelFilterTextBox = new System.Windows.Forms.TextBox();
            this.airFilterTextBox = new System.Windows.Forms.TextBox();
            this.remarksTextBox = new System.Windows.Forms.TextBox();
            carNoLabel = new System.Windows.Forms.Label();
            jobDateLabel = new System.Windows.Forms.Label();
            workerIDLabel = new System.Windows.Forms.Label();
            kMsLabel = new System.Windows.Forms.Label();
            tuningLabel = new System.Windows.Forms.Label();
            alignmentLabel = new System.Windows.Forms.Label();
            balancingLabel = new System.Windows.Forms.Label();
            tiresLabel = new System.Windows.Forms.Label();
            weightsLabel = new System.Windows.Forms.Label();
            oilChangedLabel = new System.Windows.Forms.Label();
            oilQtyLabel = new System.Windows.Forms.Label();
            oilFilterLabel = new System.Windows.Forms.Label();
            gearOilLabel = new System.Windows.Forms.Label();
            gearOilQtyLabel = new System.Windows.Forms.Label();
            pointLabel = new System.Windows.Forms.Label();
            condenserLabel = new System.Windows.Forms.Label();
            plugLabel = new System.Windows.Forms.Label();
            plugQtyLabel = new System.Windows.Forms.Label();
            fuelFilterLabel = new System.Windows.Forms.Label();
            airFilterLabel = new System.Windows.Forms.Label();
            remarksLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerMaintenanceSystemDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingNavigator)).BeginInit();
            this.jobDetailsBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 354);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(498, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // customerMaintenanceSystemDatabaseDataSet
            // 
            this.customerMaintenanceSystemDatabaseDataSet.DataSetName = "CustomerMaintenanceSystemDatabaseDataSet";
            this.customerMaintenanceSystemDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // jobDetailsBindingSource
            // 
            this.jobDetailsBindingSource.DataMember = "JobDetails";
            this.jobDetailsBindingSource.DataSource = this.customerMaintenanceSystemDatabaseDataSet;
            // 
            // jobDetailsTableAdapter
            // 
            this.jobDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CustomersTableAdapter = null;
            this.tableAdapterManager.JobDetailsTableAdapter = this.jobDetailsTableAdapter;
            this.tableAdapterManager.UpdateOrder = CustomerMaintenanceSystem.CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WorkersTableAdapter = null;
            // 
            // jobDetailsBindingNavigator
            // 
            this.jobDetailsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.jobDetailsBindingNavigator.BindingSource = this.jobDetailsBindingSource;
            this.jobDetailsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.jobDetailsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.jobDetailsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.jobDetailsBindingNavigatorSaveItem});
            this.jobDetailsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.jobDetailsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.jobDetailsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.jobDetailsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.jobDetailsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.jobDetailsBindingNavigator.Name = "jobDetailsBindingNavigator";
            this.jobDetailsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.jobDetailsBindingNavigator.Size = new System.Drawing.Size(498, 25);
            this.jobDetailsBindingNavigator.TabIndex = 1;
            this.jobDetailsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // jobDetailsBindingNavigatorSaveItem
            // 
            this.jobDetailsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.jobDetailsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("jobDetailsBindingNavigatorSaveItem.Image")));
            this.jobDetailsBindingNavigatorSaveItem.Name = "jobDetailsBindingNavigatorSaveItem";
            this.jobDetailsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.jobDetailsBindingNavigatorSaveItem.Text = "Save Data";
            this.jobDetailsBindingNavigatorSaveItem.Click += new System.EventHandler(this.jobDetailsBindingNavigatorSaveItem_Click);
            // 
            // carNoLabel
            // 
            carNoLabel.AutoSize = true;
            carNoLabel.Location = new System.Drawing.Point(12, 35);
            carNoLabel.Name = "carNoLabel";
            carNoLabel.Size = new System.Drawing.Size(43, 13);
            carNoLabel.TabIndex = 2;
            carNoLabel.Text = "Car No:";
            // 
            // carNoTextBox
            // 
            this.carNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "CarNo", true));
            this.carNoTextBox.Location = new System.Drawing.Point(82, 32);
            this.carNoTextBox.Name = "carNoTextBox";
            this.carNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.carNoTextBox.TabIndex = 3;
            // 
            // jobDateLabel
            // 
            jobDateLabel.AutoSize = true;
            jobDateLabel.Location = new System.Drawing.Point(12, 64);
            jobDateLabel.Name = "jobDateLabel";
            jobDateLabel.Size = new System.Drawing.Size(53, 13);
            jobDateLabel.TabIndex = 4;
            jobDateLabel.Text = "Job Date:";
            // 
            // jobDateDateTimePicker
            // 
            this.jobDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.jobDetailsBindingSource, "JobDate", true));
            this.jobDateDateTimePicker.Location = new System.Drawing.Point(82, 58);
            this.jobDateDateTimePicker.Name = "jobDateDateTimePicker";
            this.jobDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.jobDateDateTimePicker.TabIndex = 5;
            // 
            // workerIDLabel
            // 
            workerIDLabel.AutoSize = true;
            workerIDLabel.Location = new System.Drawing.Point(12, 87);
            workerIDLabel.Name = "workerIDLabel";
            workerIDLabel.Size = new System.Drawing.Size(59, 13);
            workerIDLabel.TabIndex = 6;
            workerIDLabel.Text = "Worker ID:";
            // 
            // workerIDTextBox
            // 
            this.workerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "WorkerID", true));
            this.workerIDTextBox.Location = new System.Drawing.Point(82, 84);
            this.workerIDTextBox.Name = "workerIDTextBox";
            this.workerIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.workerIDTextBox.TabIndex = 7;
            // 
            // kMsLabel
            // 
            kMsLabel.AutoSize = true;
            kMsLabel.Location = new System.Drawing.Point(12, 113);
            kMsLabel.Name = "kMsLabel";
            kMsLabel.Size = new System.Drawing.Size(31, 13);
            kMsLabel.TabIndex = 8;
            kMsLabel.Text = "KMs:";
            // 
            // kMsTextBox
            // 
            this.kMsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "KMs", true));
            this.kMsTextBox.Location = new System.Drawing.Point(82, 110);
            this.kMsTextBox.Name = "kMsTextBox";
            this.kMsTextBox.Size = new System.Drawing.Size(100, 20);
            this.kMsTextBox.TabIndex = 9;
            // 
            // tuningLabel
            // 
            tuningLabel.AutoSize = true;
            tuningLabel.Location = new System.Drawing.Point(12, 139);
            tuningLabel.Name = "tuningLabel";
            tuningLabel.Size = new System.Drawing.Size(43, 13);
            tuningLabel.TabIndex = 10;
            tuningLabel.Text = "Tuning:";
            // 
            // tuningTextBox
            // 
            this.tuningTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Tuning", true));
            this.tuningTextBox.Location = new System.Drawing.Point(82, 136);
            this.tuningTextBox.Name = "tuningTextBox";
            this.tuningTextBox.Size = new System.Drawing.Size(100, 20);
            this.tuningTextBox.TabIndex = 11;
            // 
            // alignmentLabel
            // 
            alignmentLabel.AutoSize = true;
            alignmentLabel.Location = new System.Drawing.Point(12, 165);
            alignmentLabel.Name = "alignmentLabel";
            alignmentLabel.Size = new System.Drawing.Size(56, 13);
            alignmentLabel.TabIndex = 12;
            alignmentLabel.Text = "Alignment:";
            // 
            // alignmentTextBox
            // 
            this.alignmentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Alignment", true));
            this.alignmentTextBox.Location = new System.Drawing.Point(82, 162);
            this.alignmentTextBox.Name = "alignmentTextBox";
            this.alignmentTextBox.Size = new System.Drawing.Size(100, 20);
            this.alignmentTextBox.TabIndex = 13;
            // 
            // balancingLabel
            // 
            balancingLabel.AutoSize = true;
            balancingLabel.Location = new System.Drawing.Point(12, 189);
            balancingLabel.Name = "balancingLabel";
            balancingLabel.Size = new System.Drawing.Size(57, 13);
            balancingLabel.TabIndex = 14;
            balancingLabel.Text = "Balancing:";
            // 
            // balancingTextBox
            // 
            this.balancingTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Balancing", true));
            this.balancingTextBox.Location = new System.Drawing.Point(82, 188);
            this.balancingTextBox.Name = "balancingTextBox";
            this.balancingTextBox.Size = new System.Drawing.Size(100, 20);
            this.balancingTextBox.TabIndex = 15;
            // 
            // tiresLabel
            // 
            tiresLabel.AutoSize = true;
            tiresLabel.Location = new System.Drawing.Point(12, 217);
            tiresLabel.Name = "tiresLabel";
            tiresLabel.Size = new System.Drawing.Size(33, 13);
            tiresLabel.TabIndex = 16;
            tiresLabel.Text = "Tires:";
            // 
            // tiresTextBox
            // 
            this.tiresTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Tires", true));
            this.tiresTextBox.Location = new System.Drawing.Point(82, 214);
            this.tiresTextBox.Name = "tiresTextBox";
            this.tiresTextBox.Size = new System.Drawing.Size(100, 20);
            this.tiresTextBox.TabIndex = 17;
            // 
            // weightsLabel
            // 
            weightsLabel.AutoSize = true;
            weightsLabel.Location = new System.Drawing.Point(12, 243);
            weightsLabel.Name = "weightsLabel";
            weightsLabel.Size = new System.Drawing.Size(49, 13);
            weightsLabel.TabIndex = 18;
            weightsLabel.Text = "Weights:";
            // 
            // weightsTextBox
            // 
            this.weightsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Weights", true));
            this.weightsTextBox.Location = new System.Drawing.Point(82, 240);
            this.weightsTextBox.Name = "weightsTextBox";
            this.weightsTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightsTextBox.TabIndex = 19;
            // 
            // oilChangedLabel
            // 
            oilChangedLabel.AutoSize = true;
            oilChangedLabel.Location = new System.Drawing.Point(12, 269);
            oilChangedLabel.Name = "oilChangedLabel";
            oilChangedLabel.Size = new System.Drawing.Size(68, 13);
            oilChangedLabel.TabIndex = 20;
            oilChangedLabel.Text = "Oil Changed:";
            // 
            // oilChangedTextBox
            // 
            this.oilChangedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "OilChanged", true));
            this.oilChangedTextBox.Location = new System.Drawing.Point(82, 266);
            this.oilChangedTextBox.Name = "oilChangedTextBox";
            this.oilChangedTextBox.Size = new System.Drawing.Size(100, 20);
            this.oilChangedTextBox.TabIndex = 21;
            // 
            // oilQtyLabel
            // 
            oilQtyLabel.AutoSize = true;
            oilQtyLabel.Location = new System.Drawing.Point(12, 295);
            oilQtyLabel.Name = "oilQtyLabel";
            oilQtyLabel.Size = new System.Drawing.Size(41, 13);
            oilQtyLabel.TabIndex = 22;
            oilQtyLabel.Text = "Oil Qty:";
            // 
            // oilQtyTextBox
            // 
            this.oilQtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "OilQty", true));
            this.oilQtyTextBox.Location = new System.Drawing.Point(82, 292);
            this.oilQtyTextBox.Name = "oilQtyTextBox";
            this.oilQtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.oilQtyTextBox.TabIndex = 23;
            // 
            // oilFilterLabel
            // 
            oilFilterLabel.AutoSize = true;
            oilFilterLabel.Location = new System.Drawing.Point(12, 321);
            oilFilterLabel.Name = "oilFilterLabel";
            oilFilterLabel.Size = new System.Drawing.Size(47, 13);
            oilFilterLabel.TabIndex = 24;
            oilFilterLabel.Text = "Oil Filter:";
            // 
            // oilFilterTextBox
            // 
            this.oilFilterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "OilFilter", true));
            this.oilFilterTextBox.Location = new System.Drawing.Point(82, 318);
            this.oilFilterTextBox.Name = "oilFilterTextBox";
            this.oilFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.oilFilterTextBox.TabIndex = 25;
            // 
            // gearOilLabel
            // 
            gearOilLabel.AutoSize = true;
            gearOilLabel.Location = new System.Drawing.Point(298, 35);
            gearOilLabel.Name = "gearOilLabel";
            gearOilLabel.Size = new System.Drawing.Size(48, 13);
            gearOilLabel.TabIndex = 26;
            gearOilLabel.Text = "Gear Oil:";
            // 
            // gearOilTextBox
            // 
            this.gearOilTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "GearOil", true));
            this.gearOilTextBox.Location = new System.Drawing.Point(371, 32);
            this.gearOilTextBox.Name = "gearOilTextBox";
            this.gearOilTextBox.Size = new System.Drawing.Size(100, 20);
            this.gearOilTextBox.TabIndex = 27;
            // 
            // gearOilQtyLabel
            // 
            gearOilQtyLabel.AutoSize = true;
            gearOilQtyLabel.Location = new System.Drawing.Point(298, 61);
            gearOilQtyLabel.Name = "gearOilQtyLabel";
            gearOilQtyLabel.Size = new System.Drawing.Size(67, 13);
            gearOilQtyLabel.TabIndex = 28;
            gearOilQtyLabel.Text = "Gear Oil Qty:";
            // 
            // gearOilQtyTextBox
            // 
            this.gearOilQtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "GearOilQty", true));
            this.gearOilQtyTextBox.Location = new System.Drawing.Point(371, 58);
            this.gearOilQtyTextBox.Name = "gearOilQtyTextBox";
            this.gearOilQtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.gearOilQtyTextBox.TabIndex = 29;
            // 
            // pointLabel
            // 
            pointLabel.AutoSize = true;
            pointLabel.Location = new System.Drawing.Point(298, 87);
            pointLabel.Name = "pointLabel";
            pointLabel.Size = new System.Drawing.Size(34, 13);
            pointLabel.TabIndex = 30;
            pointLabel.Text = "Point:";
            // 
            // pointTextBox
            // 
            this.pointTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Point", true));
            this.pointTextBox.Location = new System.Drawing.Point(371, 84);
            this.pointTextBox.Name = "pointTextBox";
            this.pointTextBox.Size = new System.Drawing.Size(100, 20);
            this.pointTextBox.TabIndex = 31;
            // 
            // condenserLabel
            // 
            condenserLabel.AutoSize = true;
            condenserLabel.Location = new System.Drawing.Point(298, 113);
            condenserLabel.Name = "condenserLabel";
            condenserLabel.Size = new System.Drawing.Size(61, 13);
            condenserLabel.TabIndex = 32;
            condenserLabel.Text = "Condenser:";
            // 
            // condenserTextBox
            // 
            this.condenserTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Condenser", true));
            this.condenserTextBox.Location = new System.Drawing.Point(371, 110);
            this.condenserTextBox.Name = "condenserTextBox";
            this.condenserTextBox.Size = new System.Drawing.Size(100, 20);
            this.condenserTextBox.TabIndex = 33;
            // 
            // plugLabel
            // 
            plugLabel.AutoSize = true;
            plugLabel.Location = new System.Drawing.Point(298, 139);
            plugLabel.Name = "plugLabel";
            plugLabel.Size = new System.Drawing.Size(31, 13);
            plugLabel.TabIndex = 34;
            plugLabel.Text = "Plug:";
            // 
            // plugTextBox
            // 
            this.plugTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Plug", true));
            this.plugTextBox.Location = new System.Drawing.Point(371, 136);
            this.plugTextBox.Name = "plugTextBox";
            this.plugTextBox.Size = new System.Drawing.Size(100, 20);
            this.plugTextBox.TabIndex = 35;
            // 
            // plugQtyLabel
            // 
            plugQtyLabel.AutoSize = true;
            plugQtyLabel.Location = new System.Drawing.Point(298, 165);
            plugQtyLabel.Name = "plugQtyLabel";
            plugQtyLabel.Size = new System.Drawing.Size(50, 13);
            plugQtyLabel.TabIndex = 36;
            plugQtyLabel.Text = "Plug Qty:";
            // 
            // plugQtyTextBox
            // 
            this.plugQtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "PlugQty", true));
            this.plugQtyTextBox.Location = new System.Drawing.Point(371, 162);
            this.plugQtyTextBox.Name = "plugQtyTextBox";
            this.plugQtyTextBox.Size = new System.Drawing.Size(100, 20);
            this.plugQtyTextBox.TabIndex = 37;
            // 
            // fuelFilterLabel
            // 
            fuelFilterLabel.AutoSize = true;
            fuelFilterLabel.Location = new System.Drawing.Point(298, 191);
            fuelFilterLabel.Name = "fuelFilterLabel";
            fuelFilterLabel.Size = new System.Drawing.Size(55, 13);
            fuelFilterLabel.TabIndex = 38;
            fuelFilterLabel.Text = "Fuel Filter:";
            // 
            // fuelFilterTextBox
            // 
            this.fuelFilterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "FuelFilter", true));
            this.fuelFilterTextBox.Location = new System.Drawing.Point(371, 188);
            this.fuelFilterTextBox.Name = "fuelFilterTextBox";
            this.fuelFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.fuelFilterTextBox.TabIndex = 39;
            // 
            // airFilterLabel
            // 
            airFilterLabel.AutoSize = true;
            airFilterLabel.Location = new System.Drawing.Point(298, 217);
            airFilterLabel.Name = "airFilterLabel";
            airFilterLabel.Size = new System.Drawing.Size(47, 13);
            airFilterLabel.TabIndex = 40;
            airFilterLabel.Text = "Air Filter:";
            // 
            // airFilterTextBox
            // 
            this.airFilterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "AirFilter", true));
            this.airFilterTextBox.Location = new System.Drawing.Point(371, 214);
            this.airFilterTextBox.Name = "airFilterTextBox";
            this.airFilterTextBox.Size = new System.Drawing.Size(100, 20);
            this.airFilterTextBox.TabIndex = 41;
            // 
            // remarksLabel
            // 
            remarksLabel.AutoSize = true;
            remarksLabel.Location = new System.Drawing.Point(298, 243);
            remarksLabel.Name = "remarksLabel";
            remarksLabel.Size = new System.Drawing.Size(52, 13);
            remarksLabel.TabIndex = 42;
            remarksLabel.Text = "Remarks:";
            // 
            // remarksTextBox
            // 
            this.remarksTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobDetailsBindingSource, "Remarks", true));
            this.remarksTextBox.Location = new System.Drawing.Point(371, 240);
            this.remarksTextBox.Name = "remarksTextBox";
            this.remarksTextBox.Size = new System.Drawing.Size(100, 20);
            this.remarksTextBox.TabIndex = 43;
            // 
            // JobsDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 376);
            this.Controls.Add(remarksLabel);
            this.Controls.Add(this.remarksTextBox);
            this.Controls.Add(airFilterLabel);
            this.Controls.Add(this.airFilterTextBox);
            this.Controls.Add(fuelFilterLabel);
            this.Controls.Add(this.fuelFilterTextBox);
            this.Controls.Add(plugQtyLabel);
            this.Controls.Add(this.plugQtyTextBox);
            this.Controls.Add(plugLabel);
            this.Controls.Add(this.plugTextBox);
            this.Controls.Add(condenserLabel);
            this.Controls.Add(this.condenserTextBox);
            this.Controls.Add(pointLabel);
            this.Controls.Add(this.pointTextBox);
            this.Controls.Add(gearOilQtyLabel);
            this.Controls.Add(this.gearOilQtyTextBox);
            this.Controls.Add(gearOilLabel);
            this.Controls.Add(this.gearOilTextBox);
            this.Controls.Add(oilFilterLabel);
            this.Controls.Add(this.oilFilterTextBox);
            this.Controls.Add(oilQtyLabel);
            this.Controls.Add(this.oilQtyTextBox);
            this.Controls.Add(oilChangedLabel);
            this.Controls.Add(this.oilChangedTextBox);
            this.Controls.Add(weightsLabel);
            this.Controls.Add(this.weightsTextBox);
            this.Controls.Add(tiresLabel);
            this.Controls.Add(this.tiresTextBox);
            this.Controls.Add(balancingLabel);
            this.Controls.Add(this.balancingTextBox);
            this.Controls.Add(alignmentLabel);
            this.Controls.Add(this.alignmentTextBox);
            this.Controls.Add(tuningLabel);
            this.Controls.Add(this.tuningTextBox);
            this.Controls.Add(kMsLabel);
            this.Controls.Add(this.kMsTextBox);
            this.Controls.Add(workerIDLabel);
            this.Controls.Add(this.workerIDTextBox);
            this.Controls.Add(jobDateLabel);
            this.Controls.Add(this.jobDateDateTimePicker);
            this.Controls.Add(carNoLabel);
            this.Controls.Add(this.carNoTextBox);
            this.Controls.Add(this.jobDetailsBindingNavigator);
            this.Controls.Add(this.statusStrip);
            this.Name = "JobsDetailsForm";
            this.Text = "Jobs Details";
            this.Load += new System.EventHandler(this.JobsDetailsForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerMaintenanceSystemDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobDetailsBindingNavigator)).EndInit();
            this.jobDetailsBindingNavigator.ResumeLayout(false);
            this.jobDetailsBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private CustomerMaintenanceSystemDatabaseDataSet customerMaintenanceSystemDatabaseDataSet;
        private System.Windows.Forms.BindingSource jobDetailsBindingSource;
        private CustomerMaintenanceSystemDatabaseDataSetTableAdapters.JobDetailsTableAdapter jobDetailsTableAdapter;
        private CustomerMaintenanceSystemDatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator jobDetailsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton jobDetailsBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox carNoTextBox;
        private System.Windows.Forms.DateTimePicker jobDateDateTimePicker;
        private System.Windows.Forms.TextBox workerIDTextBox;
        private System.Windows.Forms.TextBox kMsTextBox;
        private System.Windows.Forms.TextBox tuningTextBox;
        private System.Windows.Forms.TextBox alignmentTextBox;
        private System.Windows.Forms.TextBox balancingTextBox;
        private System.Windows.Forms.TextBox tiresTextBox;
        private System.Windows.Forms.TextBox weightsTextBox;
        private System.Windows.Forms.TextBox oilChangedTextBox;
        private System.Windows.Forms.TextBox oilQtyTextBox;
        private System.Windows.Forms.TextBox oilFilterTextBox;
        private System.Windows.Forms.TextBox gearOilTextBox;
        private System.Windows.Forms.TextBox gearOilQtyTextBox;
        private System.Windows.Forms.TextBox pointTextBox;
        private System.Windows.Forms.TextBox condenserTextBox;
        private System.Windows.Forms.TextBox plugTextBox;
        private System.Windows.Forms.TextBox plugQtyTextBox;
        private System.Windows.Forms.TextBox fuelFilterTextBox;
        private System.Windows.Forms.TextBox airFilterTextBox;
        private System.Windows.Forms.TextBox remarksTextBox;
    }
}
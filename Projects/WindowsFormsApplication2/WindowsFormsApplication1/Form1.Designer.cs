namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private MainDictionaryDataSet mainDictionaryDataSet;
        private System.Windows.Forms.BindingSource geographicnamesBindingSource;
        private MainDictionaryDataSetTableAdapters.geographic_namesTableAdapter geographic_namesTableAdapter;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainDictionaryDataSet = new WindowsFormsApplication1.MainDictionaryDataSet();
            this.geographicnamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.geographic_namesTableAdapter = new WindowsFormsApplication1.MainDictionaryDataSetTableAdapters.geographic_namesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mainDictionaryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geographicnamesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(388, 223);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainDictionaryDataSet
            // 
            this.mainDictionaryDataSet.DataSetName = "MainDictionaryDataSet";
            this.mainDictionaryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // geographicnamesBindingSource
            // 
            this.geographicnamesBindingSource.DataMember = "geographic_names";
            this.geographicnamesBindingSource.DataSource = this.mainDictionaryDataSet;
            // 
            // geographic_namesTableAdapter
            // 
            this.geographic_namesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 507);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDictionaryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geographicnamesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
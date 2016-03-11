using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectedText = "<a>" + textBox1.SelectedText + "</a>";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainDictionaryDataSet.geographic_names' table. You can move, or remove it, as needed.
            this.geographic_namesTableAdapter.Fill(this.mainDictionaryDataSet.geographic_names);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bOK1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            this.Hide();
            newForm.Show();            
        }
    }
}
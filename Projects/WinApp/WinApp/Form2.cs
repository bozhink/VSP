using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void bOK2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            this.Hide();
            newForm.Show();
        }
    }
}
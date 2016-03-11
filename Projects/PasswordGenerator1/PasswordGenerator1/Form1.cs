using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            textBox1.Visible = true;
            button1.Visible = false;
            listBox1.Visible = false;
            this.Height = textBox1.Height + button2.Height+60;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = false;
            this.Height = 310;
            button4.Visible = true;
            button1.Visible = true;
            listBox1.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = false;
            this.Height = 310;
            button4.Visible = true;
            button1.Visible = true;
            listBox1.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            listBox1.Visible = false;
            this.Height = 310;
            textBox2.Visible = true;
        }

        private String gen(int n)
        {
            String ret = new String("chdbfd");

            return ret;
        }
    }
}

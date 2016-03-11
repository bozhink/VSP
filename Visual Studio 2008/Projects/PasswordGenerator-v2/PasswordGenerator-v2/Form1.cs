using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator_v2
{
    public partial class Form1 : Form
    {
        private string nullString = "0123456789abcdef";
        private int numberOfPasswords = 10;
        private string fileName;

        public Form1()
        {
            InitializeComponent();
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(textBox2, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider1.SetError(numericUpDown1, "");
            errorProvider1.SetError(textBox2, "");

            string sourceText = textBox1.Text;
            int length=(int) numericUpDown1.Value;
            bool generate = true;
            
            if (sourceText.Length < 3 && sourceText.Length > 0)
            {
                errorProvider1.SetError(textBox1, "Source string is too short: Enter more symbols!");
                textBox1.Focus();
                generate = false;
            }
            else if (sourceText.Length == 0)
            {
                sourceText = nullString;
                generate = true;
            }

            if (length < 1)
            {
                errorProvider1.SetError(numericUpDown1, "Length of password must be greater than 1!");
                numericUpDown1.Focus();
                generate = false;
            }

            if (generate)
            {
                numberOfPasswords = (int) numericUpDown2.Value;
                textBox2.Text = "";
                for (int i = 0; i < numberOfPasswords; i++)
                {
                    System.Threading.Thread.Sleep(((127 + DateTime.Now.Second) ^ DateTime.Now.Millisecond)%123);
                    textBox2.Text += GeneratePassword(sourceText, length);
                    textBox2.Text += "\x0D\x0A"; // END-OF-LINE (EOL) in DOS mode
                }
            }
        }

        private static int seed = ((DateTime.Now.Hour * 9348) ^ (DateTime.Now.Minute * 345) + (DateTime.Now.Second * 17)) % (DateTime.Now.Millisecond + 1);
        private System.Random rnd1 = new System.Random(seed + 1);

        public string GeneratePassword(string src, int len)
        {
            int i,k=0;
            int n = src.Length;
            string sret = "";
            seed = seed ^ (((DateTime.Now.Hour * 9347) ^ (DateTime.Now.Minute * 345) + (DateTime.Now.Second * 17)) % (DateTime.Now.Millisecond + 1));
            System.Random rnd2 = new System.Random(seed + 7);
            for (i = 0; i < len; i++)
            {
                k = ((rnd1.Next(0, n)+rnd2.Next(0, n)+n)%n + rnd2.Next(0, n)*rnd1.Next(0, n)%n + n)%n;
                sret += src[k];
            }
            return sret;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            System.IO.StreamWriter f = new System.IO.StreamWriter(saveFileDialog1.OpenFile());
            f.Write(textBox2.Text);
            f.Close();
        }
    }
}

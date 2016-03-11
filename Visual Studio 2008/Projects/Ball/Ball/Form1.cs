using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g;
            Color c = new Color();
            Pen p = new Pen(c, 10.0f);
            g.DrawEllipse(p, 20.0f, 20.0f, 100.0f, 130.0f);
        }
    }
}

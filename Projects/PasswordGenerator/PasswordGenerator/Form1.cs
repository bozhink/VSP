using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int passLen;
            switch (cmbPassLength.Text)
            {
                case "8": passLen = 8; break;
                case "12": passLen = 12; break;
                case "16": passLen = 16; break;
                case "24": passLen = 24; break;
                case "32": passLen = 32; break;
                case "36": passLen = 36; break;
                case "64": passLen = 64; break;
                default: passLen = 4; break;
            }

            string srcString;
            switch (cmbSrcString.Text)
            {
                case "ss1": srcString = ss1; break;
                case "ss2": srcString = ss2; break;
                case "ss3": srcString = ss3; break;
                case "ss4": srcString = ss4; break;
                case "ss5": srcString = ss5; break;
                case "ss6": srcString = ss6; break;
                case "ss7": srcString = ss7; break;
                case "ss8": srcString = ss8; break;
                default: srcString = ss9; break;
            }

            int srcLen = srcString.Length;
            float fsrcLen = (float) srcLen;
            int idx;

            txtPassword.Text = "";
            for (int i = 0; i < passLen; i++)
            {
                idx = (int)( fsrcLen * VBMath.Rnd(1.0f) );
                txtPassword.Text = txtPassword.Text + srcString[idx];
            }
        }

        private void cmbSrcString_SelectedValueChanged(object sender, EventArgs e)
        {
            string srcString;
            switch (cmbSrcString.Text)
            {
                case "ss1": srcString = ss1; break;
                case "ss2": srcString = ss2; break;
                case "ss3": srcString = ss3; break;
                case "ss4": srcString = ss4; break;
                case "ss5": srcString = ss5; break;
                case "ss6": srcString = ss6; break;
                case "ss7": srcString = ss7; break;
                case "ss8": srcString = ss8; break;
                default: srcString = ss9; break;
            }
            lblDescription.Text = srcString;
        }
    }
}
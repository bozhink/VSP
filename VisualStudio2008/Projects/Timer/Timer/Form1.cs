using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        private DateTime dt0;
        private DateTime dt1;
        private bool firstTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Select();
            firstTime = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTime();
        }

        private void GetTime()
        {
            if (firstTime)
            {
                firstTime = false;
                dt0 = DateTime.Now;
            }
            dt1 = DateTime.Now;
            textBox1.Text += 
                FormatTime(dt1.Hour, dt1.Minute, dt1.Second, dt1.Millisecond)
                + "\t" +
                FormatTime(
                (dt1.Hour - dt0.Hour),
                (dt1.Minute - dt0.Minute),
                (dt1.Second - dt0.Second),
                (dt1.Millisecond - dt0.Millisecond))
                + "\t" +
                ElapsedTime(dt0,dt1) 
                + "\x0D\x0A";
            dt0 = dt1;
        }

        private void getTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Select();
            GetTime();
        }

        private void clearResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            firstTime = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            System.IO.StreamWriter f = new System.IO.StreamWriter(saveFileDialog1.OpenFile());
            f.Write(textBox1.Text);
            f.Close();
        }

        String FormatTime(int hour, int minute, int second, int millisecond)
        {
            String str = "";

            if (millisecond < 0)
            {
                millisecond += 1000;
                second -= 1;
            }
            if (second < 0)
            {
                second += 60;
                minute -= 1;
            }
            if (minute < 0)
            {
                minute += 60;
                hour -= 1;
            }

            if (hour < 10)
            {
                str += "0" + hour;
            }
            else
            {
                str += hour;
            }
            str += ":";
            if (minute < 10)
            {
                str += "0" + minute;
            }
            else
            {
                str += minute;
            }
            str += ":";
            if (second < 10)
            {
                str += "0" + second;
            }
            else
            {
                str += second;
            }
            str += ":";
            if (millisecond < 10)
            {
                str += "00" + millisecond;
            }
            else if (millisecond < 100)
            {
                str += "0" + millisecond;
            }
            else
            {
                str += millisecond;
            }
            return str;
        }

        private String ElapsedTime(DateTime dt1, DateTime dt2)
        {
            String str="";
            int hour = dt2.Hour - dt1.Hour;
            int minute = dt2.Minute - dt1.Minute;
            int second = dt2.Second - dt1.Second;
            int millisecond = dt2.Millisecond - dt1.Millisecond;
            long seconds = second + minute * 60 + hour * 3600;
            if (millisecond < 0)
            {
                millisecond += 1000;
                second -= 1;
            }
            str = (second + minute * 60 + hour * 3600) + "." + millisecond;
            return str;
        }
    }
}

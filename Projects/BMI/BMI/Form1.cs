using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int weight=0, height=1;
            errorProvider1.SetError(textBox1, "");
            errorProvider2.SetError(textBox2, "");
            try
            {
                weight = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException err)
            {
                errorProvider1.SetError(textBox1,"Невалидни данни: Въведете цяло число.");
                textBox1.Focus();
            }
            try 
            {
                height = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException err)
            {
                errorProvider2.SetError(textBox2, "Невалидни данни: Въведете цяло число.");
                textBox2.Focus();
            }

                double bmi = (double)weight*10000 / (height * height);
                textBox3.Text = bmi.ToString();
                if (bmi < 16.0)
                {
                    label6.Text = "Поднормено тегло: Тежко недохранване.";
                }
                else if (bmi < 17.0)
                {
                    label6.Text = "Поднормено тегло: Средно недохранване.";
                }
                else if (bmi < 18.5)
                {
                    label6.Text = "Поднормено тегло: Леко недохранване.";
                }
                else if (bmi < 25)
                {
                    label6.Text = "Нормално тегло.";
                }
                else if (bmi < 30)
                {
                    label6.Text = "Наднормено тегло: Предзатлъстяване.";
                }
                else if (bmi < 35)
                {
                    label6.Text = "Затлъстяване: Затлъстяване I степен.";
                }
                else if (bmi < 40)
                {
                    label6.Text = "Затлъстяване: Затлъстяване II степен.";
                }
                else if (bmi > 40)
                {
                    label6.Text = "Затлъстяване: Затлъстяване III степен.";
                }
                else 
                { 
                    label6.Text = "Грешка във входните данни."; 
                }
            
            
        }
    }
}

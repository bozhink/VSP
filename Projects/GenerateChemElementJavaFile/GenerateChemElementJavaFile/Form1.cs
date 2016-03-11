using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenerateChemElementJavaFile
{
    public partial class Form1 : Form
    {
        private string shortName;
        private string longName;
        private int Z;
        private double A;
        private int periodNumber;
        private int groupNumber;
        private char groupType;
        private char elementType;
        private int[] electronStructure=new int[7];

        public Form1()
        {
            InitializeComponent();
        }

        void GetElectronStructure(string arg)
        {
            bool getNumber = false; // marks if there is an integer to be read
            bool previousIsNum = false;

            int currentArrayIndex = 0;

            int ifirst, ilast;
            bool setFirstByte = false; // if first byte of integer is found
            bool setLastByte = false; // if last byte of integer is found

            char[] ch = arg.ToCharArray();
            string current="";
            ifirst = 0;
            ilast = ifirst;
            /*
             * In the following cycle current integer is read only
             * if the next character is not an integer.
             * So we have to try to read an integer if the last
             * character ch[arg.Length] is integer
             */
            for (int i = 0; i < arg.Length; i++)
            {
                /*
                 * If current char is integer then update fist and last
                 * bytes of the string which contains the integer
                 */
                if ((ch[i] == '0' || ch[i] == '1' || ch[i] == '2' || ch[i] == '3' ||
                    ch[i] == '4' || ch[i] == '5' || ch[i] == '6' || ch[i] == '7' ||
                    ch[i] == '8' || ch[i] == '9'))
                {
                    if (!setFirstByte)
                    {
                        setFirstByte = true;
                        ifirst = i;
                        ilast = ifirst;
                    }
                    if (!setLastByte)
                    {
                        setLastByte = true;
                    }
                    ilast = i;
                    previousIsNum = true;
                    getNumber = true;
                }
                else
                {
                    if (!previousIsNum)
                    {
                        /*
                         * If previous byte does not contain an integer
                         * then we don't have to read next integer in array
                         */
                        setFirstByte = false;
                        setLastByte = false;
                        getNumber = false;
                    }
                    else
                    {
                        /*
                         * If current character is not an integer
                         * but the previous character is then read
                         * the previous integer string
                         */
                        setFirstByte = false;
                        setLastByte = false;
                        if (getNumber)
                        {
                            current = "";
                            for (int j = ifirst; j <= ilast; j++)
                            {
                                current += ch[j];
                            }
                            electronStructure[currentArrayIndex] =
                                int.Parse(current);
                            currentArrayIndex++;
                        }
                        getNumber = false;
                    }

                }
            }
            /*
             * Here we try to read the last integer if ch[arg.Length]
             * is an integer
             */
            if (previousIsNum)
            {
                setFirstByte = false;
                setLastByte = false;
                if (getNumber)
                {
                    current = "";
                    for (int j = ifirst; j <= ilast; j++)
                    {
                        current += ch[j];
                    }
                    electronStructure[currentArrayIndex] =
                        int.Parse(current);
                    currentArrayIndex++;
                }
                getNumber = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shortName = textBox1.Text;
            longName = textBox2.Text;
            Z = int.Parse(textBox3.Text);
            A = double.Parse(textBox4.Text);
            periodNumber = int.Parse(textBox5.Text);
            groupNumber = int.Parse(textBox6.Text);
            groupType = ((textBox7.Text.ToUpper()).ToCharArray())[0];
            elementType = ((textBox8.Text.ToLower()).ToCharArray())[0];
            GetElectronStructure(textBox9.Text);

            System.IO.StreamWriter sw = new System.IO.StreamWriter(shortName+".java");
            sw.WriteLine("package chem.mendeleev.table;");
            sw.WriteLine();
            sw.WriteLine("public class " + shortName + " extends Element");
            sw.WriteLine("{");
            sw.WriteLine("\tpublic " + shortName +"()");
            sw.WriteLine("\t{");
            sw.WriteLine("\t\tshortName = \"{0}\";", shortName);
            sw.WriteLine("\t\tlongName = \"{0}\";", longName);
            sw.WriteLine("\t\tZ = {0};", Z);
            sw.WriteLine("\t\tA = {0};", A);
            sw.WriteLine("\t\tperiodNumber = {0};", periodNumber);
            sw.WriteLine("\t\tgroupNumber = {0};", groupNumber);
            sw.WriteLine("\t\tgroupType = \'{0}\';", groupType);
            sw.WriteLine("\t\telementType = \'{0}\';", elementType);
            sw.WriteLine("\t\telectronStructure = new int[{0}];", periodNumber);
            for (int i = 0; i < periodNumber; i++)
            {
                sw.WriteLine("\t\telectronStructure[{0}] = {1};", i, 
                    electronStructure[i]);
            }
            sw.WriteLine("\t}");
            sw.WriteLine("}");
            sw.WriteLine();
            sw.Close();
            textBox1.Focus();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveTags
{
    class Program
    {
        private const string Charset = "utf-8";

        static void Main(string[] args)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            Encoding encoding = Encoding.GetEncoding(Charset);
            string line = string.Empty;
            StringBuilder result = new StringBuilder();

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: RemoveTags <input file name> <output file name>");
                return;
            }

            string InputFileName = args[0];
            string OutputFileName = args[1];
            if (!File.Exists(InputFileName))
            {
                Console.WriteLine("File " + InputFileName + "not found.");
                return;
            }

            String file = null;
            try
            {
                reader = new StreamReader(InputFileName, encoding);
                while ((line = reader.ReadLine()) != null)
                {
                    file += line + '\n';
                }
                // Console.ReadKey();
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Can not read file " + InputFileName + ".");
                Console.WriteLine(ioex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }


            try
            {
                reader = new StreamReader(InputFileName, encoding);
                writer = new StreamWriter(OutputFileName, false, encoding);
                while ((line = reader.ReadLine()) != null)
                {
                    /*
                    line = RemoveAllTags(line);
                    line = RemoveDoubleNewLines(line);
                    line = TrimNewLines(line);
                    line = line.Trim();
                     */
                    line = Regex.Replace(file, "\r", "");
                    if (!string.IsNullOrEmpty(line))
                    {
                        writer.WriteLine(getYear(line));
                    }
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Can not read file " + InputFileName + ".");
                Console.WriteLine(ioex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public static string RemoveAllTags(string str)
        {
            string textWithoutTags = Regex.Replace(str, "<[^>]*>", "\n");
            return textWithoutTags;
        }

        public static string RemoveDoubleNewLines(string str)
        {
            string pattern = "\n\\s+";
            return Regex.Replace(str, pattern, "\n");
        }

        public static string TrimNewLines(string str)
        {
            int start = 0;
            while (start < str.Length && str[start] == '\n')
            {
                start++;
            }

            int end = str.Length - 1;
            while (end >= 0 && str[end] == '\n')
            {
                end--;
            }

            if (start > end)
            {
                return string.Empty;
            }

            string trimmed = str.Substring(start, end - start + 1);
            return trimmed;
        }

        public static string getYear(string str)
        {
            string pattern = "([1-2][6-90][0-9][0-9])[^0-0]";
            return Regex.Replace(str, pattern, "<xref>$1</xref>");
        }
    }
}

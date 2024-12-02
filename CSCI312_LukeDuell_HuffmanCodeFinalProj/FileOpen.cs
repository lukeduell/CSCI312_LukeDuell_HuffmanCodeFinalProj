using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;



namespace HuffmanEncoding
{
    class FileOpen
    {
        public string read { get; set; }
        public string readexport { get; set; }
        public string getListFromFile()
        {

            Console.WriteLine("Example file: \"a.txt\"\n");
            Console.Write("Enter the path of the file: ");
            String filename = Console.ReadLine();
            bool checkingchar;
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < stream.Length; i++)
                {
                    readexport = File.ReadAllText(filename);
                    if (checkingchar = !Regex.IsMatch(readexport, @"^[a-zA-Z]+$") || (readexport == string.Empty))
                    {
                        Console.WriteLine("Error File is Empty or Contains Illigal Characters");
                        goto end;
                    }
                    readexport = readexport.Replace("\n", string.Empty);
                    readexport = readexport.Replace("\r", string.Empty);
                    readexport = readexport.Replace(" ", string.Empty);
                    readexport = readexport.Replace("\t", string.Empty);
                }
            }
            catch (IOException)
            {
                return null;
            }
            end:
            return readexport;
        }
    }
}
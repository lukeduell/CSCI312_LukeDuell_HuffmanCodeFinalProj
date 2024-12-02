using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileOpen FileOpen = new FileOpen();
            HuffmanTree huffmanTree = new HuffmanTree();
            Top:
            //opening the file
            string input = FileOpen.getListFromFile();

            if(input == null)
            {
                Console.WriteLine("Error Reading From File or File Does Not Exist");
                Console.WriteLine("Press any key to continue or Enter \"X\" to exit the program.");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "x")
                    goto Exit;
                else
                    goto Top;
            }
            else
            {
                // Build the Huffman tree
                huffmanTree.BuildTree(input);

                // Encode
                BitArray encoded = huffmanTree.EncodeHuff(input);

                Console.WriteLine("\n\n-----------  Encoded Message  -----------\n");
                foreach (bool bit in encoded)
                {
                    Console.Write((bit ? 1 : 0) + "");
                }

                // Decode
                string decoded = huffmanTree.DecodeHuff(encoded);

                Console.WriteLine("\n\n-----------  Decoded Message  -----------\n");
                Console.WriteLine(decoded);
                Console.WriteLine("\n\n-----------------------------------------\n");
            }
        Exit:
            //prompting the user to restart or end the program
            Console.WriteLine("Task Complete...To Restart Enter \"R\" To Exit Enter \"X\"");
            string restart = Console.ReadLine();
            if (restart.ToLower() == "r")
            {
                goto Top;
            }
        }
    }
}
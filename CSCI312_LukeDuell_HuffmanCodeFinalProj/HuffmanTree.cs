using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace HuffmanEncoding
{
    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();
        public Node RootNode { get; set; }
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void BuildTree(string input)
        {
            //checking the frequencies of each input character
            for (int i = 0; i < input.Length; i++)
            {
                if (!Frequencies.ContainsKey(input[i]))
                {
                    Frequencies.Add(input[i], 0);
                }
                Frequencies[input[i]]++;
            }
            //adding the frequencies for each input character
            foreach (KeyValuePair<char, int> symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, FrequencyCheck = symbol.Value });
            }
            //creating the nodes
            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.FrequencyCheck).ToList<Node>();

                //ordering the nodes by frequency
                if (orderedNodes.Count >= 2)
                {
                    //taking the first two nodes to combine them
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    //combining the two nodes to make a parent node
                    Node parent = new Node()
                    {
                        Symbol = '*',
                        FrequencyCheck = taken[0].FrequencyCheck + taken[1].FrequencyCheck,
                        LeftNode = taken[0],
                        RightNode = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                this.RootNode = nodes.FirstOrDefault();

            }

        }

        public BitArray EncodeHuff(string source)
        {
            List<bool> encodedInput = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                //binary search tree implementation using traverse
                List<bool> encodedSymbol = this.RootNode.BSTree(source[i], new List<bool>());

                //adding elementes to the end of the encoded symbol list
                encodedInput.AddRange(encodedSymbol);
            }
            //moving the bits to an array for exporting
            BitArray bits = new BitArray(encodedInput.ToArray());

            return bits;
        }

        public string DecodeHuff(BitArray bits)
        {
            Node current = this.RootNode;
            string decoded = "";

            //translating each but back to the origional character by looking at the nodes
            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.RightNode != null)
                    {
                        current = current.RightNode;
                    }
                }
                else
                {
                    if (current.LeftNode != null)
                    {
                        current = current.LeftNode;
                    }
                }

                if (IsLeaf(current))
                {
                    decoded += current.Symbol;
                    current = this.RootNode;
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)
        {
            return (node.LeftNode == null && node.RightNode == null);
        }

    }
}
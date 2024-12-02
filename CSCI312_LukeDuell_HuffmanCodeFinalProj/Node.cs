using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanEncoding
{
    public class Node
    {
        public char Symbol { get; set; }
        public int FrequencyCheck { get; set; }
        public Node RightNode { get; set; }
        public Node LeftNode { get; set; }

        //binary search tree implementation
        public List<bool> BSTree(char symbol, List<bool> data)
        {
            //adding leafs for nodes
            if (RightNode == null && LeftNode == null)
            {
                // if symbol in list equals current symbol return value
                if (symbol.Equals(this.Symbol))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //initializing nodes for out
                List<bool> leftout = null;
                List<bool> rightout = null;

                if (LeftNode != null)
                {
                    List<bool> leftPathout = new List<bool>();
                    //adding symbol to end of leftpathout
                    leftPathout.AddRange(data);
                    leftPathout.Add(false);
                    //binary search tree implementation adding symbol
                    leftout = LeftNode.BSTree(symbol, leftPathout);
                }

                if (RightNode != null)
                {
                    List<bool> rightPathout = new List<bool>();
                    //adding symbol to end of right path out
                    rightPathout.AddRange(data);
                    rightPathout.Add(true);
                    //binary search tree implementation adding symbol
                    rightout = RightNode.BSTree(symbol, rightPathout);
                }

                //if any are null return the other node from tree
                if (leftout != null)
                {
                    return leftout;
                }
                else
                {
                    return rightout;
                }
            }
        }
    }
}
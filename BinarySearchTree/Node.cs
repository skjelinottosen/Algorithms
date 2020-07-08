using System;
namespace BinarySearchTree
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Data = value;
            Left = null;
            Right = null;
        }
    }
}

using System;
namespace Stack
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int s)
        {
            Data = s;
            Next = null;
        }
    }
}

using System;
namespace Hashing
{
    //No rehashing at full table / long lists
    //Offers insertion and search only
    public class ChainedHashClass
    {
        private class Node
        {
            public string Data;
            public Node Next { get; set; }

            public Node(String data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        public int HashLength { get; set; }
        Node[] HashTable;
        public int NumElements { get; set; }
        public int NumCollisions { get; set; }


        public ChainedHashClass(int hashLength)
        {
            HashLength = hashLength;
            HashTable = new Node[HashLength];
            NumElements = 0;
            NumCollisions = 0;

        }

        public float LoadFactor()
        {
            return HashLength / NumElements;
        }

        public int Hash(string s)
        {
            int hashValue = Math.Abs(s.GetHashCode());
            return hashValue % HashLength;
        }

        public void Insert(string s)
        {
            int index = Hash(s);
            NumElements++;

            if (HashTable[index] != null)
            {
                NumCollisions++;
            }

            HashTable[index] = new Node(s, HashTable[index]);
        }

        public bool Search(string s)
        {
            Node node = HashTable[Hash(s)];

            while (node != null)
            {
                if (node.Data == s)
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }
    }
}

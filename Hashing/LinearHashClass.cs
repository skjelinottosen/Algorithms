using System;
namespace Hashing
{
    //No rehashing at full table / long lists
    //Offers insertion and search only
    public class LinearHashClass
    {
        public int HashLength { get; set; }
        private String[] HashTable;
        public int NumElements { get; set; }
        public int NumProbes { get; set; }

        public LinearHashClass(int hashLength)
        {
            HashLength = hashLength;
            HashTable = new String[HashLength];
            NumElements = 0;
            NumProbes = 0;
        }

        public float Loadfactor()
        {
            return (float)NumElements / HashLength;
        }


        public int Hash(string s)
        {
            int hashValue = Math.Abs(s.GetHashCode());
            return hashValue % HashLength;
        }

        //Insert with quadratic probing
        public void Insert(string s)
        {
            int index = Hash(s);
            int step = 0;
            int next = index;

            while (HashTable[next] != null)
            {
                step++;
                NumProbes++;
                next = index + (step * step);

                //Wrap around
                if (next >= HashLength)
                {
                    next %= HashLength;
                }

                if (next == HashLength)
                {
                    Console.WriteLine("Error: Hashtable is full");
                }
            }

            //Stores value in hashtable at index "next"
            HashTable[next] = s;
            NumElements++;
        }

        public bool Search(string s)
        {
            int index = Hash(s);
            int step = 0;
            int next = index;

            while (HashTable[next] != null)
            {
                if (HashTable[next].CompareTo(s) == 0)
                {
                    return true;
                }

                step++;
                next = index + (step * step);

                //Wrap around
                if (next >= HashLength)
                {
                    next %= HashLength;
                }

                if (next == HashLength)
                {
                    return false;
                }
            }
            return false;
        }
    }
}

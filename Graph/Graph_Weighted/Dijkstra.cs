using System;
namespace Graph_Weighted
{
    //O(n^2) Dijkstra algorithm for SSSP starting in a node S
    //Prints the solution array
    public class Dijkstra : Graph
    {
        public Dijkstra(string filename) : base(filename)
        {
        }

        public void DijkstraSSSP(int s)
        {
            //Marks the nodes that we have already found
            bool[] Found = new bool[NumNodes];

            //Array to store the shortest known distance to each so far
            int[] Distance = new int[NumNodes];

            //Initiates the arrays
            for (int i = 0; i < NumNodes; i++)
            {
                for (int j = 0; j < NumNodes; j++)
                {
                    Distance[i] = (i == s) ? 0 : Infinity;
                    Found[i] = false;
                }
            }


            //Current node and count of nodes found
            int current = s, count = 0;

            while (count < NumNodes)
            {
                int min = Infinity;
                for (int i = 0; i < NumNodes; i++)
                {
                    if (!Found[i] && Distance[i] < min)
                    {
                        current = i;
                        min = Distance[i];
                    }
                }

                // Update distances for all neighbors to the current node not found
                for (int i = 0; i < NumNodes; i++)
                {
                    if (!Found[i])
                    {
                        int newLength = Distance[current] + Length[current, i];
                        if (newLength < Distance[i])
                        {
                            Distance[i] = newLength;
                        }
                    }
                }

                //Mark that we have found the shortest distance to the current node
                Found[current] = true;
                count++;
            }
            //Print
            //Head
            Console.Write("  ");
            for (int i = 0; i < NumNodes; i++)
            {
                Console.Write(" " + Data[i] + " ");
            }
            Console.WriteLine();

            //Body
            Console.Write(Data[s] + ":");
            for (int i = 0; i < NumNodes; i++)
            {
                if (Distance[i] == Infinity)
                {
                    Console.Write(" ∞ ");
                }
                else
                {
                    Console.Write(" " + Distance[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}

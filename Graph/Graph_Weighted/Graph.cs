using System;
using System.IO;

namespace Graph_Weighted
{
    public class Graph
    {
        public int NumNodes;
        public int[,] Length;
        public string[] Data;
        public readonly int Infinity = 999999;

        public Graph(string filename)
        {
            ReadFile(filename);

        }

        public int NumberOfNodes()
        {
            return NumNodes;
        }

        public void ReadFile(string filename)
        {
            try
            {
                string text = System.IO.File.ReadAllText(filename);
                Scanner input = new Scanner(text);
                NumNodes = input.nextInt();
                //Creates the arrays that store the graph
                Length = new int[NumNodes, NumNodes];
                Data = new string[NumNodes];

                //Initiates the entire edge matrix to INFINITE (no edge),
                //with 0 on the diagonal (nodes have "distance 0 to themself")

                for (int i = 0; i < NumNodes; i++)
                {
                    for (int j = 0; j < NumNodes; j++)
                    {
                        Length[i, j] = (i == j) ? 0 : Infinity;
                    }
                }

                //Reads one line of data from each node
                for (int i = 0; i < NumNodes; i++)
                {
                    int nodeNumber = input.nextInt();
                    Data[nodeNumber] = input.next();

                    //Read number of Length for the current node
                    int numNeighbors = input.nextInt();

                    //Reads and inserts all the Length in the neighboring matrix
                    for (int j = 0; j < numNeighbors; j++)
                    {
                        int neighborNumber = input.nextInt();
                        int edgeLength = input.nextInt();
                        Length[nodeNumber, neighborNumber] = edgeLength;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Print()
        {
            //Head
            Console.Write("  ");
            for (int i = 0; i < NumNodes; i++)
            {
                Console.Write(" " + Data[i] + " ");
            }
            Console.WriteLine();

            //Body
            for (int i = 0; i < NumNodes; i++)
            {
                Console.Write(Data[i] + " ");
                for (int j = 0; j < NumNodes; j++)
                {
                    if (Length[i, j] == Infinity)
                    {
                        Console.Write(" ∞ ");
                    }
                    else
                    {
                        if (Length[i, j] < 10)
                        {
                            Console.Write(" " + Length[i, j] + " ");
                        }
                        else
                        {
                            Console.Write(Length[i, j] + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

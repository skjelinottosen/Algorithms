using System;
namespace Graph_Unweighted
{
    public class Warshall : Graph
    {
        public Warshall(string filename) : base(filename)
        {
        }

        //The solution is stored in the original neighbor matrix of the graph
        public void WarshallAPRP()
        {
            for (int k = 0; k < NumNodes; k++)
            {
                //Tries every node as a starting point
                for (int i = 0; i < NumNodes; i++)
                {
                    //Tries every node as a ending point
                    for (int j = 0; j < NumNodes; j++)
                    {
                        //Is there a way from i to j through k?
                        Neighbors[i, j] = Neighbors[i, j] || (Neighbors[i, k] && Neighbors[k, j]);
                    }
                }
            }
        }
    }
}

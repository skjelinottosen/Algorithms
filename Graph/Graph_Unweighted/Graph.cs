using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Graph_Unweighted
{
    public class Graph
    {
        public int NumNodes;
        public bool[,] Neighbors;
        string[] Data;
        bool[] Visited;

        public Graph(string filename)
        {
            ReadFile(filename);
            Visited = new bool[NumNodes];
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
                Neighbors = new bool[NumNodes, NumNodes];
                Data = new string[NumNodes];

                //Initiates the entire neighbor matrix to false, except the main
                //diagonal who is set to true (the nodes are neighbor with themself)

                for (int i = 0; i < NumNodes; i++)
                {
                    for (int j = 0; j < NumNodes; j++)
                    {
                        if (Neighbors[i, j] = (i == j))
                        {
                            Neighbors[i, j] = true;
                        }
                        else
                        {
                            Neighbors[i, j] = false;
                        }
                    }
                }


                for (int i = 0; i < NumNodes; i++)
                {
                    int nodeNumber = input.nextInt();
                    Data[nodeNumber] = input.next();

                    //Read number of neighbors for the current node
                    int numNeighbors = input.nextInt();

                    //Reads and inserts all the neighbors in the neighboring matrix
                    for (int j = 0; j < numNeighbors; j++)
                    {
                        int neighborNumber = input.nextInt();
                        Neighbors[nodeNumber, neighborNumber] = true;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Depth-first traversal starting with a given node
        //Seeks out each node and prints data in the node
        public void DFS(int start)
        {
            //Marks all the nodes that has not been visited
            for (int i = 0; i < NumNodes; i++)
            {
                Visited[i] = false;
            }

            //Calls an internal recursive method that does itself the traversal
            Console.WriteLine("Depth-First Search");
            rDFS(start);
            Console.WriteLine();
        }

        internal void rDFS(int start)
        {
            Console.Write(Data[start] + " ");
            //Marks visited node as true
            Visited[start] = true;

            //Recursively seeks out all node neighbors that have not been visited earlier
            for (int i = 0; i < NumNodes; i++)
            {
                if (Neighbors[start, i] && !Visited[i])
                {
                    rDFS(i);
                }
            }
        }

        //Breadth-first traversal starting with a given node
        public void BFS(int start)
        {
            //Marks all the nodes that has not been visited
            for (int i = 0; i < NumNodes; i++)
            {
                Visited[i] = false;
            }
            LinkedQueue queue = new LinkedQueue();
            queue.Equeue(start);
            Visited[start] = true;

            Console.WriteLine("Breadth-First Search");
            while (!queue.IsEmpty())
            {
                //Removes the first node and visit it while printing out its value
                int index = queue.Dequeue();
                Console.Write(Data[index] + " ");

                //Adds all undiscovered / unsaved neighbors at this time node at the back of the queue
                for (int i = 0; i < NumNodes; i++)
                {
                    if (Neighbors[index, i] && !Visited[i])
                    {
                        queue.Equeue(i);
                        Visited[i] = true;
                    }
                }
            }
            Console.WriteLine();
        }

        public void Print()
        {
            for (int i = 0; i < NumNodes; i++)
            {
                Console.Write(Data[i] + ": ");
                for (int j = 0; j < NumNodes; j++)
                {
                    //If node i marked true ( i=!j not taking ref to itself)
                    if (Neighbors[i, j] && i != j)
                    {
                        Console.Write(Data[j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

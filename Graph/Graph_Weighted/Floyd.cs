using System;
namespace Graph_Weighted
{
    public class Floyd : Graph
    {
        public Floyd(string filename) : base(filename)
        {
        }

        public void FloydAPSP()
        {
            //Builds up the solution matrix step by step where k "is" the max range for visited nodes.
            for (int k = 0; k < NumNodes; k++)
            {
                for (int i = 0; i < NumNodes; i++)
                {
                    for (int j = 0; j < NumNodes; j++)
                    {
                        //Is there a shorter way from i to j through k?
                        int newLength = Length[i, k] + Length[k, j];
                        if (newLength < Length[i, j])
                        {
                            Length[i, j] = newLength;
                        }
                    }
                }
            }
        }
    }
}

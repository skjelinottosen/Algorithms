using System;
namespace Heap
{
    public class MinHeap
    {
        private int[] Array;
        private int IndexLastElement;
        private int MaxSize;

        public MinHeap(int size)
        {
            MaxSize = size;
            Array = new int[MaxSize];
            IndexLastElement = -1;
        }

        public bool IsEmpty()
        {
            if (IndexLastElement < 0)
            {
                return true;
            }
            return false;
        }

        public void Insert(int value)
        {
            IndexLastElement++;

            if (IndexLastElement == MaxSize)
            {
                Console.WriteLine("Error: Heap is full");
                Environment.Exit(1);
            }

            int childIndex = IndexLastElement;
            int parentIndex = (childIndex - 1) / 2;
            Array[childIndex] = value;
            bool done = false;

            while (!done)
            {
                //New value is root?
                if (childIndex == 0)
                {
                    done = true;
                }
                //New value is greater than parent node. 
                else if (Array[childIndex] > Array[parentIndex])
                {
                    done = true;
                }

                else
                {
                    //Swaps child and parent nodes
                    int tmp = Array[childIndex];
                    Array[childIndex] = Array[parentIndex];
                    Array[parentIndex] = tmp;
                }

                //Finds indexes for next parent and child node
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }
        }

        public int RemoveMin()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Error: Heap is empty");
                Environment.Exit(1);
            }

            int min = Array[0];

            //Moves value on the last index to the root index
            Array[0] = Array[IndexLastElement];
            IndexLastElement--;

            int currentNodeIndex = 0, nextNodeIndex = 0;
            int leftNodeIndex, rightNodeIndex;
            bool done = false;

            while (!done)
            {
                //Calculates the indexes of left and right child
                leftNodeIndex = 2 * currentNodeIndex + 1;
                rightNodeIndex = leftNodeIndex + 1;

                //If index of the Left child is outside the heap, the child (current node) will have a correct position as a leaf.
                if (leftNodeIndex > IndexLastElement)
                {
                    done = true;
                }
                else
                {
                    /*If the index of the right child is outside the heap, shall the node be swaped with the left child if the left node
                    has a lower value */
                    if (rightNodeIndex > IndexLastElement)
                    {
                        nextNodeIndex = leftNodeIndex;
                    }

                    //If both childen is in the heap, will the chidren get compared and swaped if the other child has a lower value.
                    if (Array[leftNodeIndex] < Array[rightNodeIndex])
                    {
                        nextNodeIndex = leftNodeIndex;
                    }
                    else
                    {
                        nextNodeIndex = rightNodeIndex;
                    }

                    //Finished if the new value har a correct possition against the child with the lowest value;
                    if (Array[currentNodeIndex] < Array[nextNodeIndex])
                    {
                        done = true;
                    }
                }

                //If not finished, swap the child with the lowest value and continue down the heap
                if (!done)
                {
                    int tmp = Array[nextNodeIndex];
                    Array[nextNodeIndex] = Array[currentNodeIndex];
                    Array[currentNodeIndex] = tmp;
                }
            }
            return min;
        }

        public void Print()
        {
            for (int i = 0; i <= IndexLastElement; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
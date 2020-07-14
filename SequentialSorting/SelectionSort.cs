using System;
namespace SequentialSorting
{
    //Safe: Allways O(n2)
    public class SelectionSort
    {
        public SelectionSort()
        {
        }

        public void Sort(int[] array)
        {
            int length = array.Length;
            int min, tmp;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                //Finds the lowest value in the array and update the variable "min"
                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                    //Swap index i with min
                    tmp = array[min];
                    array[min] = array[i];
                    array[i] = tmp;
                }
            }
        }
    }
}

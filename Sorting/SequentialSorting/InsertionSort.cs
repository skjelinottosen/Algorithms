using System;
namespace SequentialSorting
{
    // Efficient if the array is almost sorted ( Little swaping = O(n)).
    //Good alternative for smaller n-values. Worst case 0(n^2).
    public class InsertionSort
    {
        public InsertionSort()
        {
        }

        public void Sort(int[] array)
        {
            int length = array.Length;
            int key;

            for (int i = 1; i < length; i++)
            {
                key = array[i];
                int j = i;

                while (j > 0 && array[j - 1] > key)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = key;
            }
        }
    }
}

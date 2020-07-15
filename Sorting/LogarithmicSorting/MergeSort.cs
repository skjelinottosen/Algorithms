using System;
namespace LogarithmicSorting
{
    //Runtime O(n log (n)), but uses an extra array in memory 
    public class MergeSort
    {
        public MergeSort()
        {
        }

        public void Sort(int[] array, int min, int max)
        {
            //Base case: 1 element in the array
            if (min == max)
            {
                return;
            }

            int left, right;
            int size = max - min + 1;
            int mid = (min + max) / 2;
            int[] tmpArray = new int[size];

            //Sorts the left and right part of the array
            Sort(array, min, mid);
            Sort(array, mid + 1, max);

            //Copies the data over in a temporary array
            for (int i = 0; i < size; i++)
            {
                tmpArray[i] = array[min + i];
            }

            //Merge the left array and the left to together
            //Defines the start in the left array.
            left = 0;
            right = mid - min + 1;

            for (int i = 0; i < size; i++)
            {
                //Checks if the right array are done
                if (right <= max - min)
                {
                    //Checks if the left array are done
                    if (left <= mid - min)
                    {
                        if (tmpArray[left] > tmpArray[right])
                        {
                            array[i + min] = tmpArray[right++];
                        }
                        else
                        {
                            array[i + min] = tmpArray[left++];
                        }
                    }
                    else
                    {
                        array[i + min] = tmpArray[right++];
                    }
                }
                else
                {
                    array[i + min] = tmpArray[left++];
                }
            }
        }
    }
}

using System;
namespace LogarithmicSorting
{
    //Average runtime O(n log(n)) 
    public class QuickSort
    {
        public QuickSort()
        {
        }
        
        public void Sort(int[] array, int min, int max)
        {
            int partition;

            if (max - min > 0)
            {
                //Finds partition
                partition = FindPartition(array, min, max);

                //Sorts the left and right part of the array
                Sort(array, min, partition - 1);
                Sort(array, partition + 1, max);
            }
        }

        private int FindPartition(int[] array, int min, int max)
        {
            int left, right, tmp, partitionElement;

            //Sets the first element of the array to be the partition element
            partitionElement = array[min];
            left = min;
            right = max;

            while (left < right)
            {
                //Find elements that are greater than the partitions
                while (array[left] <= partitionElement && left < right)
                {
                    left++;
                }

                //Find elements that are smaller than the partitions
                while (array[right] > partitionElement)
                {
                    right--;
                }

                // If not done, swap elements
                if (left < right)
                {
                    tmp = array[left];
                    array[left] = array[right];
                    array[right] = tmp;
                }
            }
            //Put partition element between the partitions
            tmp = array[min];
            array[min] = array[right];
            array[right] = tmp;
            return right;
        }
    }
}

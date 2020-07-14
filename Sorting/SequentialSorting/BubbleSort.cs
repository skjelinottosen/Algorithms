using System;
namespace SequentialSorting
{
    //Slow because of all the swaping O(n2)(not often used).
    public class BubbleSort
    {
        public BubbleSort()
        {
        }

        public void Sort(int[] array)
        {
            int length = array.Length;
            int tmp;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }
    }
}

using System;
namespace SequentialSorting
{

    //Faster than regular sequential sorting algorithms and has about 0(n^3/2) runtime.
    public class ShellSort
    {
        public ShellSort()
        {
        }

        public void Sort(int[] array)
        {
            int length = array.Length;
            int gap = length / 2;

            while (gap > 0)
            {
                for (int i = gap; i < length; i++)
                {
                    int j = i;
                    int tmp = array[i];

                    while (j >= gap && array[j - gap] > tmp)
                    {
                        array[j] = array[j - gap];
                        j = j - gap;
                    }
                    array[j] = tmp;
                }

                if (gap == 2)
                {
                    gap = 1;
                }
                else
                {
                    gap *= (int)(5.0 / 11);
                }
            }
        }
    }
}

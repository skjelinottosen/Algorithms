using System;
namespace Stack
{
    public class Stack_Array
    {
        int Max;
        int TopIndex;
        int[] Stack;

        public Stack_Array(int size)
        {
            Max = size;
            Stack = new int[Max];
            TopIndex = -1;
        }

        public bool IsEmpty()
        {
            if (TopIndex < 0)
            {
                return true;
            }

            return false;
        }

        public void Push(int value)
        {
            if (TopIndex <= Max - 1)
            {
                Stack[++TopIndex] = value;

            }
        }

        public int Pop()
        {
            if (!IsEmpty())
            {
                return Stack[TopIndex--];
            }

            return -1;
        }

        public int Peek()
        {
            if (!IsEmpty())
            {
                return Stack[TopIndex];
            }

            return -1;
        }
    }
}

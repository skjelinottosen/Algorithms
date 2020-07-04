using System;
namespace Stack
{
    public class Stack_LinkedList
    {
        Node Front;

        public bool IsEmpty()
        {
            if (Front == null)
            {
                return true;
            }

            return false;
        }

        public void Push(int value)
        {
            if (IsEmpty())
            {
                Front = new Node(value);
            }

            Node tmp = Front;
            Front = new Node(value);
            Front.Next = tmp;
        }

        public int Pop()
        {
            if (!IsEmpty())
            {
                int value = Front.Data;
                Front = Front.Next;
                return value;
            }

            return -1;
        }

        public int Peek()
        {
            if (!IsEmpty())
            {
                return Front.Data;
            }

            return -1;
        }
    }
}

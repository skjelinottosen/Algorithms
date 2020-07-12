using System;
namespace Graph_Unweighted
{
    public class LinkedQueue
    {
        Node Front, Rear;
        int Count;

        public LinkedQueue()
        {
            Front = null;
            Rear = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            if (Front == null)
            {
                return true;
            }
            return false;
        }

        public int Size()
        {
            return Count;
        }

        public void Equeue(int value)
        {
            Node node = new Node(value);

            if (IsEmpty())
            {
                Front = node;
                Rear = node;
                Count++;
            }

            else
            {
                //Adds the new node at the end of queue and change Rear to point to the node
                Rear.Next = node;
                Rear = node;
                Count++;
            }
        }

        public int Dequeue()
        {
            if (!IsEmpty())
            {
                //Store previous front and move front one node ahead
                Node node = Front;
                Front = Front.Next;

                //Checks if Front becomes null after updating the pointer
                if (IsEmpty())
                {
                    Rear = null;
                }

                Count++;
                return node.Data;
            }

            return -1;
        }
    }
}

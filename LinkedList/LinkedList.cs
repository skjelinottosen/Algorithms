using System;
namespace LinkedList
{
    public class LinkedList
    {
        public Node Front { get; set; }
        public int NumNodes { get; set; }

        public LinkedList()
        {
            Front = null;
            NumNodes = 0;
        }

        public bool IsEmpty()
        {
            return NumNodes == 0;
        }

        public void AddFront(string s)
        {
            if (IsEmpty())
            {
                Front = new Node(s);
                NumNodes++;
            }
        }


        public void AddRear(string s)
        {
            if (IsEmpty())
            {
                Front = new Node(s);
            }

            Node current = Front;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node(s);
            NumNodes++;
        }

        public bool AddAfter(string s, string t)
        {

            Node node = new Node(s);
            Node current = Front;

            while (current != null)
            {
                if (current.Data.CompareTo(t) == 0)
                {
                    node.Next = current.Next;
                    current.Next = node;

                    NumNodes++;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public string FrontValue()
        {
            if (!IsEmpty())
            {
                return Front.Data;
            }

            return null;
        }

        public string RearValue()
        {
            if (NumNodes == 1)
            {
                FrontValue();
            }

            else if (!IsEmpty())
            {
                Node current = Front;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                return current.Next.Data;
            }

            return null;
        }

        public void RemoveFront()
        {
            if (!IsEmpty())
            {
                Front = Front.Next;
                NumNodes--;

            }
        }

        public void RemoveRear()
        {
            if (NumNodes == 1)
            {
                RemoveFront();
            }
            else if (!IsEmpty())
            {
                Node previous = Front;
                Node current = Front.Next;

                while (current.Next != null)
                {
                    previous = current;
                    current = current.Next;
                }

                previous.Next = null;
                NumNodes--;
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }

        public bool Remove(string t)
        {
            if (IsEmpty())
            {
                return false;
            }

            if (Front.Data.CompareTo(t) == 0)
            {
                Front = Front.Next;
                NumNodes++;
                return true;
            }

            Node previous = Front;
            Node current = Front.Next;

            while (current.Next != null)
            {
                if (Front.Data.CompareTo(t) == 0)
                {
                    previous.Next = current.Next;
                    NumNodes++;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void RemoveDuplicates()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
            }

            Node current = Front;

            while (current.Next != null)
            {
                Node currentCheck = current;

                while (currentCheck.Next != null)
                {
                    if (current.Data.CompareTo(currentCheck.Next.Data) == 0)
                    {
                        currentCheck.Next = currentCheck.Next.Next;
                    }
                    currentCheck = currentCheck.Next;
                }

                current = current.Next;
            }
        }

        public void Print()
        {
            Node current = Front;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}


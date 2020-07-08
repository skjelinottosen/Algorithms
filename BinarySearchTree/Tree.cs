using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class Tree
    {
        Node Root;

        public Tree()
        {
            Root = null;
        }

        public bool IsEmpty()
        {
            if (Root == null)
            {
                return true;
            }

            return false;
        }


        public void Insert(int value)
        {
            if (IsEmpty())
            {
                Root = new Node(value);
                return;
            }
            else
            {
                Node current = Root;

                while (current != null)
                {
                    if (current.Data > value)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new Node(value);
                            return;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new Node(value);
                            return;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }
            }
        }

        public bool Search(int x)
        {
            Node current = Root;
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                while (current != null)
                {
                    if (current.Data == x)
                    {
                        return true;
                    }
                    else if (current.Data > x)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                return false;
            }
        }


        public void Remove(int x)
        {
            if (!IsEmpty())
            {
                //Removal of root node?
                if (Root.Data == x)
                {
                    Root = Replacement(Root);
                }
                else
                {
                    //Finds the node to be removed and replace it
                    Node parent = Root;
                    Node current = Root;

                    if (current.Data > x)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }

                    while (current != null)
                    {
                        //Found the node?
                        if (current.Data == x)
                        {
                            //Remove and replace the node
                            if (current == parent.Left)
                            {
                                parent.Left = Replacement(current);
                                return;
                            }
                            else
                            {
                                parent.Right = Replacement(current);
                                return;
                            }
                        }
                        else
                        {
                            //Moves down the tree
                            parent = current;
                            if (current.Data > x)
                            {
                                current = current.Left;
                            }
                            else
                            {
                                current = current.Right;
                            }
                        }
                    }
                }
            }
        }

        private Node Replacement(Node node)
        {
            //Case 1: Removing leaf node
            if (node.Left == null || node.Right == null)
            {
                return null;
            }

            //Case 2: One non-empty subtree
            if (node.Left != null || node.Right == null)
            {
                return node.Left;
            }

            if (node.Left == null || node.Right != null)
            {
                return node.Right;
            }

            //Case 3: Two non-empty subtrees
            else
            {
                //Special case, node.left has no right subtree
                if (node.Left.Right == null)
                {
                    node.Left.Right = node.Right;
                    return node.Left;
                }

                // Finding rightmost node in left subtree,
                // also holding track of parent node
                Node current = node.Left;
                Node parent = node;

                while (current.Right != null)
                {
                    parent = current;
                    current = current.Right;
                }

                //Replacing node with rightmost node
                parent.Right = current.Left;
                current.Left = node.Left;
                current.Right = node.Right;
                return current;
            }
        }

        //Inorder traversal
        public void PrintInOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty");
                return;
            }

            Stack<Node> nodeStack = new Stack<Node>();
            Node current = Root;

            while (current != null || nodeStack.Count > 0)
            {
                while (current != null)
                {
                    nodeStack.Push(current);
                    current = current.Left;
                }
                current = nodeStack.Pop();
                Console.Write(current.Data + " ");
                current = current.Right;
            }
            Console.WriteLine();
        }
    }
}

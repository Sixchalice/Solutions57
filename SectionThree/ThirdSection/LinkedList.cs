using System;
namespace MyApp
{
    class LinkedList
    {
        private Node head;
        private Node last;
        private Node maxNode;
        private Node minNode;

        public LinkedList(int value)
        {
            head = new Node(value);
            last = head;
            maxNode = head;
            minNode = head;
        }

        // Function is called after every new Node added in order to update min / max Node
        private void UpdateMinMax(Node node)
        {
            if (node.GetValue() > maxNode.GetValue())
            {
                maxNode = node;
            }
            else if (node.GetValue() < minNode.GetValue())
            {
                minNode = node;
            }
        }

        public void Append(int value)
        {
            Node node = new Node(value);
            last.SetNext(node);
            last = node;
            UpdateMinMax(node);
        }
        public void Prepend(int value)
        {
            Node node = new Node(value, head);
            head = node;
            UpdateMinMax(node);
        }

        // Helper function for making sure to have a max value after removing the current one
        private Node SecondMaxNode()
        {
            Node node = new Node(int.MinValue);
            Node p = head;
            while (p != null)
            {
                if (p.GetValue() < maxNode.GetValue() && p.GetValue() > node.GetValue())
                {
                    node = p;
                }
                p = p.GetNext();
            }
            return node;
        }

        // Helper function for making sure to have a min value after removing the current one
        private Node SecondMinNode()
        {
            Node node = new Node(int.MaxValue);
            Node p = head;
            while (p != null)
            {
                if (p.GetValue() > minNode.GetValue() && p.GetValue() < node.GetValue())
                {
                    node = p;
                }
                p = p.GetNext();
            }
            return node;
        }

        public int Pop()
        {
            int val = last.GetValue();
            Node p = head;

            // Checking if maxNode or minNode needs to be updated
            if (last == maxNode)
            {
                maxNode = SecondMaxNode();
            }
            else if (last == minNode)
            {
                minNode = SecondMinNode();
            }
            while (p.GetNext() != last)
            {
                p = p.GetNext();
            }
            p.SetNext(null!);
            last = p;
            return val;
        }

        public int Unqueue()
        {
            // Checking if maxNode or minNode needs to be updated
            if (head == maxNode)
            {
                maxNode = SecondMaxNode();
            }
            else if (head == minNode)
            {
                minNode = SecondMinNode();
            }

            int val = head.GetValue();
            if (head.GetNext() != null)
            {
                head = head.GetNext();
            }
            return val;
        }

        public IEnumerable<int> ToList()
        {
            Node p = head;
            while (p != null)
            {
                yield return p.GetValue();
                p = p.GetNext();
            }
        }

        public bool IsCircular()
        {
            Node p1 = head;
            while (p1.GetNext() != null)
            {
                p1 = p1.GetNext();
                if (p1 == head)
                {
                    return true;
                }
            }
            return false;
        }

        public void Sort()
        {
            Node p1 = head;
            while (p1 != null)
            {
                Node p2 = head;
                while (p2 != null)
                {
                    if (p1.GetValue() < p2.GetValue())
                    {
                        int temp = p1.GetValue();
                        p1.SetValue(p2.GetValue());
                        p2.SetValue(temp);
                    }
                    p2 = p2.GetNext();
                }
                p1 = p1.GetNext();
            }
            //Set minNode and maxNode
            minNode = head;
            maxNode = head;
            while (maxNode.GetNext() != null)
            {
                maxNode = maxNode.GetNext();
            }
        }

        public Node GetMaxNode()
        {
            return maxNode;
        }
        public Node GetMinNode()
        {
            return minNode;
        }
    }
}

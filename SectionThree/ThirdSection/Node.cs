using System;
namespace MyApp
{
    class Node
    {
        private int value;
        private Node? next;

        public Node(int value, Node next)
        {
            this.value = value;
            this.next = next;
        }
        public Node(int value)
        {
            this.value = value;
        }
        public Node() { }

        public int GetValue()
        {
            return value;
        }
        public Node GetNext()
        {
            return next!;
        }
        public void SetNext(Node next)
        {
            this.next = next;
        }
        public void SetValue(int val)
        {
            this.value = val;
        }
    }
}


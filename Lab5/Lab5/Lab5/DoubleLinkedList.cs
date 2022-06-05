using System;

namespace Lab5
{
    public class DoubleLinkedList
    {
        public Node Head, Tail;
        public int Count { get; private set; }

        public DoubleLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void PushBack(int value)
        {
            Node node = new Node(value);
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Count++;
        }

        public void PushFront(int value)
        {
            Node node = new Node(value);
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Head.Previous = node;
                node.Next = Head;
                Head = node;
            }
            Count++;
        }

        public int PopBack()
        {
            if (Count != 0)
            {
                int value = Tail.Value;
                Tail.Previous.Next = null;
                Tail = Tail.Previous;
                Count--;
                return value;
            }
            throw new Exception("List is empty");
        }
        
        public int PopFront()
        {
            if (Count != 0)
            {
                int value = Head.Value;
                Head.Next.Previous = null;
                Head = Head.Next;
                Count--;
                return value;
            }
            throw new Exception("List is empty");
        }

        public void SwapValues(Node node1, Node node2)
        {
            (node1.Value, node2.Value) = (node2.Value, node1.Value);
        }

        public void SwapNodes(Node node1, Node node2)
        {
            Node first = node1.Next == node2 ? node1 : node2;
            Node second = node1.Next == node2 ? node2 : node1;
            if (Head == first) Head = second;
            if (Tail == second) Tail = first;
            if (first.Previous is not null) first.Previous.Next = second;
            if (second.Next is not null) second.Next.Previous = first;
            second.Previous = first.Previous;
            first.Previous = second;
            first.Next = second.Next;
            second.Next = first;
        }

        public override string ToString()
        {
            string result = "";
            if (Count > 0) result += Head.Value;
            
            for (Node current = Head.Next; current is not null; current = current.Next)
            {
                result += $", {current.Value}";
            }

            return result;
        }
        
        public void BubbleSort(Node first, Node last)
        {
            if (first == last) return;
            int swapCounter = 0;
            for (Node current = first; current != last; current = current.Next)
            {
                if (current.Value > current.Next.Value)
                {
                   SwapValues(current, current.Next); 
                    /*if (current == first) first = current.Next;
                    if (current.Next == last) last = current;
                    SwapNodes(current, current.Next);
                    current = current.Previous;*/
                    
                    swapCounter++;
                }
            }
            if (swapCounter>0) BubbleSort(first, last.Previous);
        }
    }
}
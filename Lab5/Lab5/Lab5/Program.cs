using System;
using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList list = new DoubleLinkedList();
            Random rand = new Random();
            for (int i = 100; i >0; i--)
            {
                list.PushBack(i);
            }

            Console.WriteLine("Initial array:");
            Console.WriteLine(list);
            Console.WriteLine();
            Console.WriteLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            list.BubbleSort(list.Head, list.Tail);
            sw.Stop();
            Console.WriteLine("Sorted values");
            Console.WriteLine("time in milliseconds: " +  (double) sw.ElapsedMilliseconds);

            Console.WriteLine(list);
        }
    }
}
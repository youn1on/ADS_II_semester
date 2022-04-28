using System;
using ArrayOperations;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            int length;
            
            BubbleSort bubbleSort = new BubbleSort();
            CombSort combSort = new CombSort();
            ArrayGenerator arrGen = new ArrayGenerator();

            length = GetLength();
            array = arrGen.GetArray(length);
            
            Console.WriteLine("\nInitial array is: ");
            bubbleSort.DisplayArray(array);
            Console.WriteLine("Execution time in ms "  + bubbleSort.GetSortingTime(array));
            Console.WriteLine("\nSorted array is " );
            bubbleSort.DisplayArray(array);
            bubbleSort.DisplayCharacteristics();
            
            length = GetLength();
            array = arrGen.GetArray(length);
            Console.WriteLine("\nInitial array is: ");
            combSort.DisplayArray(array);
            Console.WriteLine("Execution time in ms " + combSort.GetSortingTime(array));
            Console.WriteLine("\nSorted array is " );
            combSort.DisplayArray(array);
            combSort.DisplayCharacteristics();
        }
        public static int GetLength()
        {
            int length = 0;
            Console.WriteLine("Enter the length of array to generate: ");
            length = Convert.ToInt32(Console.ReadLine());
            return length;
        }
    }
    
    
}
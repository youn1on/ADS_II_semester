using System;
using System.Diagnostics;

namespace ArrayOperations
{
    public class ArrayGenerator
    {
        public int[] GetArray(int length, bool? sorted = null)
        {
            int[] array = new int[length];
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                if (sorted is null)
                    array[i] = rand.Next(-5000, 10001);
                else if (sorted is true)
                {
                    array[i] = i;
                } 
                else
                {
                    array[i] = length - i;
                }
            }

            return array;
        }
    }
    public class BubbleSort
    {
        private int _comparisonAmount;
        private int _swapAmount;
        
        protected void Swap(int[] array, int step, int upperBound)
        {
            for (int j = 0; j < array.Length - upperBound; j++)
            {
                _comparisonAmount++;
                if (array[j + step] < array[j])
                {
                    (array[j], array[j + step]) = (array[j + step], array[j]);
                    _swapAmount++;
                }
            }
        }

        public void DisplayCharacteristics()
        {
            Console.WriteLine("The amount of comparisons: " + _comparisonAmount);
            Console.WriteLine("The amount of swaps: " + _swapAmount);
        }
        
        public void DisplayArray(int[] array)
        {
            Console.WriteLine($"\n{this.GetType().Name}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0,7}", array[i]);
            }
            Console.WriteLine();
        }

        public double GetSortingTime(int[] array)
        {
            Stopwatch sw = Stopwatch.StartNew();
            DoSort(array);
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }
        
        protected virtual void DoSort(int[] array)
        {
            for (int i = 1; i <= array.Length - 1; i++)
            {
                Swap(array, 1, i);
            }
        }
    }

    public class CombSort : BubbleSort
    {
        private int GetUpdatedGap(int gap)
        {
            gap = (int)(gap / 1.2473);
            if (gap < 1) gap = 1;
            return gap;
        }

        protected override void DoSort(int[] array)
        {
            int gap = array.Length;
            while (gap != 1)
            {
                gap = GetUpdatedGap(gap);
                Swap(array, gap, gap);
            }
        }
    }
}
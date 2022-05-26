using System;
using System.Diagnostics;

namespace Randomized_Quick_Sort1
{
    class Randomized_Quick_Sort1
    {
        public static void RandomizedQuickSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int q = RandomizedPartition(input, left, right);
                RandomizedQuickSort(input, left, q - 1);
                RandomizedQuickSort(input, q + 1, right);
            }
        }
        private static int RandomizedPartition(int[] input, int left, int right)
        {
            Random random = new Random();
            int i = (left + random.Next()) % (right - left + 1);

            int pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return Partition(input, left, right);
        }
        private static int Partition(int[] input, int left, int right)
        {
            int pivot = input[right];
            int temp;

            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    temp = input[j];
                    input[j] = input[i];
                    input[i] = temp;
                }
            }

            input[right] = input[i + 1];
            input[i + 1] = pivot;

            return i;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch stopWatch;
            int[] array;
            int size = 10;
            for (int j = 1; j < 7; ++j)
            {
                stopWatch = Stopwatch.StartNew();
                array = new int[size];
                for (int i = 0; i < 10; ++i) array[i] = random.Next(0, 300);
                stopWatch.Start();
                RandomizedQuickSort(array, 0, size - 1);
                stopWatch.Stop();
                Console.WriteLine("Number of millisec to sort " + size + " elements: " + stopWatch.ElapsedMilliseconds);
                size = size * 10;
            }
        }
    }
}


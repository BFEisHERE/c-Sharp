using System;

namespace Quick_Sort4
{
    class QuickSort4
    {
        private static int partition(int[] input, int left, int right)
        {
            int pivot = input[left];
            while (true)
            {
                while (input[left] < pivot)
                {
                    left++;
                } while (input[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int tut = input[right];
                    input[right] = input[left];
                    input[left] = tut;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(int [] input,int left, int right)
        {
            int pivot;
            if (left<right)
            {
                pivot = partition(input, left, right);
                if (pivot > 1)
                {
                    quickSort(input, left, pivot - 1);
                }
                if (pivot<1)
                {
                    quickSort(input, pivot + 1, right);
                }
            }
            
        }
        
        static void Main(string[] args)
        {
            int[] dizi = { 23, 398, 34, 19, 57, 67, 55, 320,11 };
            quickSort(dizi, 0, dizi.Length-1);
            for (int i = 0; i  < dizi.Length; i ++)
            {
                Console.Write(" "+ dizi[i]);
            }
        }
    }
}

using System;

namespace Heap_Sort1
{
    class Heap_Sort1
    {/* Yığın Sıralama, yığın veri yapısını kullanan bir sıralama algoritmasıdır. 
      * Her seferinde yığının kök elemanı, yani en büyük eleman kaldırılır ve bir dizide saklanır. 
      * En sağdaki yaprak elemanı ile değiştirilir ve daha sonra yığın yeniden kurulur. 
      * Bu, yığında başka eleman kalmayana ve dizi sıralanana kadar yapılır.
      */
        static void headSort(int[] arr, int n){
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }

        }


        static void Main(string[] args)
        {
            int[] arr = { 55, 25, 89, 34, 12, 19, 78, 95, 1, 100 };
            int n = 10, i;
            Console.WriteLine("Heap Sort");
            Console.Write("Orjinal dizi:");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i]+ " ");
            }
            headSort(arr, 10);
            Console.Write("\nSıralı Dizi: ");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}

using System;

namespace Merge_Sort1
{
    class Merge_Sort1
    {
        void merge(int[] arr, int l, int m, int r)
        {
            // Birleştirilecek iki
            // alt dizinin boyutlarını bulun
            int n1 = m - l + 1;
            int n2 = r - m;

            // Geçici diziler oluşturun
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Verileri geçici dizilere kopyalayın
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Geçici dizileri birleştir

            // Birinci ve ikinci alt
            // dizilerin ilk dizinleri
            i = 0;
            j = 0;

            // Birleştirilmiş alt dizi
            // dizisinin başlangıç ​​dizini
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Varsa L[] öğesinin kalan öğelerini kopyalayın

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Varsa R[] öğesinin kalan öğelerini kopyalayın
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // ortadaki değeri bulur
                int m = l + (r - l) / 2;

                // birinci ve ikinci yarı diziyi sıralar
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Sıralanmış yarı dizileri birleştirir
                merge(arr, l, m, r);
            }
        }

        // Diziyi sıralamak için yardımcı fonksiyon
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7, 32, 31, 124, 13214, -32131 };
            Console.WriteLine("Given Array");
            printArray(arr);
            Merge_Sort1 ob = new Merge_Sort1();
            ob.sort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nSorted array");
            printArray(arr);
        }
    }
}

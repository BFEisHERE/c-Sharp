using System;
/*
 * Dayanak Seçilir (pivot)
 * Pivottan Büyük Olanlar sağa ve küçük olanlar sola koyulur.
 * 
 */
namespace Quick_Sort3
{
    class Program
    {

        public static int partition(int[] dizi,int left,int right)
        {
            int pivot;
            pivot = dizi[left];
            while (true)
            {
                /* dizinin pivottan küçük olan elemanını bulana kadar
                 * while dongusu calısmaya devam eder*/
                while (dizi[left]<pivot)
                {
                    left++;
                }/*dizinin pivotundan büyük olan elemanını bulana kadar while calısır
                  ve en indis değerini düşürür*/ 
                while (dizi[right]>pivot)
                {
                    right--;
                }
                if (left<right)
                {
                    if (dizi[left] == dizi[right]) return right;

                    int tut = dizi[left];
                    dizi[left] = dizi[right];
                    dizi[right] = tut;
                }
                else
                {
                    return right;
                }
            }
        }
        public static void quicksort(int[] dizi,int left,int right)
        {
            if (left<right)
            {
                int pivot = partition(dizi, left, right);
                if (pivot > 1)
                    quicksort(dizi, left, pivot - 1);
                if (pivot + 1 < right)
                    quicksort(dizi, pivot + 1, right);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            Console.WriteLine("Dizinin İlk Hali:");
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.Write("******");
            }
            
            quicksort(arr, 0, arr.Length - 1);
            Console.WriteLine();
            Console.Write("Sıralanmış Hali:");
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

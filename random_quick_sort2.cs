using System;

namespace random_quick_sort2
{
    class random_quick_sort2
    {
        public static void randomquick(int[] dizi, int left, int right)
        {
            if (left<right)
            {
                int q = randompartition(dizi, left, right);
                randomquick(dizi, left, q - 1);
                randomquick(dizi, q + 1, right);
            }
        }
        public static int randompartition(int[] dizi, int left, int right)
        {
            Random random = new Random();
            int i = random.Next(left, right);

            int pivot = dizi[i];
            dizi[i] = dizi[right];
            dizi[right] = pivot;

            return partition(dizi, left, right);
        }

        private static int partition(int[] dizi, int left, int right)
        {
            int pivot = dizi[right];
            int tut;
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (dizi[j]<=pivot)
                {
                    tut = dizi[j];
                    dizi[j] = dizi[i];
                    dizi[i] = tut;
                    i++;
                }
            }
            dizi[right] = dizi[i];
            dizi[i] = pivot;
            return i;
        }
        

        static void Main(string[] args)
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;

            randomquick(arr, 0, n - 1);

            Console.WriteLine("Sıralama; ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(" "+arr[i]);
            }
            Console.ReadKey();
        }
    }
}

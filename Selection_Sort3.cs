using System;

namespace Selection_Sort3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dizi =new int[8] {25,57,48,37,12,92,86,33};
            int n = 8;
            Console.WriteLine("Selection Sort İşlemi!");
            Console.Write("Ana Dizi");
            for (int i = 0; i < n; i++)
            {
                Console.Write(dizi[i] +" ");
            }
            int tut, enkucuk;
            for (int i = 0; i < n-1; i++)
            {
                enkucuk = i;

                for (int j = i + 1; j < n; j++)//i+1 unutulmamalı!!
                {
                    if (dizi[j] < dizi[enkucuk])
                    {
                        enkucuk = j;
                    }
                }
                tut = dizi[enkucuk];
                dizi[enkucuk] = dizi[i];
                dizi[i] = tut;
            }
            Console.WriteLine();
            Console.Write("Sıralanmış Hali: ");
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(dizi[i]+" ");
            }
            Console.ReadKey();
        }
    }
}

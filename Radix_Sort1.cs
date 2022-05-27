﻿using System;

namespace Radix_Sort1
{
    class Radix_Sort1
    {
        /*Radix sıralama, anahtarları aynı önemli konumu 
         * ve değeri paylaşan bireysel basamaklara göre gruplayarak 
         * tamsayı anahtarlarıyla verileri sıralayan, karşılaştırmalı 
         * olmayan bir tamsayı sıralama algoritmasıdır
         */

        static void Sort (int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift =  31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; i++)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            Console.WriteLine("\n Orijinal Dizi:");
            foreach (var item in arr){
                Console.Write(" "+item);
            }
            Console.WriteLine("\n\n");
            Sort(arr);
            Console.WriteLine("Sıralı Dizi");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine("\n\n");
            Console.ReadKey();
        }
    }
}

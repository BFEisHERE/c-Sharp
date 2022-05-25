using System;

namespace Selection_Sort2
{
    class Program
    {
        static void Main(string[] args)
        {
            // dizi tanımlama ve adedini belirleme
            int[] dizi = new int[5] { 9, 5, 8, 3, 1 };
            int n = 5;
            //ilk diziyi yazdıralım
            Console.WriteLine("Selection Sort");
            Console.Write("İlk Dizi: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            //karşılaştırıp sıralama
            int tut, enkucuk;
            for (int i = 0; i < n-1; i++)
            {
                enkucuk = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (dizi[j] < dizi[i])
                    {
                        enkucuk = j;
                    }
                }
                /* j indisindeki değer i indisindekinden küçüktür
                 Bu yüzden tut değerine dizinin en küçük değeri olan j indisindeki değer tutturuldu
                normal indisteki değerle eşitlendi 
                ve i indisindeki küçük değer yazıldı
                 */ 
                
                tut = dizi[enkucuk];
                dizi[enkucuk] = dizi[i];
                dizi[i] = tut;
            }
            Console.WriteLine();
            Console.Write("Sıralı Liste:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(dizi[i]+" ");
            }
            Console.ReadKey();
        }
    }
}

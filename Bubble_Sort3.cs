using System;

namespace Bubble_Sort3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dizi = { 9, 5, 8, 3, 1 };
            int tut;
            for (int j = 0; j <= dizi.Length-2; j++)
            {
                for (int i = 0; i <= dizi.Length-2; i++)
                {
                    if (dizi[i] > dizi[i+1])
                    {
                        //Küçükse tutuyoruz
                        tut = dizi[i + 1];
                        //üst indisle büyük alt indisi yer değiştiriyorz
                        dizi[i + 1] = dizi[i];
                        //üst indisteki küçük değeri alt indise yerleştiriyoruz
                        dizi[i] = tut;
                    }
                }
            }
            Console.Write("Listenin Sıralaması: ");
            foreach(int a in dizi)
                Console.Write(a + " ");
            Console.ReadKey();
        }
    }
}

using System;

namespace Bubble_Sort2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sıralanacak dizi oluşturuyoruz
            int[] diz = {25,57,48,37,12,92,86,33};
            int tut;
            //Dizi indislerini gezilecek
            for (int j = 0; j <= diz.Length-2; j++)
            {
                for (int i = 0; i <= diz.Length-2; i++)
                {
                    if (diz[i] > diz[i+1]) 
                    {
                        tut = diz[i+1];
                        diz[i+1] = diz[i];
                        diz[i] = tut;
                    }
                }
            }
            Console.Write("Sıralama: ");
            foreach (int a in diz)
            {
                Console.Write(a + " ");
            }
            Console.Read();
        }
    }
}

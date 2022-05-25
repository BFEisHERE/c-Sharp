using System;

namespace Selection_Sort1
{
    class Program
    {
        static void Main(string[] args)
        {
            //dizi tanımlama
            int[] dizi = new int[10] { 56, 1, 99, 67, 89, 23, 44, 12, 78, 34 };
            int n = 10; // dizi boyutu
            Console.WriteLine("Selection Sort");
            Console.Write("İlk Dizi:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(dizi[i]+" ");
            }
            int tut, enkucuk;
            for (int i = 0; i < n-1; i++)
            {
                //sözde en küçük değer bulundu karşılaştırma için
                enkucuk = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (dizi[j] < dizi[enkucuk])
                    {
                        //en küçüğü bulmak için for döngüsünde döndürüldü
                        enkucuk = j; 
                    }
                }
                //yer değiştirme yaptık
                tut = dizi[enkucuk];
                dizi[enkucuk] = dizi[i];
                dizi[i] = tut;
            }
            Console.WriteLine();
            Console.Write("Sıralanmış Hali: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(dizi[i] + " ");
            }
            Console.ReadKey();
        }
    }
}

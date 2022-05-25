using System;

namespace Quick_Sort1
{
    class Program
    {
        //diziyi bölüyoruz
        static public int Bölme(int[] arr,int left,int right)
        {
            //pivot değeri belirlendi
            int pivot;
            pivot = arr[left];//pivot olarak rastgele sayı belirlendi
            while (true)
            {
                while(arr[left] < pivot) // pivot değeri indise göre karşılatırma
                {
                    left++;
                }
                while (arr[right] > pivot) 
                {
                    right--;
                }
                if (left < right) // indislerin karşılaştırılması ve sıralandı
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else 
                { 
                    return right;
                }
            }
        }

        static public void quickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left<right)
            {
                pivot = Bölme(arr, left, right);
                if (pivot >1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot+1<right)
                {
                    quickSort(arr,  pivot + 1,right);
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 };
            int n = 10,i; //for döngüsü içindeki i tanımı kaldırıldı
            Console.WriteLine("Quick Sort");
            Console.Write("Initial array is: ");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            quickSort(arr, 0, 9);
            Console.Write("\nSorted Array is: ");
            for (i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}

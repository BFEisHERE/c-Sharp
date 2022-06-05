using System;
/*
 * İlk giren son çıkar 
 * son giren ilk çıkar  
 *  1 -> 2 -> 3 -> 4 -> 5
 *  ilk 1 en son 5 çıkar
 */
namespace Stack_Yığın_Yapısı
{
    class Stack_Yığın_Yapısı
    {
        static void Main(string[] args)
        {

            stackYapısı stc = new stackYapısı();

            stc.pop(); // Veri Silinmeye çalışışır. Çıktı = Liste Boştur

            stc.push(10); // ilk girilen değer 10 oldu. Top = 10
            stc.push(20); // 2. değer girildi. Top = 20
            stc.push(30); // 3. değer girildi. Top değişti ve 30 oldu

            stc.print(); // 30 -> 20 -> 10 şeklinde yazılır

            stc.pop(); // top listeden çıkarılır. Yani 30 değeri
            stc.pop(); // 20 değeri atıldı
            stc.pop(); // 10 değeri atıldı ve liste boş

            stc.print();
            
        }



        class Node
        {
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }
        class stackYapısı
        {
            Node top; // en üstteki eleman 
            public stackYapısı()
            {
                top = null;
            }

            public void push(int data) // ekleme işlemi
            {
                Node eleman = new Node(data);
                
                if (top == null) // Stack Boş mu ?
                {
                    top = eleman;
                    Console.WriteLine("Stack Yapısı oluşturuldu, ilk eleman girdi");
                }
                else
                {
                    eleman.next = top;
                    top = eleman;
                    Console.WriteLine("Eleman eklendi");
                }
            }

            public int pop() // Eleman çıkarma 
            {
                if (top == null)
                {
                    Console.WriteLine("stack boş!");
                    return -1;
                }
                else
                {
                    int sayı = top.data;
                    top = top.next;
                    Console.WriteLine(sayı + " Stackten çıkartıldı");
                    return sayı;
                }
            }

            public void print()
            {
                if (top == null)
                {
                    Console.WriteLine("Stack Boştur");
                }
                else
                {
                    Node temp= top;
                    while (temp != null)
                    {
                        Console.WriteLine(temp.data);
                        temp = temp.next;
                    }
                }
            }


        }
    }
}

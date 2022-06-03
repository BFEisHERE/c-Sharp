using System;

namespace LinkedList2
{
    class LinkedList2
    {
        // BAŞA - SONA ELEMAN EKLEMELİ BAĞLANTILI LİSTE
        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }
        class liste
        {
            public Node head;

            public liste()
            {
                head = null;
            }

            public void sonaEkle(int data)
            {
                Node eleman = new Node(data);

                if (head == null) { 
                    head = eleman;
                    Console.WriteLine("İlk Eleman head'e eklendi");
                }

                else
                {
                    Node temo = head;
                    while (temo.next!=null)
                    {
                        temo = temo.next;
                    }
                    temo.next = eleman;
                    Console.WriteLine("Sona Eleman Eklendi");
                }
            }
            public void basaEkle(int data){

                Node eleman = new Node(data);
                if (head==null)
                {
                    head = eleman;
                    Console.WriteLine("Liste oluşturuldu. İlk eleman eklendi.");
                }
                else
                {
                    eleman.next = head; // Listenin başına eklendi ve önceki head'i gösteriyordu
                    head = eleman; // Head güncellendi ve head in ismi değişti
                    Console.WriteLine("Başa Düğüm eklendi");
                }
            }

            public void Yazdır()
            {
                Node temp = head;
                if (head ==null)
                {
                    Console.WriteLine("Liste Boştur.");

                }
                else
                {
                    while(temp.next != null)
                    {
                        Console.Write(temp.data + " --> ");
                        temp = temp.next;
                    }
                    Console.Write(temp.data + " son.");
                }
            }
            //Silme İşlemleri
            public void bastanSil()  
            {
                // Baştan silme işlemi ilk düğümün next'inin
                // gösteriminin değiştirilmesi demektir.
                if (head ==null)
                {
                    Console.WriteLine("liste boş");
                }
                else
                {
                    head = head.next; // Baştaki düğüm silindi
                    Console.WriteLine("Baştaki Düğüm Silindi");
                }
            }

            public void sonSil()
            {
                // Son eleman null değer gösteren elemandır.
                if (head == null)
                {
                    Console.WriteLine("liste boş");
                }
                else if (head.next == null)
                {
                    head = null;
                    Console.WriteLine("Listede kalan son düğüm de silindi.");
                }
                else
                {
                    // temp son elemanı tutarken 
                    // temp2 sondan bir önceki elemanı tutar. Böylece sondaki elemanla
                    // bağ kopartılarak silme işlemi yapılır
                    Node temp = head;
                    Node temp2 = temp;
                    while (temp.next != null)
                    {
                        temp2 = temp;
                        temp = temp.next;
                    }
                    temp2.next = null;
                    Console.WriteLine("Sondaki düğüm silindi.");
                }
            }
        }
        static void Main(string[] args){

            liste lst = new liste();
            /*lst.sonaEkle(11);
            lst.sonaEkle(12);
            lst.sonaEkle(13);
            Console.WriteLine("head düğümünün içindeki değer : "+ lst.head.data);
            Console.WriteLine("head.next.data düğümünün içindeki değer : "+ lst.head.next.data);
            Console.WriteLine("head.next.next.data düğümünün içindeki değer : "+ lst.head.next.next.data);
            Console.WriteLine("\n\n\n");
            lst.basaEkle(10);
            Console.WriteLine("head düğümünün içindeki değer : " + lst.head.data);
            lst.Yazdır();
            Console.WriteLine("\n\n\n");
            
            lst.bastanSil();
            lst.Yazdır();
            Console.WriteLine("\n\n\n");
            lst.sonSil();
            lst.sonSil();
            lst.sonSil();
            lst.Yazdır();*/

            int sayı;
            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1: Console.Write("Sayı : ");
                        sayı = int.Parse(Console.ReadLine());
                        lst.basaEkle(sayı);
                        break;
                    case 2: Console.Write("Sayı : ");
                        sayı = int.Parse(Console.ReadLine());
                        lst.sonaEkle(sayı); 
                        break;
                    case 3:
                        lst.bastanSil();
                        break;
                    case 4:
                        lst.sonSil();
                        break;
                    case 0:
                        break;
                }
            }

            lst.Yazdır();
            Console.WriteLine();
            //secim = menu();
        }

        public static int menu()
        {
            int secim;
            Console.WriteLine("1. başa ekleme");
            Console.WriteLine("2. sona ekleme");
            Console.WriteLine("3. baştan sil");
            Console.WriteLine("4. sondan sil");
            Console.WriteLine("0. programı kapat");
            Console.Write("Seçiminiz:");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
}
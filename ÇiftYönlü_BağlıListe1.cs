using System;
// Çift Yönlü Bağlı Listeler 
namespace ÇiftYönlü_BağlıListe1
{
    class ÇiftYönlü_BağlıListe1
    {
        static void Main(string[] args)
        {
            Liste list = new Liste();

            int sayı, indis;
            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.basaEkle(sayı); list.yazdır();
                        break;
                    case 2:
                        Console.WriteLine("Sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.sonaEkle(sayı); list.yazdır();
                        break;
                    case 3:
                        list.bastanSil(); list.yazdır();
                        break;
                    case 4:list.sondanSil(); list.yazdır();
                        break;
                    case 5:
                        list.tersYazdır();break;
                    case 6:
                        Console.WriteLine("İndis: "); indis = int.Parse(Console.ReadLine());
                        Console.WriteLine("Sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.arayaEkle(indis,sayı); list.yazdır();
                        break;
                    case 7:
                        Console.WriteLine("İndis: "); indis = int.Parse(Console.ReadLine());
                        list.aradanSil(indis); list.yazdır();
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız");
                        break;
                }

                secim = menu();
                Console.Clear();
            }


            Console.ReadKey();

        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1- Başa ekleme");
            Console.WriteLine("2- Sona ekleme");
            Console.WriteLine("3- Baştan Silme");
            Console.WriteLine("4- Sondan Silme");
            Console.WriteLine("5- Tersten Sırala");
            Console.WriteLine("6- Araya Ekle");
            Console.WriteLine("7- Aradan Sil");
            Console.WriteLine("0- Programı Kapat");
            Console.Write("Seçiminiz:"); secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }
    class Node
    {
        // diğerinden farklı olarak bir değil iki gösterici vardır
        // ilk düğüm head, son düğüm tail
        public int data;
        public Node next;
        public Node prev;
        
        public Node(int data)
        {
            this.data = data;
            next = null;
            prev = null;
        }
    }
    
    
    class Liste
    {
        public Node head;
        public Node tail;
        public Liste()
        {
            head = null;
            tail = null;
        }

        public void basaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                Console.WriteLine(  "Liste oluşturuldu ilk eleman eklendi");
            }
            else
            {
                eleman.next = head;
                head = eleman;
                head.prev = eleman;
                Console.WriteLine("Listenin başına eleman eklendi");
            }
        }
        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);
            if (head == null)
            {
                head = tail = eleman;
                Console.WriteLine("Liste oluşturuldu ilk eleman eklendi");
            }
            else
            {
                tail.next = eleman;
                eleman.prev = tail;

                tail = eleman;
                Console.WriteLine("Listenin sonuna eleman eklendi");
            }
        }
        public void yazdır()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boştur");
            }
            else
            {
                Node temp = head;

                while (temp.next != null)
                {
                    Console.Write(temp.data + "->");
                    temp = temp.next;
                }
                Console.WriteLine(temp.data + " son.");
            }
        }
        public void tersYazdır()
        {
            if (tail == null)
            {
                Console.WriteLine("Liste boştur");
            }
            else
            {
                Node temp = tail;
                
                while (temp.prev != null)
                {
                    Console.Write(temp.data + "->");
                    temp = temp.prev;
                }
                Console.WriteLine(temp.data + " son.");
            }
        }

        // Silme İşlemleri

        public void bastanSil()
        {
            if(head == null)
                Console.WriteLine("Liste Boştur");
            else if (head.next == null )
            {
                head = tail = null;
                Console.WriteLine("Listede kalan son düğüm silindi");
            }
            else
            {
                head = head.next;
                head.prev = null;
                Console.WriteLine("Baştan eleman silindi");
            }
        }
        public void sondanSil()
        {
            if (head == null)
                Console.WriteLine("Liste Boştur");
            else if (head.next == null)
            {
                head = tail = null;
                Console.WriteLine("Listede kalan son düğüm silindi");
            }
            else
            {
                tail = tail.prev;
                
                tail.next = null;
                Console.WriteLine("Sondan eleman silindi");
            }
        }

        // Araya Ekle-Sil
        public void arayaEkle(int indis,int data)
        {

            bool sonuc = false;
            Node eleman = new Node(data);

            if (head == null && indis ==0)
            {
                sonuc = true;
                head = tail = eleman;
                Console.WriteLine("Liste oluşturuldu ilk eleman eklendi");
            }
            else if (head != null && indis == 0)
            {
                sonuc = true;
                basaEkle(data);
            }
            else
            {
                
                int i = 0;
                Node temp = head;
                Node temp2 = head;
                while (temp.next != null)
                {
                    if(i == indis)
                    {
                        sonuc = true;
                        temp2.next = eleman;
                        eleman.prev = temp2;

                        eleman.next = temp;
                        temp.prev = eleman;
                        Console.WriteLine("Araya Eklendi");
                        i++;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next; i++;
                }
                if (i == indis)
                {
                    sonuc = true;
                    temp2.next = eleman;
                    eleman.prev = temp2;

                    eleman.next = tail;
                    tail.prev = eleman;

                    Console.WriteLine("Araya Eklendi");
                }
            }
            if(sonuc == false)
                Console.WriteLine("Hatalı indis girdiniz!");
        }

        public void aradanSil(int indis)
        {
            if (head == null)
                Console.WriteLine("Liste Boştur");
            else if (head.next == null && indis ==0)
            {
                head = tail = null;
                Console.WriteLine("Listede kalan son düğüm silindi");
            }
            else if (head.next != null && indis == 0)
            {
                bastanSil();
            }
            else
            {
                Node temp = head;
                Node temp2 =temp;
                int i = 0;
                while (temp.next != null)
                {
                    if (i == indis)
                    {
                        temp2.next = temp.next;
                        temp.next.prev = temp2;
                        Console.WriteLine("Aradan Düğüm Silindi");
                        i++;
                        break;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    sondanSil();
                }
            }
        }



    }
}

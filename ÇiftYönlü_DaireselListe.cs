using System;
/*
 * Listede ileri geri bir gösterin vardır 
 * tail.next = head & head.prev = tail
 */
namespace ÇiftYönlü_DaireselListe
{
    class ÇiftYönlü_DaireselListe
    {
        static void Main(string[] args)
        {
            Liste list = new Liste();
            int secim = menu();
            int sayı,indis;

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1: Console.Write("sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.basaEkle(sayı); list.Yazdır(); break;
                    case 2: Console.Write("sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.sonaEkle(sayı); list.Yazdır(); break;
                    case 3:
                        Console.Write("İndis: "); indis = int.Parse(Console.ReadLine());
                        Console.Write("sayı: "); sayı = int.Parse(Console.ReadLine());
                        list.arayaEkle(indis,sayı); list.Yazdır(); break;
                    case 4:
                        list.bastanSil(); list.Yazdır(); break;
                    case 5:
                        list.bsondanSil(); list.Yazdır(); break;
                    case 6:
                        Console.Write("İndis: "); indis = int.Parse(Console.ReadLine());
                        list.aradanSil(indis); list.Yazdır(); break;
                    case 7:list.tersYazdır();break;
                    case 0: break;
                    default:
                        Console.WriteLine("Hatalı Seçim!!");
                        break;
                }
                
                secim = menu(); 

            }
            Console.Clear();
            Console.WriteLine("Program Kapatıldı");
            Console.ReadLine();


        }

        private static int menu()
        {
            Console.WriteLine("\n\n1- Başa Ekle");
            Console.WriteLine("2- Sona Ekle");
            Console.WriteLine("3- Araya Ekle");
            Console.WriteLine("4- Baştna Sil");
            Console.WriteLine("5- Sondan Sil");
            Console.WriteLine("6- Aradan Sil");
            Console.WriteLine("7- Tersten Yazdır");
            Console.WriteLine("0- Kapat");
            Console.Write("Seçiminiz: ");
            int secim = int.Parse(Console.ReadLine());
            return secim;
        }

        class Node
        {
            public int data;
            public Node next;
            public Node prev;
            
            public Node(int data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }
        }

        class Liste
        {
            Node head;
            Node tail;

            public Liste()
            {
                this.head = null;
                this.tail = null;
            }

            // EKLEME İŞLEMLERİ 

            public void basaEkle(int data)
            {
                Node eleman = new Node(data);
                
                if (head == null)
                {
                    /*
                     * eleman.next = eleman;
                     * eleman.prev = eleman;
                     */

                    head = tail = eleman;
                    head.next = tail;
                    head.prev = tail;
                    
                    tail.next = head;
                    tail.prev = head;

                    Console.WriteLine("Liste Oluşturuldu Eklendi");
                }
                else
                {
                    eleman.next = head;
                    head.prev = eleman;

                    head = eleman;

                    head.prev = tail;
                    tail.next = head;

                    Console.WriteLine("Başa Eleman Eklendi");
                }
            }
            public void sonaEkle(int data)
            {
                Node eleman = new Node(data);

                if (head == null)
                {
                    /*
                     * eleman.next = eleman;
                     * eleman.prev = eleman;
                     */

                    head = tail = eleman;
                    head.next = tail;
                    head.prev = tail;

                    tail.next = head;
                    tail.prev = head;

                    Console.WriteLine("Liste Oluşturuldu Eklendi");
                }
                else
                {
                    tail.next = eleman;
                    eleman.prev = tail;

                    tail = eleman;

                    tail.next = head;
                    head.prev = tail;

                    Console.WriteLine("Sona Eleman Eklendi");
                }
            }

            public void Yazdır()
            {
                if(head == null)
                    Console.WriteLine("Liste Boş");
                else
                {
                    Node temp = head;
                    Console.Write("Baş -->");
                    while (temp != tail)
                    {
                        Console.Write(temp.data +" ->");
                        temp = temp.next;
                    }
                    Console.Write(temp.data + " --> son");
                }
            }

            public void tersYazdır()
            {
                if (head == null)
                    Console.WriteLine("Liste Boş");
                else
                {
                    Node temp = tail;
                    Console.Write("Son -->");
                    while (temp != head)
                    {
                        Console.Write(temp.data + " ->");
                        temp = temp.prev;
                    }
                    Console.Write(temp.data + " --> baş");
                }
            }

            //SİLME İŞLEMLERİ

            public void bastanSil()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste Boş");
                }
                else if(head.next == head)
                {
                    head = tail = null;
                    Console.WriteLine("Eleman silindi, listede eleman kalmadı");
                }
                else
                {
                    head = head.next;
                    head.prev = tail;
                    tail.next = head;
                    Console.WriteLine("Baştan Eleman Silindi");
                }
            }

            public void bsondanSil()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste Boş");
                }
                else if (head.next == head)
                {
                    head = tail = null;
                    Console.WriteLine("Eleman silindi, listede eleman kalmadı");
                }
                else
                {
                    tail = tail.prev;
                    tail.next = head;
                    head.prev = tail;

                    Console.WriteLine("Sondan Eleman Silindi");
                }
            }

            // ARAYA EKLEME - SİLME 

            public void arayaEkle(int indis, int data)
            {
                Node eleman = new Node(data);

                if (head == null && indis == 0)
                {
                    head = tail = eleman;

                    tail.next = head;
                    tail.prev = head;
                    head.next = tail;
                    head.prev = tail;
                    Console.WriteLine("Liste oluşturuldu, ilk eleman eklendi");
                }
                else if (head != null && indis == 0)
                {
                    basaEkle(data);
                }
                else
                {
                    int i = 0;
                    Node temp = head;
                    Node temp2 = head;

                    while (temp != tail)
                    {
                        temp2 = temp;
                        temp = temp.next;
                        i++;
                        if (i == indis)
                        {
                            temp2.next = eleman;
                            eleman.prev = temp2;

                            eleman.next = temp;
                            temp.prev = eleman;
                            i++;
                            Console.WriteLine("Araya eleman eklendi");
                            break;
                        }
                        temp2 = temp;
                        temp = temp.next;
                        i++;
                    }
                    if (i == indis)
                    {
                        temp2.next = eleman;
                        eleman.prev = temp2;

                        eleman.next = temp;
                        temp.prev = eleman;
                        Console.WriteLine("Araya eleman eklendi");
                    }
                }
            }
            public void aradanSil(int indis)
            {
                if (head == null)
                {
                    Console.WriteLine("Liste Boş");
                }
                else if (head.next == head && indis ==0)
                {
                    head = tail = null;
                    Console.WriteLine("Eleman silindi, listede eleman kalmadı");
                }
                else if (head.next != head && indis == 0)
                {
                    bastanSil();
                }
                else
                {
                    Node temp = head;
                    Node temp2 = head;
                    int i = 0;
                    while (temp != tail)
                    {
                        if (i == indis)
                        {
                            temp2.next = temp.next;
                            temp.next.prev = temp2;
                            Console.WriteLine("Aradan Eleman eklendi");
                            i++;
                            break;
                        }
                        temp2 = temp;
                        temp = temp.next;
                        i++;
                    }
                    if (i == indis)
                    {
                        tail = tail.prev;
                        tail.next = head;
                        head.prev = tail;
                    }
                }
            }


        }
    }
}
